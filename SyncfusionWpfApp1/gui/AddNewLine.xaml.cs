﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using System.Windows.Shapes;
using BingMapsRESTToolkit;
using BingMapsRESTToolkit.Extensions;
using Microsoft.Maps.MapControl.WPF;
using SyncfusionWpfApp1.help;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;

namespace SyncfusionWpfApp1.gui
{
    /// <summary>
    /// Interaction logic for AddNewLine.xaml
    /// </summary>
    public partial class AddNewLine : Window
    {
        private Frame frame;
        System.Windows.Point startPoint = new System.Windows.Point();
        private string BingMapsKey = "AusVMyYktKC6acBY2olTotz0tcbvBRx6Oal5XaWYcP-lXLpvW2Ejy162U2hIubv6";

        private string SessionKey;
        private List<SimpleWaypoint> waypoints = new List<SimpleWaypoint>();
        private Pushpin pin;
        private List<TrainStation> newTrainStations = new List<TrainStation>();
        private List<TrainStationInfo> newTrainStationInfo = new List<TrainStationInfo>();
        public ObservableCollection<TrainLine> TrainLines { get; set; }
        private TrainLine CurrentLine;
        public delegate void drawDelegate();
        private EditTrainLine Line;
        public AddNewLine(TrainLine currentTrainLine, EditTrainLine line)
        {
            InitializeComponent();
            CurrentLine = currentTrainLine;
            Line = line;
            foreach (DictionaryEntry kvp in currentTrainLine.Map)
            {
                TrainStation t = (TrainStation)kvp.Key;
                comboLines.Items.Add(t.Name);
            }
           
            comboLines.SelectedItem = 0;

            DataContext = this;
            initMap();
        }
        private void initMap()
        {
            MainMap.Mode = new RoadMode();
            MainMap.Focus();
            MainMap.Culture = "sr-Latn-RS";
            MainMap.CredentialsProvider = new ApplicationIdCredentialsProvider(BingMapsKey);
            MainMap.CredentialsProvider.GetCredentials((c) =>
            {
                SessionKey = c.ApplicationId;
            });
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

            pin = new Pushpin();
            pin.Location = pinLocation;


            waypoints.Add(new SimpleWaypoint(pinLocation.Latitude.ToString() + "," + pinLocation.Longitude.ToString()));
            CreatePoint point = new CreatePoint(pinLocation.Latitude.ToString(), pinLocation.Longitude.ToString(), this, false);
            if (point.Show)
                point.Show();


        }
        public void DeleteLast()
        {
            waypoints.RemoveAt(waypoints.Count - 1);
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
        private void Save_Handler(object sender, RoutedEventArgs e)
        {
            if (newTrainStations.Count < 1)
            {
                NotificationDialog dialog = new NotificationDialog("Nije moguce kreirati novu liniju bez njenih koordinata!");
                if ((bool)dialog.ShowDialog())
                    return;

                return;
            }
            string station = comboLines.Text;
            if (station.Equals(""))
            {
                station = (string)comboLines.Items.GetItemAt(0);
            }
            OrderedDictionary newDict = new OrderedDictionary();
            IDictionaryEnumerator myEnumerator = CurrentLine.Map.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                TrainStation t = (TrainStation)myEnumerator.Key;
                newDict.Add(myEnumerator.Key, myEnumerator.Value);
                if (station.Equals(t.Name))
                {
                    newDict.Add(newTrainStations[0], newTrainStationInfo[0]);
                }
            }
            CurrentLine.Map.Clear();
            CurrentLine.Map = newDict;

            drawDelegate p = new drawDelegate(Line.drawTableTrainLine);
            p.Invoke();
            this.Close();
            this.Close();

        }
        public void SaveLast(string street, string city, string state, double price, int minute)
        {
            TrainStation station = new TrainStation(street, state, city, (MainRepository.trainStations.Count + 2));
            newTrainStations.Add(station);
            TrainStationInfo stationInfo = new TrainStationInfo(minute, price);
            newTrainStationInfo.Add(stationInfo);
            MainMap.Children.Add(pin);
            img1.Visibility = Visibility.Hidden;
        }
        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Button b = null;
            var windows = Application.Current.Windows;
            foreach (var window in windows)
            {
                IEnumerable<Button> buttons = FindVisualChilds<Button>((DependencyObject)window);
                if (buttons != null)
                {
                    foreach (var button in buttons)
                    {
                        if (button.Name.Equals("helpButton"))
                        {
                            b = button;
                        }
                    }
                }
            }
            string path = HelpProvider.GetHelpKey((DependencyObject)b);
            HelpProvider.ShowHelp(path, this);
        }
        public IEnumerable<T> FindVisualChilds<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChilds<T>(ithChild)) yield return childOfChild;
            }
        }
        private void playVideoHandler(object sender, RoutedEventArgs e)
        {
            MediaElement m = new MediaElement(@"../../../videos/dodavanjeMedjustanice.wmv");
            m.ShowDialog();
        }
    }
}
