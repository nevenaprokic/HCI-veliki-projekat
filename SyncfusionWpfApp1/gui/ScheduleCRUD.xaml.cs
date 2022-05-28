using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class RowDataSchedule
    {
        public string Time { get; set; }
        
        public RowDataSchedule(string time)
        {
            Time = time;
        }
    }
    public partial class ScheduleCRUD : Page
    {
        private Frame frame;
        public Schedule SelectedSchedule { get; set; }
        public ObservableCollection<Schedule> Schedules { get; set; }
        public ObservableCollection<RowDataSchedule> Rows { get; set; }

        public ScheduleCRUD(Frame f)
        {
            InitializeComponent();
            frame = f;
            Schedules = new ObservableCollection<Schedule>(MainRepository.Schedules);
            DataContext = this;
            SelectedSchedule = MainRepository.Schedules[0];
            comboSchedule.ItemsSource = Schedules;
            Rows = new ObservableCollection<RowDataSchedule>();
            drawTable();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedSchedule = (Schedule)comboSchedule.SelectedItem;
            drawTable();
        }

        private void AddTime_Handler(object sender, RoutedEventArgs e)
        {
            SelectedSchedule.Times.Add(newTime.Text);
            SelectedSchedule.Times = sortTimes();
            drawTable();
            newTime.Text = "";
        }

        private void DeleteRow_Handler(object sender, RoutedEventArgs e)
        {
            int forRemove = dataGrid.SelectedIndex;
            SelectedSchedule.Times.RemoveAt(forRemove);
            drawTable();
        }

        private void DeleteSchedule_Handler(object sender, RoutedEventArgs e)
        {
            Schedules.Remove(SelectedSchedule);
            MainRepository.Schedules.Remove(SelectedSchedule);
            comboSchedule.SelectedItem = null;
        }

        private List<String> sortTimes()
        {
            List<DateTime> dateTimes = new List<DateTime>();
            foreach(string input in SelectedSchedule.Times)
            {
                var time = TimeSpan.Parse(input);
                var dateTime = DateTime.Today.Add(time);
                dateTimes.Add(dateTime);
            }
            dateTimes.Sort((ps1, ps2) => DateTime.Compare(ps1, ps2));

            List<String> sorted = new List<string>();
            foreach (DateTime t in dateTimes)
            {
                sorted.Add(t.ToString("HH:mm"));
            }

            return sorted;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            int selectedIndex = dataGrid.SelectedIndex;
            Console.WriteLine(selectedIndex);
            newTime.Text = Rows[selectedIndex].Time;
        }

        private void drawTable()
        {
            Rows.Clear();
            if (SelectedSchedule == null) return;
            foreach (string s in SelectedSchedule.Times)
            {
                RowDataSchedule r = new RowDataSchedule(s);
                Rows.Add(r);
            }
        }
    }
}
