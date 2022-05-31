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
        public bool AlreadyInInsertMode { get; set; }

        public TrainUpdateDelete(Frame f)
        {
            InitializeComponent();
            frame = f;
            DataContext = this;
            Trains = new ObservableCollection<Train>(MainRepository.Trains);
            Rows = new ObservableCollection<RowDataWagon>();
            AlreadyInInsertMode = true;
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
            ConfirmDialog cofirmDialog = new ConfirmDialog("Obriši voz i njegove vagone?");
            if ((bool)cofirmDialog.ShowDialog())
            {
                int index = comboSchedule.SelectedIndex;
                if (index == -1) return;

                Train t = MainRepository.Trains[index];
                foreach (Wagon w in t.Wagons)
                {
                    MainRepository.Wagons.RemoveAll(p => p.Id == w.Id);
                }
                Trains.Remove(SelectedTrain);
                MainRepository.Trains.RemoveAt(index);
                comboSchedule.SelectedItem = null;
                drawTable();
                NotificationDialog dialog = new NotificationDialog("Uspešno ste obrisali izabrani voz i njegove vagone.");
                if ((bool)dialog.ShowDialog())
                {
                    return;
                }
            }           
        }

        private void Save_Handler(object sender, RoutedEventArgs e)
        {
            int index = comboSchedule.SelectedIndex;
            if (index == -1) return;

            Train t = MainRepository.Trains[index];
            foreach (Wagon w in t.Wagons)
            {
                MainRepository.Wagons.RemoveAll(p => p.Id == w.Id);
            }
            MainRepository.Trains.RemoveAt(index);

            MainRepository.Trains.Add(SelectedTrain);
            NotificationDialog dialog = new NotificationDialog("Uspešno ste izmenili izabrani voz i njegove vagone.");
            if ((bool)dialog.ShowDialog())
            {
                return;
            }
        }

        private void insertMode()
        {
            Uri uri = new Uri("../../../images/add_icon.png", UriKind.RelativeOrAbsolute);
            editIcon.Source = BitmapFrame.Create(uri);
            NumberSeatsTextBox.Text = "";
            NumberWagonsTextBox.Text = "1";
            comboClass.SelectedItem = WagonClass.FIRST;

            if (!AlreadyInInsertMode)
            {
                iconButton.Click += AddWagon_Handler;
                iconButton.Click -= EditWagon_Handler;
            }
            AlreadyInInsertMode = true;
        }

        private void editMode()
        {
            Uri uri = new Uri("../../../images/edit_icon.png", UriKind.RelativeOrAbsolute);
            editIcon.Source = BitmapFrame.Create(uri);

            if (AlreadyInInsertMode)
            {
                iconButton.Click -= AddWagon_Handler;
                iconButton.Click += EditWagon_Handler;
            }
            AlreadyInInsertMode = false;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            int selectedIndex = dataGrid.SelectedIndex;
            if (selectedIndex == -1) return;

            NumberSeatsTextBox.Text = Rows[selectedIndex].NumOfSeats.ToString();
            NumberWagonsTextBox.Text = Rows[selectedIndex].NumOfWagons.ToString();
            comboClass.SelectedItem = Rows[selectedIndex].Class;
            editMode();
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

        private void EditWagon_Handler(object sender, RoutedEventArgs e)
        {
            seatValidationLabel.Content = "";
            wagonValidationLabel.Content = "";

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
            int selectedIndex = dataGrid.SelectedIndex;
            if (selectedIndex == -1) return;

            SelectedTrain.Wagons[selectedIndex].NumberOfSeats = Int32.Parse(NumberSeatsTextBox.Text);
            if (NumberWagonsTextBox.Text != "1") NumberOfWagonsChanged();
            SelectedTrain.Wagons[selectedIndex].Class = (WagonClass)comboClass.SelectedItem;
            drawTable();
            insertMode();
        }

        private void NumberOfWagonsChanged()
        {
            int nextOrderNumber = SelectedTrain.Wagons.OrderByDescending(item => item.OrderdNumber).First().OrderdNumber + 1;
            int nextId = SelectedTrain.Wagons.OrderByDescending(item => item.Id).First().Id + 1;

            for (int i = 0; i < Int32.Parse(NumberWagonsTextBox.Text) - 1; i++)
            {
                SelectedTrain.Wagons.Add(new Wagon(nextId, Int32.Parse(NumberSeatsTextBox.Text), (WagonClass)comboClass.SelectedItem, nextOrderNumber));
                nextOrderNumber++;
                nextId++;
            }
        }

        private void DeleteRow_Handler(object sender, RoutedEventArgs e)
        {
            int forRemove = dataGrid.SelectedIndex;
            Rows.RemoveAt(forRemove);
            SelectedTrain.Wagons.RemoveAt(forRemove);
        }

        private void CreateTrain_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new CreateTrain(frame);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedTrain = (Train)comboSchedule.SelectedItem;
            drawTable();
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
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_ticket.Visibility = Visibility.Collapsed;
                tt_schedule.Visibility = Visibility.Collapsed;
                tt_trainLine.Visibility = Visibility.Collapsed;
                tt_maps.Visibility = Visibility.Collapsed;
                tt_trainLineReport.Visibility = Visibility.Collapsed;
                tt_train.Visibility = Visibility.Collapsed;
                tt_report_monthly.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_ticket.Visibility = Visibility.Visible;
                tt_schedule.Visibility = Visibility.Visible;
                tt_trainLine.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_trainLineReport.Visibility = Visibility.Visible;
                tt_train.Visibility = Visibility.Visible;
                tt_report_monthly.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void TicketReport_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void TicketReservation_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void MonthlyReport_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new MonthlyReport(frame);
        }
        private void TrainLineReport_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TrainLineReport(frame);
        }
        private void Schedule_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new ScheduleUpdateDelete(frame);
        }
        private void NetworkTrainLine_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new NetworkTrainLine(frame);
        }
        private void TrainLine_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TrainLineCRUD(frame);
        }
        private void Train_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TrainUpdateDelete(frame);
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            // img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            //img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }


    }
}
