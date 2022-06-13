using SyncfusionWpfApp1.dto;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using SyncfusionWpfApp1.service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class RowDataTrainLine
    {
        public int Id { get; set; }
        public string StartStationName { get; set; }
        public string EndStationName { get; set; }
        public string Trains { get; set; }
        public double Price { get; set; }

        public RowDataTrainLine() { }
        public RowDataTrainLine(int id, string startStationName, string endStationName, string trainName, double price)
        {
            this.Id = id;
            this.StartStationName = startStationName;
            this.EndStationName = endStationName;
            this.Trains = trainName;
            this.Price = price;
        }

    }
    public partial class TrainLineCRUD : Page
    {
        private Frame frame;
        public TrainLine TrainLine { get; set; }
        public ObservableCollection<TrainLine> TrainLines { get; set; }
        public ObservableCollection<RowDataTrainLine> Rows { get; set; }
        public TrainLine currentTrainLine { get; set; }

        private string _selectedLineNames;
       
        public string SelectedLineNames
        {
            get { return _selectedLineNames; }
            set
            {
                if (_selectedLineNames != value)
                {
                    _selectedLineNames = value;
                    RaisePropertyChanged(nameof(SelectedLineNames));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        private void playVideoHandler(object sender, RoutedEventArgs e)
        {
            MediaElement m = new MediaElement(@"../../../videos/voznaLinijaCRUD.wmv");
            m.ShowDialog();
        }
        protected void RaisePropertyChanged(String propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public TrainLineCRUD(Frame f)
        {
            InitializeComponent();
            frame = f;
            initPage();
            TrainLines = new ObservableCollection<TrainLine>(MainRepository.trainLines);
            
            Rows = new ObservableCollection<RowDataTrainLine>();
            drawTable();


            DataContext = this;


        }

        private void initPage()
        {
            Uri iconUriMail = new Uri("../../../images/proba.png", UriKind.RelativeOrAbsolute);
            //logoIcon.Source = BitmapFrame.Create(iconUriMail);
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
            Uri iconUriDelete = new Uri("../../../images/delete.png", UriKind.RelativeOrAbsolute);
            iconDelete.Source = BitmapFrame.Create(iconUriDelete);
            Uri iconUriAdd = new Uri("../../../images/add1.png", UriKind.RelativeOrAbsolute);
            iconAdd.Source = BitmapFrame.Create(iconUriAdd);
            Uri iconUriEdit = new Uri("../../../images/edit.png", UriKind.RelativeOrAbsolute);
            
        }
        public void drawTable()
        {
            Rows.Clear();
            foreach (TrainLine t in TrainLines)
            {
                string trains = "   ";
                foreach (Train train in t.Trains)
                {
                    trains += train.Name + ", ";
                }
                RowDataTrainLine r = new RowDataTrainLine(t.Id, t.Start.Name, t.End.Name, trains.Substring(0, trains.Length - 2), t.Price);
                Rows?.Add(r);
            }
        }
        private void DeleteRow_Handler(object sender, RoutedEventArgs e)
        {
            int forRemove = dataGrid.SelectedIndex;
            RowDataTrainLine tl = dataGrid.SelectedItem as RowDataTrainLine;
            RowDataTrainLine t = dataGrid.SelectedItem as RowDataTrainLine;
            if (IsAbleToDelete(t.Id))
            {
                NotificationDialog n = new NotificationDialog("Voznu liniju nije moguće obrisati zbog budućih karata.");
                if ((bool)n.ShowDialog())
                {
                    return;
                }
            }
            MainRepository.trainLines.Remove(MainRepository.trainLines.FirstOrDefault(t => t.Id == tl.Id));
            TrainLines.RemoveAt(forRemove);
            drawTable();
        }
        private bool IsAbleToDelete(int id)
        {
            foreach (Ticket t in MainRepository.Tickets)
            {
                if (t.Line.Id == id && !Passed(t.DepartureTime))
                {
                    return false;
                }
            }
            return true;
        }

        private bool Passed(DateTime start)
        {
            return (start.Date - DateTime.Now.Date).TotalDays < 0;
        }
        private void EditRow_Handler(object sender, RoutedEventArgs e)
        {
            RowDataTrainLine t = dataGrid.SelectedItem as RowDataTrainLine;
            if (IsAbleToDelete(t.Id))
            {
                NotificationDialog n = new NotificationDialog("Voznu liniju nije moguće izmeniti zbog budućih karata.");
                if ((bool)n.ShowDialog())
                {
                    return;
                }
            }
            EditTrainLine line = new EditTrainLine(t.Id, frame, this);
            if ((bool)line.ShowDialog())
            {
                drawTable();
            }
                
        }
        private void DetailView_Handler(object sender, RoutedEventArgs e)
        {
            Button b = (Button)e.OriginalSource;
            RowDataTrainLine CurrentSelectedLine = (RowDataTrainLine)b.DataContext;
            currentTrainLine =  MainRepository.trainLines.FirstOrDefault(t => t.Id == CurrentSelectedLine.Id);
            Review r = new Review(currentTrainLine);
            r.Show();

        }
        
        private void AddNew_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new AddNewTrainLine(frame);
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
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                
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
                
                tt_schedule.Visibility = Visibility.Visible;
                tt_trainLine.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_trainLineReport.Visibility = Visibility.Visible;
                tt_train.Visibility = Visibility.Visible;
                tt_report_monthly.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
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

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            //Close();
        }
        private void Logout_Handler(object sender, RoutedEventArgs e)
        {

            frame.Content = new LoginPage(frame);
            frame.NavigationService.RemoveBackEntry();
        }

    }
}
