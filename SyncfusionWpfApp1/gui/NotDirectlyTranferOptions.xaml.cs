using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.service;
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
    /// Interaction logic for NotDirectlyTranferOptions.xaml
    /// </summary>
    public partial class NotDirectlyTranferOptions : Page
    {
        public NotDirectlyTranferOptions(TrainStation startStation, TrainStation endStation, DateTime startDateTime)
        {
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
            NotDirectionRideService service = new NotDirectionRideService();
            service.getNotDirectionsRide(startStation, endStation, startDateTime);
        }
    }
}
