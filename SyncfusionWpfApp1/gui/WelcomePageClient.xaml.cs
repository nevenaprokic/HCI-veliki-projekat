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
            logoIcon.Source = BitmapFrame.Create(iconUriMail);
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;

        }
        private void TicketCreate_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new CardReservation();
        }
        private void TicketReprt_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void Schedule_Handler(object sender, RoutedEventArgs e) { }
        private void NetworkTrainLine_Handler(object sender, RoutedEventArgs e) { }
        private void TrainLine_Handler(object sender, RoutedEventArgs e) { }

    }
}
