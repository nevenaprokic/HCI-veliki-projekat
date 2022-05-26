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
            frame.Content = new CardReservation();
        }

    }
}
