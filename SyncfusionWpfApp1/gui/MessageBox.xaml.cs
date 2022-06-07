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
using System.Windows.Shapes;

namespace SyncfusionWpfApp1.gui
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class MessageBox : Window
    {
        public Window parentWindow { get; set; }
        public MessageBox(String message, Window parentWindow)
        {
            InitializeComponent();
            txtMessage.Text = message;
            if (parentWindow != null)
            {
                this.parentWindow = parentWindow;
                parentWindow.IsEnabled = false;
                
                Canvas.SetLeft(this, parentWindow.Left + parentWindow.Width / 2.8);
                Canvas.SetTop(this, parentWindow.Top + parentWindow.Height / 2.3);
            }
            else
            {
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
           
        }

        private void Ok_clicked(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            if(parentWindow != null)
            {
                parentWindow.IsEnabled = true;
            }
          
        }
    }
}
