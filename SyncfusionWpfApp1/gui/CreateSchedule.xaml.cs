using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace SyncfusionWpfApp1.gui
{
    public partial class CreateSchedule : Page
    {
        public ObservableCollection<RowDataSchedule> Rows { get; set; }
        public bool AlreadyInInsertMode { get; set; }
        public Schedule SelectedSchedule {get; set;}
        private Frame frame;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;
        public string ScheduleName
        {
            get { return _name; }
            set
            {
                if (_name != value) 
                {
                    _name = value.ToString();
                    OnPropertyChanged("ScheduleName");
                }
            }
        }

        public CreateSchedule(){ }

        public CreateSchedule(Frame f)
        {
            InitializeComponent();
            setBackground();
            frame = f;
            SelectedSchedule = new Schedule();
            SelectedSchedule.Times = new List<string>();
            DataContext = this;
            AlreadyInInsertMode = true;
            ScheduleName = "";
            Rows = new ObservableCollection<RowDataSchedule>();
            drawTable();
            editLabel.Content = "Unesite novo vreme za: " + ScheduleName;
        }

        private void setBackground()
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
        }

        private void playVideoHandler(object sender, RoutedEventArgs e) {
            MediaElement m = new MediaElement();
            m.ShowDialog();
        }

        private void AddRow_Handler(object sender, RoutedEventArgs e)
        {
            if (validInput())
            {
                if (TimeAlreadyExists())
                {
                    messageLabel.Content = "Time already exists!";
                    return;
                }
                SelectedSchedule.Times.Add(newTime.Text);
                SelectedSchedule.Times = sortTimes();
                drawTable();
                newTime.Text = "";
                messageLabel.Content = "";
            }
            else
            {
                messageLabel.Content = "Neispravan format. Probajte 'HH:mm'!";
            }
        }

        private bool TimeAlreadyExists()
        {
            foreach (string s in SelectedSchedule.Times)
            {
                if (newTime.Text == s)
                    return true;
            }
            return false;
        }

        private void GenerateRows_Handler(object sender, RoutedEventArgs e)
        {
            GenerateTimeSlotsDialog dialog = new GenerateTimeSlotsDialog(this);
            if ((bool)dialog.ShowDialog())
            {
                drawTable();
            }
        }

        private bool validInput()
        {
            Regex rx = new Regex(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");
            Match m = rx.Match(newTime.Text);
            return m.Success;
        }

        private void DeleteRow_Handler(object sender, RoutedEventArgs e)
        {
            int forRemove = dataGrid.SelectedIndex;
            SelectedSchedule.Times.RemoveAt(forRemove);
            drawTable();
            insertMode();
        }

        private void EditRow_Handler(object sender, RoutedEventArgs e)
        {
            if (validInput())
            {
                int selectedIndex = dataGrid.SelectedIndex;
                if (selectedIndex == -1) return;
                string newValue = newTime.Text;

                SelectedSchedule.Times[selectedIndex] = newValue;
                SelectedSchedule.Times = sortTimes();
                drawTable();
                insertMode();
            }
            else
            {
                messageLabel.Content = "Neispravan format. Probajte 'HH:mm'!";
            }
        }

        private List<String> sortTimes()
        {
            List<DateTime> dateTimes = new List<DateTime>();
            foreach (string input in SelectedSchedule.Times)
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

        public void GenerateTimeSlots(string startTime, string endTime, int interval)
        {
            List<string> slots = new List<string>();
            TimeSpan t1 = TimeSpan.Parse(startTime);
            TimeSpan t2 = TimeSpan.Parse(endTime);

            while (t1 <= t2)
            {
                slots.Add(t1.ToString().Substring(0, 5));
                t1 += TimeSpan.FromMinutes(interval);
            }
            SelectedSchedule.Times = slots;
            drawTable();
        }

        private void insertMode()
        {
            editLabel.Content = "Unesite novo vreme za: " + ScheduleName;
            Uri uri = new Uri("../../../images/add_icon.png", UriKind.RelativeOrAbsolute);
            newTime.Text = "";
            editIcon.Source = BitmapFrame.Create(uri);

            if (!AlreadyInInsertMode)
            {
                iconButton.Click += AddRow_Handler;
                iconButton.Click -= EditRow_Handler;
            }
            AlreadyInInsertMode = true;
            messageLabel.Content = "";
        }

        private void editMode()
        {
            editLabel.Content = "Unesite izmenu za: ";
            Uri uri = new Uri("../../../images/edit_icon.png", UriKind.RelativeOrAbsolute);
            editIcon.Source = BitmapFrame.Create(uri);

            if (AlreadyInInsertMode)
            {
                iconButton.Click -= AddRow_Handler;
                iconButton.Click += EditRow_Handler;
            }
            AlreadyInInsertMode = false;
            messageLabel.Content = "";
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            int selectedIndex = dataGrid.SelectedIndex;
            if (selectedIndex == -1) return;
            newTime.Text = Rows[selectedIndex].Time;
            editMode();
        }

        private void drawTable()
        {
            Rows.Clear();
            foreach (string s in SelectedSchedule.Times)
            {
                RowDataSchedule r = new RowDataSchedule(s);
                Rows.Add(r);
            }
        }

        private void TextBoxName_Changed(object sender, TextChangedEventArgs e)
        {
            nameValidationLabel.Content = "";
        }

        private void Save_Handler(object sender, RoutedEventArgs e)
        {
            if (ScheduleName == "")
            {
                nameValidationLabel.Content = "Naziv je obavezan!";
                return;
            }

            SelectedSchedule.Name = ScheduleName;
            MainRepository.Schedules.Add(SelectedSchedule);
            SelectedSchedule = new Schedule();
            SelectedSchedule.Times = new List<string>();
            ScheduleName = "";
            nameBox.Text = "";
            drawTable();
            NotificationDialog dialog = new NotificationDialog("Uspešno ste kreirali novi red vožnje.");
            if ((bool)dialog.ShowDialog())
                return;
        }

        private void Cancel_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new ScheduleUpdateDelete(frame);
        }

    }
}
