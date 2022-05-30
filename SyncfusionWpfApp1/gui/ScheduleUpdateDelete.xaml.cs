﻿using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class RowDataSchedule
    {
        public string Time { get; set; }
        
        public RowDataSchedule(string time)
        {
            Time = time;
        }
    }
    public partial class ScheduleUpdateDelete : Page
    {
        private Frame frame;
        public Schedule SelectedSchedule { get; set; }
        public ObservableCollection<Schedule> Schedules { get; set; }
        public ObservableCollection<RowDataSchedule> Rows { get; set; }
        public bool AlreadyInInsertMode { get; set; }

        public ScheduleUpdateDelete(Frame f)
        {
            InitializeComponent();
            frame = f;
            setBackground();
            Schedules = new ObservableCollection<Schedule>(MainRepository.Schedules);
            DataContext = this;
            SelectedSchedule = MainRepository.Schedules[0];
            comboSchedule.ItemsSource = Schedules;
            AlreadyInInsertMode = true;
            Rows = new ObservableCollection<RowDataSchedule>();
            drawTable();
            comboSchedule.SelectedIndex = 0;
            editLabel.Content = "Unesite novo vreme za: " + comboSchedule.Text;
        }

        private void setBackground()
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editLabel.Content = "Unesite novo vreme za: " + comboSchedule.SelectedItem?.ToString();
            SelectedSchedule = (Schedule)comboSchedule.SelectedItem;
            CheckSelection();
            insertMode();
            drawTable();
        }

        private void CheckSelection()
        {
            bool check = true;
            if (comboSchedule.SelectedItem == null)
                check = false;
            deleteScheduleButton.IsEnabled = check;
            iconButton.IsEnabled = check;
            newTime.IsEnabled = check;
        }

        private void AddRow_Handler(object sender, RoutedEventArgs e)
        {
            if (validInput())
            {
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

        private void DeleteSchedule_Handler(object sender, RoutedEventArgs e)
        {
            ConfirmDialog cofirmDialog = new ConfirmDialog("Obriši raspored?");
            if ((bool)cofirmDialog.ShowDialog())
            {
                Schedules.Remove(SelectedSchedule);
                MainRepository.Schedules.Remove(SelectedSchedule);
                comboSchedule.SelectedItem = null;
                insertMode();
            } 
        }

        private void Create_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new CreateSchedule(frame);
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

        private void insertMode() 
        {
            editLabel.Content = "Unesite novo vreme za: " + comboSchedule.SelectedItem?.ToString();
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
            editLabel.Content = "Unesite izmenu za: " + comboSchedule.SelectedItem?.ToString();
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
            if (SelectedSchedule == null) return;
            foreach (string s in SelectedSchedule.Times)
            {
                RowDataSchedule r = new RowDataSchedule(s);
                Rows.Add(r);
            }
        }
    }
}