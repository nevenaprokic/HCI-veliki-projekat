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
        public List<string> _sortedBackTimes { get; set; }

        public List<String> SortedStartTimes
        {
            get { return _sortedStartTimes; }

            set
            {
                if (_sortedStartTimes != value)
                {
                    _sortedStartTimes = value;
                    RaisePropertyChanged("SortedStartTimes");
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
                    RaisePropertyChanged("SortedBackTimes");
                }
            }
        }

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
        
        private TrainStation startStation;
        private TrainStation endStation;
        private DateTime _startDate;
        private DateTime _backDate; 
        private String _startTime;
        private String _backTime;
        private String trainLine;
        private String _train;
        private int wagon;
        private int seat;

        public String StartTime
        {
            get { return _startTime; }

            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    RaisePropertyChanged("StartTime");
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
                    RaisePropertyChanged("StartDate");
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
                    RaisePropertyChanged("BackDate");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
            myBrush.ImageSource = new BitmapImage(new Uri("../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
            Uri iconUriMail = new Uri("../../images/trian_station.png", UriKind.RelativeOrAbsolute);
            trainIcon.Source = BitmapFrame.Create(iconUriMail);
            trainIcon1.Source = BitmapFrame.Create(iconUriMail);
            Uri iconUriArrow = new Uri("../../images/arrow.png", UriKind.RelativeOrAbsolute);
            arrow.Source = BitmapFrame.Create(iconUriArrow);
            arrow1.Source = BitmapFrame.Create(iconUriArrow);
            arrow2.Source = BitmapFrame.Create(iconUriArrow);
            arrow3.Source = BitmapFrame.Create(iconUriArrow);
            arrow4.Source = BitmapFrame.Create(iconUriArrow);
            arrow5.Source = BitmapFrame.Create(iconUriArrow);
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
            //preuzeti podatke i validirati ih
            this.FirstPage.Visibility = Visibility.Hidden;
            this.SecondPage.Visibility = Visibility.Visible;
            

        }

        private void StartStationChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            startStation = (TrainStation)cmb.SelectedItem;
        }

        private void EndStationChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            endStation = (TrainStation) cmb.SelectedItem;
        }

        private void startDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker picker = sender as DatePicker;
            StartDate = (DateTime)picker.SelectedDate;
            //selekotvanje vremena polaska
            //dobaviti sve vozne linije koje sadrze ove dve stanice u odgovarajucem redosledu
            selectedLines = MainRepository.selectMatchingTrainLine(startStation, endStation);
            SortedStartTimes = MainRepository.getTimeList(selectedLines, StartDate);
        }

        private void endDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
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
    }
}
