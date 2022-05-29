using SyncfusionWpfApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CreateTrain.xaml
    /// </summary>
    public partial class CreateTrain : Page
    {
        private Frame frame;
        public Train NewTrain { get; set; }
        public List<Wagon> Wagons { get; set; }

        public CreateTrain(Frame f)
        {
            InitializeComponent();
            frame = f;
            DataContext = this;
            NewTrain = new Train();
            setBackground();
        }

        private void setBackground()
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
        }

        private bool validInput()
        {
            return nameBox.Text != "";
        }

        private void Save_Handler(object sender, RoutedEventArgs e)
        {
            if (!validInput())
            {
                messageLabel.Content = "Naziv je obavezan.";
                return;
            }

        }
    }
}
