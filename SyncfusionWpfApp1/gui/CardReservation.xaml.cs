using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
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
using SyncfusionWpfApp1.repo;
using System.ComponentModel;
using SyncfusionWpfApp1.dto;
using SyncfusionWpfApp1.validators;
using SyncfusionWpfApp1.expetion;
using SyncfusionWpfApp1.service;
using Syncfusion.Windows.Shared;

namespace SyncfusionWpfApp1.gui
{
    /// <summary>
    /// Interaction logic for CardReservation.xaml
    /// </summary>
    /// 

    public partial class CardReservation : Page, INotifyPropertyChanged
    {
        public Frame frame { get; set; }
        public List<TrainStation> trainStations { get; set; }
        public List<string> stationsNames { get; set; }
        public List<Ticket> tickets { get; set; }
        public List<string> trainClasses { get; set; }

        private List<string> _sortedStartTimes;
        private List<string> _sortedBackTimes;

        private List<TrainRide> _trainRides;

        private TrainStation startStation;
        private TrainStation endStation;
        private DateTime _startDate;
        private DateTime _backDate;
        private String _startTime;
        private String _backTime;
        private TrainLine _trainLine;
        private Train _train;
        private Wagon _wagon;
        public String WagonOrder;
        private int seat;
        public String SeatNumber;
        private List<Train> _awailableTrains;
        private List<Seat> _awailableSeats;
        private List<Wagon> _selectedTrainWagons;

        public List<Wagon> SelectedTrainWagons
        {
            get { return _selectedTrainWagons; }
            set
            {
                if(_selectedTrainWagons != value)
                {
                    _selectedTrainWagons = value;
                    RaisePropertyChanged(nameof(SelectedTrainWagons));
                }
            }
        }

        public Wagon Wagon
        {
            get { return _wagon; }
            set
            {
                if(_wagon != value)
                {
                    _wagon = value;
                    WagonOrder = _wagon.OrderdNumber.ToString();
                    RaisePropertyChanged(nameof(Wagon));
                    RaisePropertyChanged(nameof(WagonOrder));
                }
            }
        }
        public Train Train { 
            get { return _train; }
            set
            {
                if(_train != value)
                {
                    _train = value;
                    RaisePropertyChanged(nameof(Train));
                }
            }
        }

        public List<Train> AwailableTrains {
            get { return _awailableTrains; }
            set
            {
                if (_awailableTrains != value)
                {
                    _awailableTrains = value;
                    RaisePropertyChanged(nameof(AwailableTrains));
                }
            }
        }

        public List<Seat> AwailableSeats
        {
            get { return _awailableSeats; }
            set
            {
                if(_awailableSeats != value)
                {
                    _awailableSeats = value;
                    RaisePropertyChanged(nameof(AwailableSeats));
                }
            }
        }
           
        public List<String> SortedStartTimes
        {
            get { return _sortedStartTimes; }

            set
            {
                if (_sortedStartTimes != value)
                {
                    _sortedStartTimes = value;
                    RaisePropertyChanged(nameof(SortedStartTimes));
                }
            }
            

        }

        public List<String> SortedBackTimes
        {
            get { return _sortedBackTimes; }

            set
            {
                if (_sortedBackTimes != value)
                {
                    _sortedBackTimes = value;
                    RaisePropertyChanged(nameof(SortedBackTimes));
                }
            }
        }

