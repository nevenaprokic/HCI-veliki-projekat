using SyncfusionWpfApp1.Model;
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
    /// Interaction logic for EditTrainLine.xaml
    /// </summary>
    public partial class EditTrainLine : Window
    {
        public EditTrainLine(RowDataTrainLine line)
        {
            InitializeComponent();
        }
        private void Close_Handler(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }
    
    }
}
