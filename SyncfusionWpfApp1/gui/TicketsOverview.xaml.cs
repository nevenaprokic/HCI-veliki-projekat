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
    /// Interaction logic for TicketsOverview.xaml
    /// </summary>
    public partial class TicketsOverview : Page, INotifyPropertyChanged
    {
        Frame frame { get; set; }
        private List<Ticket> _clientTickets;
        public List<TrainStation> trainStations { get; set; }

        public List<Ticket> ClientTickets
        {
            get { return _clientTickets; }
            set
            {
                if(_clientTickets != value)
                {
                    _clientTickets = value;
                    RaisePropertyChanged(nameof(ClientTickets));
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

        public TicketsOverview(Frame f)
        {
            bindingTicketsData();

            InitializeComponent();
            frame = f;
            Uri iconUriMail = new Uri("../../../images/proba.png", UriKind.RelativeOrAbsolute);
            
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;

            trainStations = MainRepository.trainStations;

            DataContext = this;
        }

        private void bindingTicketsData()
        {
            ClientTickets = TicketService.getCurrentClientTickets();
        }

        private void TicketReport_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new CardReservation(frame);
        }
        private void TicketReservation_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void MonthlyReport_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void TrainLineReport_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void Schedule_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void NetworkTrainLine_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void TrainLine_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void Train_Handler(object sender, RoutedEventArgs e)
        {


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
                //tt_trainLineReport.Visibility = Visibility.Collapsed;
                //tt_train.Visibility = Visibility.Collapsed;
                //tt_report_monthly.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_ticket.Visibility = Visibility.Visible;
                tt_schedule.Visibility = Visibility.Visible;
                tt_trainLine.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
               /* tt_trainLineReport.Visibility = Visibility.Visible;
                tt_train.Visibility = Visibility.Visible;
                tt_report_monthly.Visibility = Visibility.Visible;*/
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

        private void TicketDetailsClick(object sender, RoutedEventArgs e)
        {
            var v = (Button)e.OriginalSource;
            Ticket t = (Ticket)v.DataContext;
            TicketDetailsDialog ticketDetails = new TicketDetailsDialog(t);
            ticketDetails.Show();

        }
        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            //reset filtera
            ClientTickets = TicketService.getCurrentClientTickets();
            //preuzimanje svih selectovanih vrednsoti
            TrainStation start =(TrainStation) StartStation.SelectedItem; 
            TrainStation end = (TrainStation)endStation.SelectedItem;
            double maxPrice = (Double)priceFilter.Value;
            ComboBoxItem ticketType = (ComboBoxItem)CardType.SelectedItem;
            string s = (string)ticketType.Content;
            bool bought = false;
            bool all = false;
            if (maxPrice == 0.00) maxPrice = 100000;
            if (s.Equals("Kupljene")) bought = true;
            if (s.Equals("Sve")) all = true;
            ClientTickets = TicketService.filterTickets(ClientTickets, start, end, maxPrice, bought, all);
        }


      /*  private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           *//* ComboBoxItem sortParam = (ComboBoxItem)Sort.SelectedItem;
            string param = (string)sortParam.Content;
            if (param.Equals("Cena"))
            {
                ClientTickets = TicketService.sortTicketsByPrice(ClientTickets);
            }
            else
            {
                ClientTickets = TicketService.sortTicketsByDate(ClientTickets);
            }*//*
        }*/
    }
}
