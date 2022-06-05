using SyncfusionWpfApp1.Model;
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
            priceLabel.Content = Ticket.Price + " din.";
            
            retRerunLabelsVisibilty();
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
                inidrectRideLabel.Visibility = Visibility.Visible;
            }
            else
            {
                inidrectRideLabel.Visibility = Visibility.Hidden;
            }
        }
    }
}
