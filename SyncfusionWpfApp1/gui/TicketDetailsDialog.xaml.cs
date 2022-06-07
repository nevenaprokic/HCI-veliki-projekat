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
using System.Windows.Shapes;

namespace SyncfusionWpfApp1.gui
{
    /// <summary>
    /// Interaction logic for TicketDetailsDialog.xaml
    /// </summary>
    public partial class TicketDetailsDialog : Window, INotifyPropertyChanged
    {
        public Ticket Ticket { get; set; }
        private DateTime _arrivalTime;
        private List<Ticket> _clientTickets;
        
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

        public DateTime ArrivalTime
        {
            get { return _arrivalTime; }
            set
            {
                if(_arrivalTime != value)
                {
                    _arrivalTime = value;

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



        public TicketDetailsDialog(Ticket ticket)
        {
            InitializeComponent();
       
            Uri clockIcon = new Uri("../../../images/arrival-time-_1_ (1).png", UriKind.RelativeOrAbsolute);
            ClockIcon1.Source = BitmapFrame.Create(clockIcon);
            ClockIcon2.Source = BitmapFrame.Create(clockIcon);
            Uri locationIcon = new Uri("../../../images/location.png", UriKind.RelativeOrAbsolute);
            ClockIcon1.Source = BitmapFrame.Create(clockIcon);
            startIcon.Source = BitmapFrame.Create(locationIcon);
            endIcon.Source = BitmapFrame.Create(locationIcon);
            Ticket = ticket;
            DataContext = Ticket;
            //priceLabel.Content = Ticket.Price + " din.";

            renderButtons();
            retRerunLabelsVisibilty();
        }

        private void renderButtons()
        {
            if (!Ticket.bought && Ticket.Client.Email.Equals(MainRepository.CurrentUser))
            {
                Exit1.Visibility = Visibility.Visible;
                reservationCancelBtn.Visibility = Visibility.Visible;
                boughtBtn.Visibility = Visibility.Visible;
                Exit2.Visibility = Visibility.Hidden;
            }
            else
            {
                Exit1.Visibility = Visibility.Hidden;
                reservationCancelBtn.Visibility = Visibility.Hidden;
                boughtBtn.Visibility = Visibility.Hidden;
                Exit2.Visibility = Visibility.Visible;
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = true;
            this.Close();
        }

        private void retRerunLabelsVisibilty()
        {
            if (Ticket.ReturnTicket)
            {
                returnTicketLabel.Visibility = Visibility.Visible;
            }
            else
            {
                returnTicketLabel.Visibility = Visibility.Hidden;
            }
            if (Ticket.IndirectRide)
            {
                indirectRideLabel.Visibility = Visibility.Visible;
            }
            else
            {
                indirectRideLabel.Visibility = Visibility.Hidden;
            }
        }

        public void setClientTickets(List<Ticket> tickets)
        {
            ClientTickets = tickets;
        }
        private void Reservation_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainRepository.Tickets.Remove(Ticket);
            ClientTickets = TicketService.getCurrentClientTickets();
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClientTickets)));
            this.Close();
        }

        private void Bought_Click(object sender, RoutedEventArgs e)
        {
            Ticket.bought = true;
            ClientTickets = TicketService.getCurrentClientTickets();
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClientTickets)));
            this.Close();
            this.Close();
        }
    }
}
