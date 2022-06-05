using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BingMapsRESTToolkit;
using BingMapsRESTToolkit.Extensions;
using Microsoft.Maps.MapControl.WPF;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System.Collections;
using System.Collections.ObjectModel;

namespace SyncfusionWpfApp1.gui
{
    /// <summary>
    /// Interaction logic for NetworkLineClient.xaml
    /// </summary>
    public partial class NetworkLineClient : Page
    {
        private Frame frame;
        private string BingMapsKey = "AusVMyYktKC6acBY2olTotz0tcbvBRx6Oal5XaWYcP-lXLpvW2Ejy162U2hIubv6";

        private string SessionKey;
        private List<SimpleWaypoint> waypoints = new List<SimpleWaypoint>();
        public ObservableCollection<TrainLine> TrainLines { get; set; }

        public NetworkLineClient(Frame f)
        {
            InitializeComponent();
            frame = f;
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;

            TrainLines = new ObservableCollection<TrainLine>(MainRepository.trainLines);
            foreach (TrainLine t in TrainLines)
            {
                comboLines.Items.Add(t.Start.Name + " - " + t.End.Name);
            }
            comboLines.SelectedItem = 0;

            DataContext = this;

            MainMap.Mode = new RoadMode();
            MainMap.Focus();
            MainMap.Culture = "sr-Latn-RS";
            MainMap.CredentialsProvider = new ApplicationIdCredentialsProvider(BingMapsKey);
            MainMap.CredentialsProvider.GetCredentials((c) =>
            {
                SessionKey = c.ApplicationId;
            });

        }


        private async void CalculateRouteBtn_Clicked(object sender, RoutedEventArgs e)
        {
            MainMap.Children.Clear();
            int index = comboLines.SelectedIndex;
            if (index == -1) return;

            LoadingBar.Visibility = Visibility.Visible;

            var waypoints = GetWaypoints(index);

            if (waypoints.Count < 2)
            {
                NotificationDialog dialog = new NotificationDialog("Potrebno je minimalno dva pina kako bi se ruta nacrtala!");
                if ((bool)dialog.ShowDialog())
                    return;
            }

            var travelMode = (TravelModeType)Enum.Parse(typeof(TravelModeType), (string)("Walking"));
            var tspOptimization = (TspOptimizationType)Enum.Parse(typeof(TspOptimizationType), (string)("StraightLineDistance"));
            try
            {
                //Calculate a route between the waypoints so we can draw the path on the map. 
                var routeRequest = new RouteRequest()
                {
                    Waypoints = waypoints,

                    //Specify that we want the route to be optimized.
                    WaypointOptimization = tspOptimization,

                    RouteOptions = new RouteOptions()
                    {
                        TravelMode = travelMode,
                        RouteAttributes = new List<RouteAttributeType>()
                        {
                            RouteAttributeType.RoutePath,
                            RouteAttributeType.ExcludeItinerary
                        }
                    },

                    //When straight line distances are used, the distance matrix API is not used, so a session key can be used.
                    BingMapsKey = (tspOptimization == TspOptimizationType.StraightLineDistance) ? SessionKey : BingMapsKey
                };

                //Only use traffic based routing when travel mode is driving.
                if (routeRequest.RouteOptions.TravelMode != TravelModeType.Driving)
                {
                    routeRequest.RouteOptions.Optimize = RouteOptimizationType.Time;
                }
                else
                {
                    routeRequest.RouteOptions.Optimize = RouteOptimizationType.TimeWithTraffic;
                }

                var r = await routeRequest.Execute();

                RenderRouteResponse(routeRequest, r);
            }
            catch (Exception ex)
            {

                NotificationDialog dialog = new NotificationDialog("Greška, pokušajte ponovo...");
                if ((bool)dialog.ShowDialog())
                    return;
            }

            LoadingBar.Visibility = Visibility.Collapsed;
        }
        private List<SimpleWaypoint> GetWaypoints(int index)
        {
            waypoints.Clear();
            TrainLine line = TrainLines[index];
            waypoints.Add(new SimpleWaypoint(line.Start.Name));
            foreach (DictionaryEntry kvp in line.Map)
            {
                waypoints.Add(new SimpleWaypoint(kvp.Key.ToString()));
            }
            waypoints.Add(new SimpleWaypoint(line.End.Name));

            return waypoints;
        }
        private void RenderRouteResponse(RouteRequest routeRequest, Response response)
        {
            //Render the route on the map.
            if (response != null && response.ResourceSets != null && response.ResourceSets.Length > 0 &&
               response.ResourceSets[0].Resources != null && response.ResourceSets[0].Resources.Length > 0
               && response.ResourceSets[0].Resources[0] is Route)
            {
                var route = response.ResourceSets[0].Resources[0] as Route;

                var routeLine = route.RoutePath.Line.Coordinates;
                var routePath = new LocationCollection();

                for (int i = 0; i < routeLine.Length; i++)
                {
                    routePath.Add(new Microsoft.Maps.MapControl.WPF.Location(routeLine[i][0], routeLine[i][1]));
                }

                var routePolyline = new MapPolyline()
                {
                    Locations = routePath,
                    Stroke = new SolidColorBrush(Colors.Red),
                    StrokeThickness = 3
                };

                MainMap.Children.Add(routePolyline);

                var locs = new List<Microsoft.Maps.MapControl.WPF.Location>();

                //Create pushpins for the optimized waypoints.
                //The waypoints in the request were optimized for us.
                for (var i = 0; i < routeRequest.Waypoints.Count; i++)
                {
                    var loc = new Microsoft.Maps.MapControl.WPF.Location(routeRequest.Waypoints[i].Coordinate.Latitude, routeRequest.Waypoints[i].Coordinate.Longitude);

                    //Only render the last waypoint when it is not a round trip.
                    if (i < routeRequest.Waypoints.Count - 1)
                    {
                        MainMap.Children.Add(new Pushpin()
                        {
                            Location = loc,
                            Content = i
                        });
                    }

                    locs.Add(loc);
                }

                MainMap.SetView(locs, new Thickness(50), 0);
            }
            else if (response != null && response.ErrorDetails != null && response.ErrorDetails.Length > 0)
            {
                throw new Exception(String.Join("", response.ErrorDetails));
            }
        }

        private void TicketReport_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new CardReservation(frame);
        }
        private void TicketReservation_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void Schedule_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void NetworkTrainLine_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new NetworkTrainLine(frame);
        }
        private void TrainLine_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TrainLineView(frame);
        }
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_ticket.Visibility = Visibility.Collapsed;
                tt_schedule.Visibility = Visibility.Collapsed;
                tt_trainLine.Visibility = Visibility.Collapsed;
                tt_maps.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_ticket.Visibility = Visibility.Visible;
                tt_schedule.Visibility = Visibility.Visible;
                tt_trainLine.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }
        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            // img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            //img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }
    }
}
