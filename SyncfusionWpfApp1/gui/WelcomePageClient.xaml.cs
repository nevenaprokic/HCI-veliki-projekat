using SyncfusionWpfApp1.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace SyncfusionWpfApp1.gui
{
    /// <summary>
    /// Interaction logic for WelcomePageClient.xaml
    /// </summary>
    public partial class WelcomePageClient : Page
    {
        private Frame frame;

        public WelcomePageClient(Frame f)
        {
            InitializeComponent();
            frame = f;
            Uri iconUriMail = new Uri("../../../images/proba.png", UriKind.RelativeOrAbsolute);
            //logoIcon.Source = BitmapFrame.Create(iconUriMail);
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;

            setWarningMessage();

        }

        private void setWarningMessage()
        {
            if (TicketService.checkTickectsExpire(TicketService.getCurrentClientTickets()))
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(3);
                WarrningMessage.Visibility = Visibility.Visible;
                WarrningBorder.Visibility = Visibility.Visible;
                WarningTitle.Visibility = Visibility.Visible;
                WarningImg.Visibility = Visibility.Visible;

                timer.Tick += (s, en) => {
                    WarrningMessage.Visibility = Visibility.Hidden;
                    WarrningBorder.Visibility = Visibility.Hidden;
                    WarningTitle.Visibility = Visibility.Hidden;
                    WarningImg.Visibility = Visibility.Hidden;
                    timer.Stop(); // Stop the timer
                };
                timer.Start();
            }
            else
            {
                WarrningMessage.Visibility = Visibility.Hidden;
                WarrningBorder.Visibility = Visibility.Hidden;
            }
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
    }
}
