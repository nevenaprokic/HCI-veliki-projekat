using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for TrainUpdateDelete.xaml
    /// </summary>
    public partial class TrainUpdateDelete : Page
    {
        private Frame frame;
        public ObservableCollection<RowDataWagon> Rows { get; set; }
        public ObservableCollection<Train> Trains { get; set; }
        public Train SelectedTrain { get; set; }
        public List<Wagon> Wagons { get; set; }

        public TrainUpdateDelete(Frame f)
        {
            InitializeComponent();
            frame = f;
            DataContext = this;
            Trains = new ObservableCollection<Train>(MainRepository.Trains);
            Rows = new ObservableCollection<RowDataWagon>();
            SetBackground();
            InitForm();
        }

        private void InitForm()
        {
            comboClass.Items.Add(WagonClass.FIRST);
            comboClass.Items.Add(WagonClass.SECOND);
            comboClass.SelectedItem = 0;
            NumberWagonsTextBox.Text = "1";
        }

        private void ResetForm()
        {
            comboClass.SelectedItem = 0;
            NumberWagonsTextBox.Text = "1";
            NumberSeatsTextBox.Text = "";
        }


        private void SetBackground()
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DeleteTrain_Handler(object sender, RoutedEventArgs e)
        { 
        
        }

        private void Save_Handler(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            int selectedIndex = dataGrid.SelectedIndex;
            if (selectedIndex == -1) return;
            //newTime.Text = Rows[selectedIndex].Time;
            //editMode();
        }

        private void AddWagon_Handler(object sender, RoutedEventArgs e)
        {
            Rows.Add(new RowDataWagon(Int32.Parse(NumberSeatsTextBox.Text), Int32.Parse(NumberWagonsTextBox.Text), (WagonClass)comboClass.SelectedItem));
            ResetForm();
        }

        private void DeleteRow_Handler(object sender, RoutedEventArgs e)
        {
            int forRemove = dataGrid.SelectedIndex;
            Rows.RemoveAt(forRemove);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //editLabel.Content = "Unesite novo vreme za: " + comboSchedule.SelectedItem?.ToString();
            SelectedTrain = (Train)comboSchedule.SelectedItem;
            drawTable();
            //CheckSelection();
            //insertMode();
            //drawTable();
        }

        private void drawTable()
        {
            Rows.Clear();
            if (SelectedTrain == null) return;
            foreach (Wagon w in SelectedTrain.Wagons)
            {
                RowDataWagon r = new RowDataWagon(w.NumberOfSeats, 1, w.Class);
                Rows.Add(r);
            }
        }

    }
}
