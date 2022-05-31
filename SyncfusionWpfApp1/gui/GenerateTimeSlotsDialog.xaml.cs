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
using System.Windows.Shapes;
using SyncfusionWpfApp1.gui;

namespace SyncfusionWpfApp1.gui
{
    /// <summary>
    /// Interaction logic for GenerateTimeSlotsDialog.xaml
    /// </summary>
    public partial class GenerateTimeSlotsDialog : Window
    {
        public delegate void someDelegate(string a, string b, int interval);
        public CreateSchedule Parent { get; set; }

        public GenerateTimeSlotsDialog(CreateSchedule createSchedule)
        {
            InitializeComponent();
            comboStart.ItemsSource = GenerateTimesForComboBox("00:00", "23:00", 60);
            comboEnd.ItemsSource = GenerateTimesForComboBox("00:00", "23:00", 60);
            Parent = createSchedule;
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            someDelegate p = null;
            p = Parent.GenerateTimeSlots;
            p.Invoke(comboStart.SelectedItem.ToString(), comboEnd.SelectedItem.ToString(), Int32.Parse(intervalTextBox.Text));
            this.Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private List<string> GenerateTimesForComboBox(string startTime, string endTime, int interval)
        {
            List<string> slots = new List<string>();
            TimeSpan t1 = TimeSpan.Parse(startTime);
            TimeSpan t2 = TimeSpan.Parse(endTime);

            while (t1 <= t2)
            {
                slots.Add(t1.ToString());
                t1 += TimeSpan.FromMinutes(interval);
            }
            return slots;
        }
    }
}
