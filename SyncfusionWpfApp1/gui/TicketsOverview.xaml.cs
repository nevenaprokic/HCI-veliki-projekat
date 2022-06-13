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

        public void RaisePropertyChanged(String propertyName)
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
            checkExpiringReservations();
            DataContext = this;
        }

        private void checkExpiringReservations()
        {
            if (TicketService.checkTickectsExpire(ClientTickets))
            {
                ReservationExpireLabel.Visibility = Visibility.Visible;
            }
            else
            {
                ReservationExpireLabel.Visibility = Visibility.Hidden;
            }
        }

        private void bindingTicketsData()
        {
            ClientTickets = TicketService.getCurrentClientTickets();
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
            frame.NavigationService.RemoveBackEntry();
            frame.Content = new LoginPage(frame);
            
        }

        private void TicketDetailsClick(object sender, RoutedEventArgs e)
        {
            var v = (Button)e.OriginalSource;
            Ticket t = (Ticket)v.DataContext;
            TicketDetailsDialog ticketDetails = new TicketDetailsDialog(t);
            ticketDetails.setClientTickets(ClientTickets);
            
            ticketDetails.PropertyChanged += (o, s) => {
                this.ClientTickets = TicketService.getCurrentClientTickets();
                checkExpiringReservations();

            };
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
            bool all = false;
            bool bought = false;
            if (ticketType == null || ticketType.Content.Equals("Sve")) all = true;
            else
            {
                string s = (string)ticketType.Content;
                if (s.Equals("Kupljene")) bought = true;
            }
         
            
            if (maxPrice == 0.00) maxPrice = 100000;
            
            
            ClientTickets = TicketService.filterTickets(ClientTickets, start, end, maxPrice, bought, all);
            if(ClientTickets.Count == 0)
            {
                MessageLabel.Visibility = Visibility.Visible;
            }
            else
            {
                MessageLabel.Visibility = Visibility.Hidden;
            }
        }

        private void playVideoHandler(object sender, RoutedEventArgs e)
        {

        }
    }
}