        public List<TrainRide> TrainRides
        {
            get { return _trainRides;  }
            set
            {
                if(_trainRides != value)
                {
                    _trainRides = value;
                    RaisePropertyChanged(nameof(TrainRides));
                }
            }
        }
        public String StartTime
        {
            get { return _startTime; }

            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    RaisePropertyChanged(nameof(StartTime));
                    startTimeError.Content = "";
                    startTimePicker.BorderBrush = Brushes.Transparent;
                    startTimePicker.BorderThickness = new Thickness(1, 1, 1, 1);
                }
            }
        }

        public String BackTime
        {
            get { return _backTime; }

            set
            {
                if (_backTime != value)
                {
                    _backTime = value;
                    RaisePropertyChanged("BackTime");
                    backTimeError.Content = "";
                    backTimePicker.BorderBrush = Brushes.Transparent;
                    backTimePicker.BorderThickness = new Thickness(1, 1, 1, 1);
                }
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }

            set
            {
                
                if (_startDate != value)
                {
                    _startDate = value;
                    RaisePropertyChanged(nameof(StartDate));
                    
                }
            }
        }

        public DateTime BackDate
        {
            get { return _backDate; }

            set
            {
                if (_backDate != value)
                {
                    _backDate = value;
                    RaisePropertyChanged(nameof(BackDate));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void RaisePropertyChanged(String propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }


        private List<TrainLine> selectedLines { get; set; }


        public IEnumerable<WagonClass> wagonClasses  {get; set;}
        public CardReservation()
        {
            InitializeComponent();
        }

        public CardReservation(Frame f)
        {
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
            Uri iconUriMail = new Uri("../../../images/trian_station.png", UriKind.RelativeOrAbsolute);
            trainIcon.Source = BitmapFrame.Create(iconUriMail);
            trainIcon1.Source = BitmapFrame.Create(iconUriMail);
            trainIcon2.Source = BitmapFrame.Create(iconUriMail);
            Uri iconUriArrow = new Uri("../../../images/arrow.png", UriKind.RelativeOrAbsolute);
            arrow.Source = BitmapFrame.Create(iconUriArrow);
            arrow1.Source = BitmapFrame.Create(iconUriArrow);
            arrow2.Source = BitmapFrame.Create(iconUriArrow);
            arrow3.Source = BitmapFrame.Create(iconUriArrow);
            arrow4.Source = BitmapFrame.Create(iconUriArrow);
            arrow5.Source = BitmapFrame.Create(iconUriArrow);
            arrow6.Source = BitmapFrame.Create(iconUriArrow);
            arrow7.Source = BitmapFrame.Create(iconUriArrow);
            arrow8.Source = BitmapFrame.Create(iconUriArrow);
            //arrow4.Source = BitmapFrame.Create(iconUriArrow);
            frame = f;
            trainStations = MainRepository.trainStations;
            tickets = MainRepository.Tickets;
            wagonClasses = Enum.GetValues(typeof(WagonClass)).Cast<WagonClass>();
            generateStationsNames();
            SortedStartTimes = MainRepository.getTimeList(MainRepository.trainLines, DateTime.Now);
            SortedBackTimes = MainRepository.getTimeList(MainRepository.trainLines, DateTime.Now);


            DataContext = this;
        }

        private void generateStationsNames()
        {
            stationsNames = new List<string>();
            foreach(TrainStation station in trainStations)
            {
                String name = station.City + ", " +  station.Street + " " + station.Number + ", "  +station.Country;
                stationsNames.Add(name);
            }
        }

        private void FistPageNextBtnClicked(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (checkFullFields())
                {
                    DateTime startDateTime = convertToFullDateTime(StartDate, StartTime);
                    DateTime backDateTime = convertToFullDateTime(BackDate, BackTime);
                    if (DateTimeValidator.validateDates(startDateTime, backDateTime))
                    {
                        this.FirstPage.Visibility = Visibility.Hidden;
                        this.SecondPage.Visibility = Visibility.Visible;

                        TrainRides = MainRepository.filterSelectedLines(startStation, endStation, startDateTime, backDateTime);
                        AwailableTrains = TrainService.getTrainsForLines(MainRepository.selectMatchingTrainLine(startStation, endStation));

                    }
                   

                }


            }
            catch(StartDateAfterBackDateException exception)
            {
                backDateError.Content = exception.Message;
                backDatePicker.BorderBrush = Brushes.Red;
                backDatePicker.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            catch (StartTimeAfterBackTimeException exception)
            {
                backTimeError.Content = exception.Message;
                backTimePicker.BorderBrush = Brushes.Red;
                backTimePicker.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            catch (PassedDateException exception)
            {
                startDateError.Content = exception.Message;
                startDatePicker.BorderBrush = Brushes.Red;
                startDatePicker.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            catch (TooEarlyReservationException exception)
            {
                startDateError.Content = exception.Message;
                startDatePicker.BorderBrush = Brushes.Red;
                startDatePicker.BorderThickness = new Thickness(2, 2, 2, 2);
            }

        }

        private bool checkFullFields()
        {
            int emptyFieldsNum = 0;

            if (startStation == null)
            {
                startStationLabel.Content = "Obavezno polje";
                startStationSelection.BorderBrush = Brushes.Red;
                startStationSelection.BorderThickness = new Thickness(2, 2, 2, 2);
                emptyFieldsNum++;
            }

            if (endStation == null)
            {
                endStationLabel.Content = "Obavezno polje";
                endStationSelection.BorderBrush = Brushes.Red;
                endStationSelection.BorderThickness = new Thickness(2, 2, 2, 2);
                emptyFieldsNum++;
            }
            if (StartDate == DateTime.MinValue)
            {
                startDateError.Content = "Obavezno polje";
                startDatePicker.BorderBrush = Brushes.Red;
                startDatePicker.BorderThickness = new Thickness(2, 2, 2, 2);
                emptyFieldsNum++;
            }

            if (BackDate == DateTime.MinValue)
            {
                backDateError.Content = "Obavezno polje";
                backDatePicker.BorderBrush = Brushes.Red;
                backDatePicker.BorderThickness = new Thickness(2, 2, 2, 2);
                emptyFieldsNum++;
            }
            if (StartTime == null)
            {
                startTimeError.Content = "Obavezno polje";
                startTimePicker.BorderBrush = Brushes.Red;
                startTimePicker.BorderThickness = new Thickness(2, 2, 2, 2);
                emptyFieldsNum++;
            }
            if (BackTime == null)
            {
                backTimeError.Content = "Obavezno polje";
                backTimePicker.BorderBrush = Brushes.Red;
                backTimePicker.BorderThickness = new Thickness(2, 2, 2, 2);
                emptyFieldsNum++;
            }

            if (emptyFieldsNum > 0) return false;
            return true;
        
        }

        private DateTime convertToFullDateTime(DateTime date, string time)
        {
            string[] timeTokens = time.Split(":");
            DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, int.Parse(timeTokens[0]), int.Parse(timeTokens[1]), 0);
            return dateTime;
        }

        private void StartStationChanged(object sender, SelectionChangedEventArgs e)
        {
            startStationLabel.Content = "";
            startStationSelection.BorderBrush = Brushes.Transparent;
            startStationSelection.BorderThickness = new Thickness(1, 1, 1, 1);
            ComboBox cmb = sender as ComboBox;
            startStation = (TrainStation)cmb.SelectedItem;
        }

        private void EndStationChanged(object sender, SelectionChangedEventArgs e)
        {
            endStationLabel.Content = "";
            endStationSelection.BorderBrush = Brushes.Transparent;
            endStationSelection.BorderThickness = new Thickness(1, 1, 1, 1);
            ComboBox cmb = sender as ComboBox;
            endStation = (TrainStation) cmb.SelectedItem;
        }

        private void startDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            startDateError.Content = "";
            startDatePicker.BorderBrush = Brushes.Transparent;
            startDatePicker.BorderThickness = new Thickness(1, 1, 1, 1);
            DatePicker picker = sender as DatePicker;
            StartDate = (DateTime)picker.SelectedDate;
            //selekotvanje vremena polaska
            //dobaviti sve vozne linije koje sadrze ove dve stanice u odgovarajucem redosledu
            selectedLines = MainRepository.selectMatchingTrainLine(startStation, endStation);
            SortedStartTimes = MainRepository.getTimeList(selectedLines, StartDate);
        }

        private void endDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            backDateError.Content = "";
            backDatePicker.BorderBrush = Brushes.Transparent;
            backDatePicker.BorderThickness = new Thickness(1, 1, 1, 1);
            DatePicker picker = sender as DatePicker;
            BackDate = (DateTime)picker.SelectedDate;
            selectedLines = MainRepository.selectMatchingTrainLine(startStation, endStation);
            SortedBackTimes = MainRepository.getTimeList(selectedLines, BackDate);
        }

        private void SecondPageBackBtnClicked(object sender, RoutedEventArgs e)
        {
            this.FirstPage.Visibility = Visibility.Visible;
            this.SecondPage.Visibility = Visibility.Hidden;
        }

        private void trainSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            Train = (Train)cmb.SelectedItem;
            TrainRides = TrainLineService.filterTrainRidesByTrain(TrainRides, Train);

        }

        private void maxPriceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DoubleTextBox doubleTextBox = d as DoubleTextBox;
            double price = (double) e.NewValue;
            TrainRides = TrainLineService.filterTrainRidesByMaxPrice(TrainRides, price);

        }

        private void SecondPageNextBtnClicked(object sender, RoutedEventArgs e)
        {
            TrainRide selectedRide = (TrainRide)TrainRidesDataGrid.SelectedItem;
            AwailableSeats = SeatService.getLineAwailableSeats(selectedRide.line, selectedRide.train, selectedRide.startStation, selectedRide.start);
            if(selectedRide == null)
            {
                SecondPageErrorLabel.Content = "Niste odabrali nijednu vožnju";
                SecondPageErrorLabel.Visibility = Visibility.Visible;
            }
            else
            {
                SecondPage.Visibility = Visibility.Hidden;
                ThirdPage.Visibility = Visibility.Visible;
                double padding = 2;

                for(int i=0; i < 5; i++)
                {
                    if (i == 2) continue;
                    for (int j=0; j<6; j++)
                    {
                        Button b = addImageBtn(i);
                        RowDefinition r = new RowDefinition();
                        //b.Background = Brushes.Red;
                        double heigh = SeatsGrid.ActualHeight / 6 - padding;
                        r.Height = new GridLength(heigh);
                        SeatsGrid.RowDefinitions.Add(r);
                        SeatsGrid.Children.Add(b);
                        Grid.SetRow(b, j);
                        Grid.SetColumn(b, i);

                    }
                   
                }
            }
            
        }

        private Button addImageBtn(int i)
        {
            Image img = new Image();
            Uri seatIcon = new Uri("../../../images/blue_seat.png", UriKind.RelativeOrAbsolute);
            if (i % 2 == 0)
            {
                seatIcon = new Uri("../../../images/red_seat.png", UriKind.RelativeOrAbsolute);
            }
            
            img.Source = BitmapFrame.Create(seatIcon);
            Label l = new Label();
            l.Content = i;

            StackPanel stackPnl = new StackPanel();
            stackPnl.Orientation = Orientation.Horizontal;
            stackPnl.Background = Brushes.Transparent;
            stackPnl.Children.Add(img);
            stackPnl.Children.Add(l);

            Button btn = new Button();
            btn.Content = stackPnl;
            btn.Background = Brushes.White;
            return btn;
        }

        private void wagonSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            Wagon = (Wagon)box.SelectedItem;
            AwailableSeats = SeatService.getWagonAwailableSeats(AwailableSeats, Wagon);
            //drawSeats();
        }
    }
}
