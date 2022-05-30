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
    public class RowDataWagon
    {
        
        public WagonClass Class { get; set; }
        public int NumOfSeats { get; set; }
        public int NumOfWagons { get; set; }

        public RowDataWagon(int numOfSeats, int numOfWagons, WagonClass wclass)
        {
            Class = wclass;
            NumOfSeats = numOfSeats;
            NumOfWagons = numOfWagons;
        }
    }

    public partial class CreateTrain : Page
    {
        private Frame frame;
        public ObservableCollection<RowDataWagon> Rows { get; set; }
        public Train NewTrain { get; set; }
        public List<Wagon> Wagons { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;
        public string TrainName
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value.ToString();
                    OnPropertyChanged("TrainName");
                }
            }
        }

        public CreateTrain(Frame f)
        {
            InitializeComponent();
            frame = f;
            DataContext = this;
            NewTrain = new Train();
            Rows = new ObservableCollection<RowDataWagon>();
            TrainName = "";
            SetBackground();
            InitForm();
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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

        private bool ValidInput()
        {
            return nameBox.Text != "";
        }

        private void Save_Handler(object sender, RoutedEventArgs e)
        {
            if (!ValidInput())
            {
                nameValidationLabel.Content = "Naziv je obavezan.";
                return;
            }
            //BuildTrain();
            NotificationDialog dialog = new NotificationDialog("Uspešno ste kreirali novi voz i njegove vagone.");
            if ((bool)dialog.ShowDialog())
                return;
            ResetForm();

        }

        private void BuildTrain()
        {
            NewTrain.Name = TrainName;
            int wagonId = NextWagonId();
            foreach (RowDataWagon r in Rows)
            {
                for (int i = 0; i < r.NumOfWagons; i++)
                {
                    NewTrain.Wagons.Add(new Wagon());
                }
            }
        }

        private int NextWagonId()
        {
            int maxVal = 0;
            foreach(Wagon w in MainRepository.Wagons)
            {
                if (maxVal < w.Id) maxVal = w.Id;
            }
            return maxVal;
        }

        private void TextBoxName_Changed(object sender, TextChangedEventArgs e)
        {
            nameValidationLabel.Content = "";
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            //int selectedIndex = dataGrid.SelectedIndex;
            //if (selectedIndex == -1) return;
            //newTime.Text = Rows[selectedIndex].Time;
            //editMode();
        }

        private void AddWagon_Handler(object sender, RoutedEventArgs e)
        {
            seatValidationLabel.Content = "";
            wagonValidationLabel.Content = "";
            classValidationLabel.Content = "";

            if (NumberSeatsTextBox.Text == "")
            {
                seatValidationLabel.Content = "Broj sedišta je obavezan.";
                return;
            }
            if (NumberWagonsTextBox.Text == "")
            {
                wagonValidationLabel.Content = "Broj vagona je obavezan.";
                return;
            }
            if (comboClass.SelectedItem == null)
            {
                classValidationLabel.Content = "Razred vagona je obavezan.";
                return;
            }
            Rows.Add(new RowDataWagon(Int32.Parse(NumberSeatsTextBox.Text), Int32.Parse(NumberWagonsTextBox.Text), (WagonClass)comboClass.SelectedItem));
            ResetForm();
        }

        private void DeleteRow_Handler(object sender, RoutedEventArgs e)
        {
            int forRemove = dataGrid.SelectedIndex;
            Rows.RemoveAt(forRemove);
        }

        
    }
}
