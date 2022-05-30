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
    public class RowDataTrainLine
    {
        public int Id { get; set; }
        public string StartStationName { get; set; }
        public string EndStationName { get; set; }
        //public List<string> TrainsName { get; set; }
        public double Price { get; set; }

        public RowDataTrainLine() { }
        public RowDataTrainLine(int id, string startStationName, string endStationName, double price)
        {
            this.Id = id;
            this.StartStationName = startStationName;
            this.EndStationName = endStationName;
            //this.TrainsName = trainName;
            this.Price = price;
        }

    }
    public partial class TrainLineCRUD : Page
    {
        private Frame frame;
        public TrainLine TrainLine { get; set; }
        public ObservableCollection<TrainLine> TrainLines { get; set; }
        public ObservableCollection<RowDataTrainLine> Rows { get; set; }

        public TrainLineCRUD(Frame f)
        {
            InitializeComponent();
            frame = f;
            initPage();
            TrainLines = new ObservableCollection<TrainLine>(MainRepository.trainLines);
            DataContext = this;
            Rows = new ObservableCollection<RowDataTrainLine>();
            drawTable();


        }

        private void initPage()
        {
            Uri iconUriMail = new Uri("../../../images/proba.png", UriKind.RelativeOrAbsolute);
            logoIcon.Source = BitmapFrame.Create(iconUriMail);
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
            Uri iconUriDelete = new Uri("../../../images/delete.png", UriKind.RelativeOrAbsolute);
            iconDelete.Source = BitmapFrame.Create(iconUriDelete);
            Uri iconUriAdd = new Uri("../../../images/add1.png", UriKind.RelativeOrAbsolute);
            iconAdd.Source = BitmapFrame.Create(iconUriAdd);
            Uri iconUriEdit = new Uri("../../../images/edit.png", UriKind.RelativeOrAbsolute);
            
        }
        private void drawTable()
        {
            Rows.Clear();
            foreach(TrainLine t in TrainLines){
                List<string> trains = new();
                /*foreach(Train train in t.Trains){
                    trains.Add(train.Name);
                }*/
                RowDataTrainLine r = new RowDataTrainLine(t.Id, t.Start.Name, t.End.Name, t.Price);
                Rows.Add(r);
            }
        }
        private void DeleteRow_Handler(object sender, RoutedEventArgs e)
        {
            int forRemove = dataGrid.SelectedIndex;
            Console.WriteLine(forRemove);
            TrainLines.RemoveAt(forRemove);
            drawTable();
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

        }
        private void TrainLine_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TrainLineCRUD(frame);
        }
        private void Train_Handler(object sender, RoutedEventArgs e)
        {

        }

    }
}
