using BingMapsRESTToolkit;
using BingMapsRESTToolkit.Extensions;
using Microsoft.Maps.MapControl.WPF;
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

namespace SyncfusionWpfApp1.gui
{
    public partial class NetworkLine : Page
    {
        private Frame frame;
        System.Windows.Point startPoint = new System.Windows.Point();
        private string BingMapsKey = "AusVMyYktKC6acBY2olTotz0tcbvBRx6Oal5XaWYcP-lXLpvW2Ejy162U2hIubv6";

        private string SessionKey;
        private List<SimpleWaypoint> waypoints = new List<SimpleWaypoint>();

        public NetworkLine(Frame f)
        {
            InitializeComponent();
            frame = f;
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
            MainMap.Mode = new RoadMode();
            MainMap.Focus();
            MainMap.Culture = "sr-Latn-RS";
            MainMap.CredentialsProvider = new ApplicationIdCredentialsProvider(BingMapsKey);
            MainMap.CredentialsProvider.GetCredentials((c) =>
            {
                SessionKey = c.ApplicationId;
            });
            //waypoints.Add(new SimpleWaypoint("Novi Sad, Srbija"));
            //waypoints.Add(new SimpleWaypoint("Beograd, Srbija"));

            //MainMap.MouseDoubleClick += new MouseButtonEventHandler(MapWithPushpins_MouseDoubleClick);
        }
        private void MapWithPushpins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            System.Windows.Point mousePosition = e.GetPosition(this);
            Microsoft.Maps.MapControl.WPF.Location pinLocation = MainMap.ViewportPointToLocation(mousePosition);

            Pushpin pin = new Pushpin();
            pin.Location = pinLocation;


            Coordinates.Text = pinLocation.Longitude.ToString();
            Coordinates1.Text = pinLocation.Latitude.ToString();
            MainMap.Children.Add(pin);

        }
        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Image image = e.Source as Image;
                DataObject data = new DataObject(typeof(ImageSource), image.Source);
                DragDrop.DoDragDrop(image, data, DragDropEffects.Move);
            }
        }
        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            e.Handled = true;

            System.Windows.Point mousePosition = e.GetPosition(MainMap);
            Microsoft.Maps.MapControl.WPF.Location pinLocation = MainMap.ViewportPointToLocation(mousePosition);

            Pushpin pin = new Pushpin();
            pin.Location = pinLocation;


            Coordinates.Text = pinLocation.Longitude.ToString();
            Coordinates1.Text = pinLocation.Latitude.ToString();
            MainMap.Children.Add(pin);
            //add waitpoints
            waypoints.Add(new SimpleWaypoint(pinLocation.Latitude.ToString() + "," + pinLocation.Longitude.ToString()));

        }

        private async void CalculateRouteBtn_Clicked(object sender, RoutedEventArgs e)
        {
            MainMap.Children.Clear();
            //OutputTbx.Text = string.Empty;
            LoadingBar.Visibility = Visibility.Visible;

            var waypoints = GetWaypoints();

            if (waypoints.Count < 2)
            {
                NotificationDialog dialog = new NotificationDialog("Potrebno je minimalno dva pina kako bi se ruta nacrtala!");
                if ((bool)dialog.ShowDialog())
                    return;
                
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
        private List<SimpleWaypoint> GetWaypoints()
        {

            // waypoints = new List<SimpleWaypoint>();

            /*foreach (var p in places)
            {
                if (!string.IsNullOrWhiteSpace(p))
                {
                    waypoints.Add(new SimpleWaypoint(p));
                }
            }*/

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

                var timeSpan = new TimeSpan(0, 0, (int)Math.Round(route.TravelDurationTraffic));

                if (timeSpan.Days > 0)
                {
                    Console.WriteLine(string.Format("Travel Time: {3} days {0} hr {1} min {2} sec\r\n", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Days));
                    //OutputTbx.Text = string.Format("Travel Time: {3} days {0} hr {1} min {2} sec\r\n", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Days);
                }
                else
                {
                    Console.WriteLine(string.Format("Travel Time: {0} hr {1} min {2} sec\r\n", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds));
                    //OutputTbx.Text = string.Format("Travel Time: {0} hr {1} min {2} sec\r\n", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                }

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

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_ticket.Visibility = Visibility.Collapsed;
                tt_schedule.Visibility = Visibility.Collapsed;
                tt_trainLine.Visibility = Visibility.Collapsed;
                tt_maps.Visibility = Visibility.Collapsed;
                tt_trainLineReport.Visibility = Visibility.Collapsed;
                tt_train.Visibility = Visibility.Collapsed;
                tt_report_monthly.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_ticket.Visibility = Visibility.Visible;
                tt_schedule.Visibility = Visibility.Visible;
                tt_trainLine.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_trainLineReport.Visibility = Visibility.Visible;
                tt_train.Visibility = Visibility.Visible;
                tt_report_monthly.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void TicketReport_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void TicketReservation_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void MonthlyReport_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new MonthlyReport(frame);
        }
        private void TrainLineReport_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TrainLineReport(frame);
        }
        private void Schedule_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new ScheduleUpdateDelete(frame);
        }
        private void NetworkTrainLine_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new NetworkTrainLine(frame);
        }
        private void TrainLine_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TrainLineCRUD(frame);
        }
        private void Train_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TrainUpdateDelete(frame);
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
