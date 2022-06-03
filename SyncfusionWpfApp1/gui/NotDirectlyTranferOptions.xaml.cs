using SyncfusionWpfApp1.dto;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using SyncfusionWpfApp1.service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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
    /// <summary>
    /// Interaction logic for NotDirectlyTranferOptions.xaml
    /// </summary>
    public partial class NotDirectlyTranferOptions : Page, INotifyPropertyChanged
    {
        private int _selectedRideIndex;
        private DirectionItem _selectedRide;

        private List<DirectionItem> _allIndirectionRides;

        private DateTime _startDateTime;
        private List<TrainRide> _ridesOnDirection;
        private String _travelDurationMessage;
        private double _oneWayPrice;
        private double _twoWaysPrice;

        private Train _train { get; set; }
        private Seat _seat { get; set; }
        private Wagon _wagon { get; set; }



        public int SelectedRideIndex
        {
            get { return _selectedRideIndex;  }
            set
            {
                if(_selectedRideIndex != value)
                {
                    _selectedRideIndex = value;
                    RaisePropertyChanged(nameof(SelectedRideIndex));
                }
            }
        }

        public DirectionItem SelectedRide
        {
            get { return _selectedRide; }
            set
            {
                if (_selectedRide != value)
                {
                    _selectedRide = value;
                    RaisePropertyChanged(nameof(SelectedRide));
                }
            }
        }

        public List<DirectionItem> AllIndirectionRides
        {
            get { return _allIndirectionRides; }
            set
            {
                if (_allIndirectionRides != value)
                {
                    _allIndirectionRides = value;
                    RaisePropertyChanged(nameof(AllIndirectionRides));
                }
            }
        }

        public DateTime StartDateTime
        {
            get { return _startDateTime; }
            set
            {
                if (_startDateTime != value)
                {
                    _startDateTime = value;
                    RaisePropertyChanged(nameof(StartDateTime));
                }
            }
        }

        public List<TrainRide> RidesOnDirection
        {
            get { return _ridesOnDirection; }
            set
            {
                if(_ridesOnDirection != value)
                {
                    _ridesOnDirection = value;
                    RaisePropertyChanged(nameof(RidesOnDirection));
                }
            }
        }

        public String TravelDuratonMessage
        {
            get { return _travelDurationMessage; }
            set
            {
                if (_travelDurationMessage != value)
                {
                    _travelDurationMessage = value;
                    RaisePropertyChanged(nameof(_travelDurationMessage));
                }
            }
        }

        public double OneWayPrice
        {
            get { return _oneWayPrice; }
            set
            {
                if (_oneWayPrice != value)
                {
                    _oneWayPrice= value;
                    RaisePropertyChanged(nameof(OneWayPrice));
                }
            }
        }

        public double TwoWaysPrice
        {
            get { return _twoWaysPrice; }
            set
            {
                if (_twoWaysPrice != value)
                {
                    _twoWaysPrice = value;
                    RaisePropertyChanged(nameof(TwoWaysPrice));
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

        public NotDirectlyTranferOptions(TrainStation startStation, TrainStation endStation, DateTime startDateTime)
        {
            NotDirectionRideService service = new NotDirectionRideService();
            service.getNotDirectionsRide(startStation, endStation, startDateTime);
            AllIndirectionRides = service.directions;
            SelectedRideIndex = 0;
            StartDateTime = startDateTime;
            SelectedRide = AllIndirectionRides.ElementAt(0);
            RidesOnDirection = BindSelectedDirectionData();

            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
            
            drawIcons();
            setButtons();

            DataContext = this;
           
        }

        private void drawIcons()
        {
            Uri travelDurationIcon = new Uri("../../../images/hourglass.png", UriKind.Relative);
            TravelDurationIcon.Source = BitmapFrame.Create(travelDurationIcon);
            Uri backArrowIcon = new Uri("../../../images/back_blue.png", UriKind.Relative);
            Uri nextArrowIcon = new Uri("../../../images/next_blue.png", UriKind.Relative);
            BackArrow.Source = BitmapFrame.Create(backArrowIcon);
            NextArrow.Source = BitmapFrame.Create(nextArrowIcon);
        }

        private void setButtons()
        {
            if(SelectedRideIndex == 0)
            {
                PrevoiusBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                PrevoiusBtn.Visibility = Visibility.Visible;
            }

            if (StartDateTime - DateTime.Now <= TimeSpan.FromHours(24))
            {
                disableReservationOption();
            }
            else
            {
                restoreReservationOption();
            }
        }

        private void disableReservationOption()
        {
            ReservBtn.Visibility = Visibility.Hidden;
            CancelBtnFirst.Visibility = Visibility.Hidden;
            CancelBtnSecond.Visibility = Visibility.Visible;
            //ReservationMessageLabel.Visibility = Visibility.Visible;
        }

        private void restoreReservationOption()
        {
            ReservBtn.Visibility = Visibility.Visible;
            CancelBtnFirst.Visibility = Visibility.Visible;
            CancelBtnSecond.Visibility = Visibility.Hidden;
            //ReservationMessageLabel.Visibility = Visibility.Hidden;
        }

        private List<TrainRide> BindSelectedDirectionData()
        {
            List<TrainRide> rides = new List<TrainRide>();
            int index = 1;
            while (index < SelectedRide.allStations.Count)
            {
                OrderedDictionary d1 = SelectedRide.allStations.ElementAt(index - 1);
                OrderedDictionary d2 = SelectedRide.allStations.ElementAt(index);
                IDictionaryEnumerator d1Enumerator = d1.GetEnumerator();
                IDictionaryEnumerator d2Enumerator = d2.GetEnumerator();

                TrainStation start = null;
                TrainStationInfo startInfo = null;
                TrainStation end = null;
                TrainStationInfo endInfo = null;
                while (d1Enumerator.MoveNext())
                {
                    start = (TrainStation)d1Enumerator.Key;
                    startInfo = (TrainStationInfo)d1Enumerator.Value;


                }
                while (d2Enumerator.MoveNext())
                {
                    end = (TrainStation)d2Enumerator.Key;
                    endInfo = (TrainStationInfo)d2Enumerator.Value;
                }
                //pretraziti slobodan voz
                findFirstTrainWithAwailableSeats(SelectedRide, start, end, StartDateTime);
                TrainRide ride = new TrainRide();
                ride.startStation = start;
                ride.endStation = end;
                ride.train = _train;
                ride.seat = _seat;
                ride.price = endInfo.Price;
                ride.travelDuration = endInfo.FromDeparture;

                if(index == 1)
                {
                    ride.start = calculateSTartTime(StartDateTime, start, end);
                }
                else
                {
                    TrainRide lastTrainLide = rides.Last();
                    ride.start = calculateSTartTime(lastTrainLide.arrivalTime, start, end);
                }
               
                ride.arrivalTime = ride.start.AddMinutes(endInfo.FromDeparture);
                
                rides.Add(ride);
                index++;
            }
            calculateTravelDuration(rides);
            calculatePrice(rides);
            return rides;
        }

        private void calculateTravelDuration(List<TrainRide> rides)
        {
            TrainRide startRide = rides.First();
            TrainRide lastRide = rides.Last();
            double duration = (lastRide.arrivalTime - startRide.start).TotalMinutes;
            double hours = duration / 60;
            string[] hourTokens = hours.ToString().Split(".");
            double minutes = duration - int.Parse(hourTokens[0]) * 60;
            string[] minutesTokens = minutes.ToString().Split(".");
            TravelDuratonMessage = hourTokens[0] + "h " + minutesTokens[0] + "min";
        }

        private DateTime calculateSTartTime(DateTime arrivalTime, TrainStation startStation, TrainStation endStation)
        {
            TrainLine matchingLine = TrainLineService.findMatchingLine(startStation, endStation);
            //racunati preko pocetnog datuma i trajanja putovanja, pa naci najblize vreme u rasporedu
            if(matchingLine != null)
            {
                List<DateTime> schedual = MainRepository.sortedDatesFromString(matchingLine.TimeSlots, arrivalTime);
                DateTime closestTime = findNearestTime(arrivalTime, schedual);
                return closestTime;
            }
            return arrivalTime.AddMinutes(15);
            
        }

        private DateTime findNearestTime(DateTime arrivalTime, List<DateTime> schedual)
        {
            long min = long.MaxValue;
            DateTime closestTime = schedual.ElementAt(0);

            foreach (DateTime date in schedual)
            {

                if ((arrivalTime.Ticks - date.Ticks) < 0)
                {
                    if ((arrivalTime.Ticks - date.Ticks) < min)
                    {
                        min = arrivalTime.Ticks - date.Ticks;
                        closestTime = date;
                    }
                }
            }
            return closestTime;

        }


        private void findFirstTrainWithAwailableSeats(DirectionItem selectedRide, TrainStation start, TrainStation end, DateTime startDateTime)
        {
            IEnumerable<TrainLine> matchingLines = MainRepository.selectMatchingTrainLine(start, end);
            foreach (TrainLine line in matchingLines)
            {
                foreach (Train train in line.Trains)
                {
                    List<Seat> awailableSeats = SeatService.getLineAwailableSeats(line, train, start, startDateTime);
                    if(awailableSeats.Count > 0)
                    {
                        _train = train;
                        _seat = awailableSeats.ElementAt(0);
                        _wagon = _seat.Wagon;
                    }
                }
            }
        }

        private void calculatePrice(List<TrainRide> rides)
        {
            double price = 0;
            foreach(TrainRide ride in rides)
            {
                price += ride.price;
            }
            OneWayPrice = price;
            TwoWaysPrice = price * 1.5;

        } 
    }
}
