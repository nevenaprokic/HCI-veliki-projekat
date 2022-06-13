using SyncfusionWpfApp1.dto;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using SyncfusionWpfApp1.service;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ClientTrainLinesOverview.xaml
    /// </summary>
    public partial class ClientTrainLinesOverview : Page, INotifyPropertyChanged
    {
        Frame frame { get; set; }
        private List<TrainLineDTO> _allLines { get; set; }
        public List<TrainStation> trainStations { get; set; }
        private TrainLineDTO _selectedLine;
        private string _selectedLineNames;
        private List<RowDataSchedule> _selectedSchedual;

        public List<RowDataSchedule> SelectedSchedual
        {
            get
            {
                return _selectedSchedual;
            }
            set
            {
                if(_selectedSchedual != value)
                {
                    _selectedSchedual = value;
                    RaisePropertyChanged(nameof(SelectedSchedual));
                }
            }
        }

        public TrainLineDTO SelectedLine
        {
            get { return _selectedLine; }
            set
            {
                if(_selectedLine != value)
                {
                    _selectedLine = value;
                    RaisePropertyChanged(nameof(SelectedLine));
                }
            }
        }

        public string SelectedLineNames
        {
            get { return _selectedLineNames; }
            set
            {
                if (_selectedLineNames != value)
                {
                    _selectedLineNames = value;
                    RaisePropertyChanged(nameof(SelectedLineNames));
                }
            }
        }


        public List<TrainLineDTO> AllLines
        {
            get { return _allLines; }
            set
            {
                if(_allLines != value)
                {
                    _allLines = value;
                    RaisePropertyChanged(nameof(AllLines));

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
        public ClientTrainLinesOverview(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
            Uri iconUriMail = new Uri("../../../images/proba.png", UriKind.RelativeOrAbsolute);

            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;

            AllLines = TrainLineService.converLinesToDTO(MainRepository.trainLines);
            SelectedLine = AllLines.First();
            SelectedLineNames = "";
            setMessageLabel();

            trainStations = MainRepository.trainStations;
            DataContext = this;
        }

        private void TicketReport_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TicketsOverview(frame);
        }
        private void TicketReservation_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new CardReservation(frame);
        }
        private void NetworkTrainLine_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new NetworkLineClient(frame);
        }
        private void TrainLine_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new ClientTrainLinesOverview(frame);
        }
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_ticket.Visibility = Visibility.Collapsed;
                tt_trainLine.Visibility = Visibility.Collapsed;
                tt_maps.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;

            }
            else
            {
                tt_ticket.Visibility = Visibility.Visible;
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

        private void Logout_Handler(object sender, RoutedEventArgs e)
        {

            frame.Content = new LoginPage(frame);
            frame.NavigationService.RemoveBackEntry();
        }

        private void FIlter_Click(object sender, RoutedEventArgs e)
        {
            TrainStation startStation = (TrainStation) StartStation.SelectedItem;
            TrainStation endStation = (TrainStation)EndStation.SelectedItem;
            TrainStation containedStation = (TrainStation)ContainedStation.SelectedItem;
            List<TrainLine> filterdLines = TrainLineService.filterTrainLinesByStations(startStation, endStation, containedStation);
            AllLines = TrainLineService.converLinesToDTO(filterdLines);

            setMessageLabel();
        }

        private void setMessageLabel()
        {
            if (AllLines.Count == 0)
            {
                MessageLabel.Visibility = Visibility.Visible;
            }
            else
            {
                MessageLabel.Visibility = Visibility.Hidden;
            }
        }

        private void TrsinLinesDetails_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)e.OriginalSource;
            SelectedLine = (TrainLineDTO)b.DataContext;
            SelectedLineNames = SelectedLine.StartStation.Name + "  ---> " +
                                SelectedLine.EndStation.Name;
            scahedualSelector.SelectedIndex = 0;
            TrainLinesTableView.Visibility = Visibility.Hidden;
            TrainLineDeatils.Visibility = Visibility.Visible;
            

        }

        private void SchedualSelection_chancged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            ComboBoxItem selectedItem = (ComboBoxItem)box.SelectedItem;
            string selection = (string)selectedItem.Content;
            if (selection.Equals("Vikend"))
            {
                SelectedSchedual = SelectedLine.WeekendDaySchedual;
            }
            else
            {
                SelectedSchedual = SelectedLine.WorkingDaySchedual;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            TrainLinesTableView.Visibility = Visibility.Visible;
            TrainLineDeatils.Visibility = Visibility.Hidden;
        }

        private void playVideoHandler(object sender, RoutedEventArgs e)
        {

        }
    }
}
