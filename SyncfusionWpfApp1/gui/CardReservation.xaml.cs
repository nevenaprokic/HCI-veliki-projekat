using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using SyncfusionWpfApp1.dto;
using SyncfusionWpfApp1.validators;
using SyncfusionWpfApp1.expetion;
using SyncfusionWpfApp1.service;
using System.Globalization;
using System.Threading;
using System.Windows.Input;

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

        private TrainStation _startStation;
        private TrainStation _endStation;
        private DateTime _startDate;
        private String _startTime;
        private Train _train;
        private Wagon _wagon;
        public string WagonOrder { get; set; }
        private Seat _seat;
        public string SeatNumber { get; set; }
        private List<Train> _awailableTrains;
        private List<Seat> _awailableSeats;
        private List<Wagon> _selectedTrainWagons;
        private TrainRide _selectedRide;
        private DateTime _startDateTime;
        private DateTime _arrivalDateTime;
        public DateTime ExpireDate { get; set; }
        public bool backTicket { get; set; }

        public DateTime StartDateTime
        {
            get
            {
                return _startDateTime;
            }
            set
            {
                if (_startDateTime != value)
                {
                    _startDateTime = value;
                    RaisePropertyChanged(nameof(StartDateTime));
                }
            }
        }
        public DateTime ArrivalDateTime
        {
            get
            {
                return _arrivalDateTime;
            }
            set
            {
                if (_arrivalDateTime != value)
                {
                    _arrivalDateTime = value;
                    RaisePropertyChanged(nameof(ArrivalDateTime));
                }
            }
        }
        public Seat Seat
        {
            get { return _seat; }
            set
            {
                if(_seat != value)
                {
                    _seat = value;
                    RaisePropertyChanged(nameof(Seat));
                }
            }
        }
        public TrainStation StartStation
        {
            get { return _startStation; }
            set
            {
                if(_startStation != value)
                {
                    _startStation = value;
                    RaisePropertyChanged(nameof(StartStation));
                }
            }
        }

        public TrainStation EndStation
        {
            get { return _endStation; }
            set
            {
                if (_endStation != value)
                {
                    _endStation = value;
                    RaisePropertyChanged(nameof(EndStation));
                }
            }
        }

        public TrainRide SelectedRide
        {
            get { return _selectedRide; }
            set
            {
                if(_selectedRide != value)
                {
                    _selectedRide = value;
                    RaisePropertyChanged(nameof(SelectedRide));
                }
            }
        }

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
                    RaisePropertyChanged(nameof(Wagon));
                   
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


        public DateTime StartDate
        {
            get { return _startDate; }

            set
            {
                
                if (_startDate != value)
                {
                    _startDate = value;
                    ExpireDate = StartDate.AddDays(30);
                    RaisePropertyChanged(nameof(StartDate));
                    RaisePropertyChanged(nameof(ExpireDate));
                    
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
            Uri trainStationIcon = new Uri("../../../images/ticketIcon.jpeg", UriKind.RelativeOrAbsolute);
            trainIcon.Source = BitmapFrame.Create(trainStationIcon);
            trainIcon1.Source = BitmapFrame.Create(trainStationIcon);
            trainIcon2.Source = BitmapFrame.Create(trainStationIcon);
            Uri iconUriArrow = new Uri("../../../images/blue_arrow.png", UriKind.RelativeOrAbsolute);
            arrow.Source = BitmapFrame.Create(iconUriArrow);
            arrow1.Source = BitmapFrame.Create(iconUriArrow);
            arrow2.Source = BitmapFrame.Create(iconUriArrow);
            arrow3.Source = BitmapFrame.Create(iconUriArrow);
            arrow4.Source = BitmapFrame.Create(iconUriArrow);
            arrow5.Source = BitmapFrame.Create(iconUriArrow);
            arrow6.Source = BitmapFrame.Create(iconUriArrow);
            arrow7.Source = BitmapFrame.Create(iconUriArrow);
            arrow8.Source = BitmapFrame.Create(iconUriArrow);
            Uri appIcon = new Uri("../../../images/zeleznica.jpeg", UriKind.RelativeOrAbsolute);
            AppIcon.Source = BitmapFrame.Create(appIcon);
            Uri clockIcon = new Uri("../../../images/arrival-time-_1_ (1).png", UriKind.RelativeOrAbsolute);
            ClockIcon1.Source = BitmapFrame.Create(clockIcon);
            ClockIcon2.Source = BitmapFrame.Create(clockIcon);
            Uri locationIcon = new Uri("../../../images/location.png", UriKind.RelativeOrAbsolute);
            ClockIcon1.Source = BitmapFrame.Create(clockIcon);
            startIcon.Source = BitmapFrame.Create(locationIcon);
            endIcon.Source = BitmapFrame.Create(locationIcon);
            cardArrow1.Source = BitmapFrame.Create(iconUriArrow);
            cardArrow2.Source = BitmapFrame.Create(iconUriArrow);
            arrow9.Source = BitmapFrame.Create(iconUriArrow);
            arrow10.Source = BitmapFrame.Create(iconUriArrow);
            arrow11.Source = BitmapFrame.Create(iconUriArrow);

            trainIcon3.Source = BitmapFrame.Create(trainStationIcon);
            Uri nextIcon = new Uri("../../../images/next.png", UriKind.RelativeOrAbsolute);
            FirstPageNextBtn.Source = BitmapFrame.Create(nextIcon);
            SecondPageNextBtn.Source = BitmapFrame.Create(nextIcon);
            ThirdPageNextBtn.Source = BitmapFrame.Create(nextIcon);
            Uri backIcon = new Uri("../../../images/back.png", UriKind.RelativeOrAbsolute);
            SecondPageBackBtn.Source = BitmapFrame.Create(backIcon);
            ThirdPageBackBtn.Source = BitmapFrame.Create(backIcon);

            frame = f;
            trainStations = MainRepository.trainStations;
            tickets = MainRepository.Tickets;
            wagonClasses = Enum.GetValues(typeof(WagonClass)).Cast<WagonClass>();
            generateStationsNames();
            SortedStartTimes = MainRepository.getTimeList(MainRepository.trainLines, DateTime.Now);
            SortedBackTimes = MainRepository.getTimeList(MainRepository.trainLines, DateTime.Now);

            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            Thread.CurrentThread.CurrentCulture = ci;

            var txt = 

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
                    StartDateTime = convertToFullDateTime(StartDate, StartTime);
                    selectedLines = MainRepository.selectMatchingTrainLine(StartStation, EndStation);
                    if (selectedLines.Count == 0)
                    {

                        offerNotDirectlyTravel();
                    }

                    if (DateTimeValidator.validateDates(StartDateTime))
                    {
                        
                        StartDateTime.Date.ToShortDateString();
                        this.FirstPage.Visibility = Visibility.Hidden;
                        this.SecondPage.Visibility = Visibility.Visible;

                        TrainRides = MainRepository.filterSelectedLines(StartStation, EndStation, StartDateTime, backTicket);
                        AwailableTrains = TrainService.getTrainsForLines(MainRepository.selectMatchingTrainLine(StartStation, EndStation));

                    }
                   

                }


            }
            catch (PassedDateException exception)
            {
                startDateError.Content = exception.Message;
                startDatePicker.BorderBrush = new SolidColorBrush(Color.FromRgb(207, 27, 13));
                startDatePicker.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            catch (TooEarlyReservationException exception)
            {
                startDateError.Content = exception.Message;
                startDatePicker.BorderBrush = new SolidColorBrush(Color.FromRgb(207, 27, 13));
                startDatePicker.BorderThickness = new Thickness(2, 2, 2, 2);
            }

        }

        private bool checkFullFields()
        {
            int emptyFieldsNum = 0;

            if (StartStation == null)
            {
                startStationLabel.Content = "Obavezno polje";
                startStationSelection.BorderBrush = new SolidColorBrush(Color.FromRgb(207, 27, 13));
                startStationSelection.BorderThickness = new Thickness(2, 2, 2, 2);
                emptyFieldsNum++;
            }

            if (EndStation == null)
            {
                endStationLabel.Content = "Obavezno polje";
                endStationSelection.BorderBrush = new SolidColorBrush(Color.FromRgb(207, 27, 13));
                endStationSelection.BorderThickness = new Thickness(2, 2, 2, 2);
                emptyFieldsNum++;
            }
            if (StartDate == DateTime.MinValue)
            {
                startDateError.Content = "Obavezno polje";
                startDatePicker.BorderBrush = new SolidColorBrush(Color.FromRgb(207, 27, 13));
                startDatePicker.BorderThickness = new Thickness(2, 2, 2, 2);
                emptyFieldsNum++;
            }

           
            if (StartTime == null)
            {
                startTimeError.Content = "Obavezno polje";
                startTimePicker.BorderBrush = new SolidColorBrush(Color.FromRgb(207, 27, 13));
                startTimePicker.BorderThickness = new Thickness(2, 2, 2, 2);
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
            StartStation = (TrainStation)cmb.SelectedItem;
            if(EndStation != null)
            {
                startDatePicker.IsEnabled = true;
               
            }
            if(StartStation == null)
            {
                startDatePicker.IsEnabled = false;
                
            }
        }

        private void EndStationChanged(object sender, SelectionChangedEventArgs e)
        {
            endStationLabel.Content = "";
            endStationSelection.BorderBrush = Brushes.Transparent;
            endStationSelection.BorderThickness = new Thickness(1, 1, 1, 1);
            ComboBox cmb = sender as ComboBox;
            EndStation = (TrainStation) cmb.SelectedItem;
            if (StartStation != null)
            {
                startDatePicker.IsEnabled = true;
                
            }
            if (EndStation == null)
            {
                startDatePicker.IsEnabled = false;
                
            }
        }

        private void startDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            startDatePicker.SelectedDate.Value.Date.ToShortDateString();
            startDateError.Content = "";
            startDatePicker.BorderBrush = Brushes.Transparent;
            startDatePicker.BorderThickness = new Thickness(1, 1, 1, 1);
            DatePicker picker = sender as DatePicker;
            StartDate = (DateTime)picker.SelectedDate;
            //selekotvanje vremena polaska
            //dobaviti sve vozne linije koje sadrze ove dve stanice u odgovarajucem redosledu
            
            selectedLines = MainRepository.selectMatchingTrainLine(StartStation, EndStation);
            if(selectedLines.Count == 0)
            {
                List<TrainLine> linesContainsStartStation = TrainLineService.getLinesWhichContainesStation(StartStation);
                List<TrainLine> linesContainsEndStation = TrainLineService.getLinesWhichContainesStation(EndStation);
                selectedLines = TrainLineService.combileListOfTrainLines(linesContainsEndStation, linesContainsStartStation);
                
            }
            
            SortedStartTimes = MainRepository.getTimeList(selectedLines, StartDate);
            startTimePicker.IsEnabled = true;
            if (StartDate == DateTime.MinValue)
            {
                startTimePicker.IsEnabled = false;

            }
            //dodati event na satnicu  KOMENTAR
            else if (StartDate - DateTime.Now <= TimeSpan.FromHours(24))
            {
                disableReservationOption();
            }
            else
            {
                restoreReservationOption();
            }
            
            
        }

        private void offerNotDirectlyTravel()
        {
            frame.Content = new NotDirectlyTranferOptions(frame, StartStation, EndStation, StartDateTime, backTicket);
        }

        private void disableReservationOption()
        {
            ReservBtn.Visibility = Visibility.Hidden;
            CancelBtnFirst.Visibility = Visibility.Hidden;
            CancelBtnSecond.Visibility = Visibility.Visible;
            ReservationMessageLabel.Visibility = Visibility.Visible;
        }

        private void restoreReservationOption()
        {
            ReservBtn.Visibility = Visibility.Visible;
            CancelBtnFirst.Visibility = Visibility.Visible;
            CancelBtnSecond.Visibility = Visibility.Hidden;
            ReservationMessageLabel.Visibility = Visibility.Hidden;
        }

        private void SecondPageBackBtnClicked(object sender, RoutedEventArgs e)
        {
            this.FirstPage.Visibility = Visibility.Visible;
            this.SecondPage.Visibility = Visibility.Hidden;
        }

        private void SecondPageNextBtnClicked(object sender, RoutedEventArgs e)
        {
            SelectedRide = (TrainRide)TrainRidesDataGrid.SelectedItem;
            
            if(SelectedRide == null)
            {
                SecondPageErrorLabel.Content = "Niste odabrali nijednu vožnju";
                SecondPageErrorLabel.Visibility = Visibility.Visible;
                SecondPageErrorBox.Visibility = Visibility.Visible;
            }
            else
            {
                ArrivalDateTime = StartDateTime.AddMinutes(SelectedRide.travelDuration);
                AwailableSeats = SeatService.getLineAwailableSeats(SelectedRide.line, SelectedRide.train, SelectedRide.startStation, SelectedRide.start);
                SelectedTrainWagons = TrainService.getTrainWagonsByClass(SelectedRide.wagonClass, SelectedRide.train);
                SecondPage.Visibility = Visibility.Hidden;
                ThirdPage.Visibility = Visibility.Visible;
                
            }
            
        }

        private Button addImageBtn(Seat seat)
        {
            Button btn = new Button();
            StackPanel stackPnl = new StackPanel();
            Image img = new Image();
            Uri seatIcon = new Uri("../../../images/red_seat.png", UriKind.RelativeOrAbsolute);

            if (AwailableSeats.Contains(seat))
            {
                seatIcon = new Uri("../../../images/green_seat.png", UriKind.RelativeOrAbsolute);
                btn.Click += SeatBtnClicked;
            }
            else
            {
                btn.Click += takenSeatClick;
            }
            
            img.Source = BitmapFrame.Create(seatIcon);
            Label l = new Label();
            l.Content = seat.SeatNumber;
                        
            stackPnl.Orientation = Orientation.Horizontal;
            stackPnl.Background = Brushes.Transparent;
            stackPnl.Children.Add(img);
            stackPnl.Children.Add(l);

            btn.Content = stackPnl;
            btn.Background = Brushes.White;
            return btn;
        }

        private void takenSeatClick(object sender, RoutedEventArgs e)
        {
            ThirdPageErrorLabel.Content = "Ne možete izabrati zauzeto sedište";
            ThirdPageErrorLabel.Visibility = Visibility.Visible;
            ThirdPageErrorBox.Visibility = Visibility.Visible;
        }

        private void wagonSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            Wagon = (Wagon)box.SelectedItem;
            if(Wagon != null)
            {
                Seat = null;
                List<Seat> lineAwailableSeats = SeatService.getLineAwailableSeats(SelectedRide.line, SelectedRide.train, SelectedRide.startStation, SelectedRide.start);
                AwailableSeats = SeatService.getWagonAwailableSeats(lineAwailableSeats, Wagon);
                drawSeats();
            }
            
        }

        private void cleanSeatsGrid()
        {
            if (SeatsGrid.RowDefinitions.Count > 0)
            {
                SeatsGrid.RowDefinitions.RemoveRange(0, SeatsGrid.RowDefinitions.Count);
                SeatsGrid.Children.RemoveRange(0, SeatsGrid.Children.Count);
            }
        }

        private void drawSeats()
        {

            cleanSeatsGrid();
            double padding = 2;
            List<Seat> allWagonSeats = SeatService.allWagonSeats(Wagon);
            int seatsPerColumn = allWagonSeats.Count / 4;
            int seatsCounter = 0;
            for (int i = 0; i < 5; i++)
            {
                if (i == 2) continue;
                for (int j = 0; j < seatsPerColumn; j++)
                {
                    Button b = addImageBtn(allWagonSeats[seatsCounter]);
                    seatsCounter++;
                    RowDefinition r = new RowDefinition();
                    //b.Background = Brushes.Red;
                    double heigh = 50 - padding;
                    r.Height = new GridLength(heigh);
                    SeatsGrid.RowDefinitions.Add(r);
                    SeatsGrid.Children.Add(b);
                    Grid.SetRow(b, j);
                    Grid.SetColumn(b, i);

                }

            }
            if(seatsPerColumn * 4 < allWagonSeats.Count)
            {
                int remainingSeats = allWagonSeats.Count - seatsPerColumn * 4;
                for (int i =0; i<remainingSeats; i++)
                {
                    RowDefinition r = new RowDefinition();
                    //b.Background = Brushes.Red;
                    double heigh = 50 - padding;
                    r.Height = new GridLength(heigh);
                    SeatsGrid.RowDefinitions.Add(r);
                    Button b = addImageBtn(allWagonSeats[seatsCounter]);
                    seatsCounter++;
                    SeatsGrid.Children.Add(b);
                    Grid.SetRow(b, 6);
                    if (i >= 2)
                    {
                        Grid.SetColumn(b, i+1);
                    }
                    else
                    {
                        Grid.SetColumn(b, i);
                    }
                   
                }
            }
        }

        private void SeatBtnClicked(object sender, RoutedEventArgs e)
        {
            ThirdPageErrorLabel.Content = "";
            Button btn = sender as Button;
            StackPanel p = (StackPanel)btn.Content;
            int count = p.Children.Count;
            for (int itr = 0; itr < count; itr++)
            {
                if (p.Children[itr] is Label)
                {
                    Label l = (Label)p.Children[itr];
                    Seat = new Seat(Wagon, (int)l.Content);
                }
            }
        }

        private void TrainRidesDataGrid_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            SecondPageErrorLabel.Content = "";
            SecondPageErrorLabel.Visibility = Visibility.Hidden;
            SecondPageErrorBox.Visibility = Visibility.Hidden;
        }

        private void ThirdPageBackBtnClicked(object sender, RoutedEventArgs e)
        {
            cleanSeatsGrid();
            ThirdPage.Visibility = Visibility.Hidden;
            SecondPage.Visibility = Visibility.Visible;
            
        }

        private bool checkSeatSelection()
        {
            if (Wagon != null && Seat != null) return true;
            return false;
        }

        private void ThirdPageNextBtnClicked(object sender, RoutedEventArgs e)
        {
            if (checkSeatSelection())
            {
                ThirdPage.Visibility = Visibility.Hidden;
                FourthPage.Visibility = Visibility.Visible;
                if (backTicket)
                {
                    returnTicketLabel.Visibility = Visibility.Visible;
                    returnTicketExpireLabel.Visibility = Visibility.Visible;
                    returnTicketExpireDate.Visibility = Visibility.Visible;
                }
                else
                {
                    returnTicketLabel.Visibility = Visibility.Hidden;
                    returnTicketExpireLabel.Visibility = Visibility.Hidden;
                    returnTicketExpireDate.Visibility = Visibility.Hidden;
                }
               
                    
            }
            else
            {
                ThirdPageErrorLabel.Content = "Niste izabrali vagon i sedište";
                ThirdPageErrorBox.Visibility = Visibility.Visible;
            }
           
           

        }

        private void filterTrainRidesClicked(object sender, RoutedEventArgs e)
        {
            Train = (Train)TrainCombobox.SelectedItem;
            double price = (double)priceFilter.Value;
            TrainRides = MainRepository.filterSelectedLines(StartStation, EndStation, StartDateTime, backTicket);

            if (Train != null)
            {
                TrainRides = TrainLineService.filterTrainRidesByTrain(TrainRides, Train);
            }
            if(price != double.MinValue)
            {
                TrainRides = TrainLineService.filterTrainRidesByMaxPrice(TrainRides, price);
            }
            

        }

        private void cancleClicked(object sender, RoutedEventArgs e)
        {
            //povratak na pocetnu stranicu
            //sve bindinge skloniti
            frame.Content = new WelcomePageClient(frame);
        }

        private void removeBindings() { 

        }

        private void reservationTicketClicked(object sender, RoutedEventArgs e)
        {
            //User client, bool returnTicket, TrainLine line, DateTime departureTime, Seat seat, Seat returnSeat, Train train, TrainStation from, TrainStation to
            User client = UserService.findByEmail(MainRepository.CurrentUser);
            Ticket ticket = new Ticket(client, SelectedRide, Seat);
            ticket.bought = false;
            MainRepository.Tickets.Add(ticket);
            String message = "Karta je uspešno rezervisana. Neophodno je da izvršiti kupovinu karte do dan pred polazak. U suprotnom karta ne važi.";
            MessageBox messageBox = new MessageBox(message, MainWindow.GetWindow(this));
            messageBox.Show();
            frame.Content = new WelcomePageClient(frame);
        }
        private void buyTicketClicked(object sender, RoutedEventArgs e)
        {
            //User client, bool returnTicket, TrainLine line, DateTime departureTime, Seat seat, Seat returnSeat, Train train, TrainStation from, TrainStation to
            User client = UserService.findByEmail(MainRepository.CurrentUser);
            Ticket ticket = new Ticket(client, SelectedRide, Seat);
            MainRepository.Tickets.Add(ticket);
            ticket.bought = true;
            String message = "Karta je uspešno kupljena!";
            MessageBox messageBox = new MessageBox(message, MainWindow.GetWindow(this));
            messageBox.Show();
            frame.Content = new WelcomePageClient(frame);
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
            frame.Content = new NetworkLineClient(frame);
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
