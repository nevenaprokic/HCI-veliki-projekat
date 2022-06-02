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
    
    public partial class TrainLineView : Page
    {
        private Frame frame;
        public TrainLine TrainLine { get; set; }
        public ObservableCollection<TrainLine> TrainLines { get; set; }
        public ObservableCollection<RowDataTrainLine> Rows { get; set; }

        public TrainLineView(Frame f)
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
            

        }
        private void drawTable()
        {
            Rows.Clear();
            foreach (TrainLine t in TrainLines)
            {
                string trains = "";
                foreach (Train train in t.Trains)
                {
                    trains += train.Name + ", ";
                }
                RowDataTrainLine r = new RowDataTrainLine(t.Id, t.Start.Name, t.End.Name, trains.Substring(0, trains.Length - 2), t.Price);
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
        private void TicketCreate_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new CardReservation();
        }
        private void TicketReprt_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void Schedule_Handler(object sender, RoutedEventArgs e) { }
        private void NetworkTrainLine_Handler(object sender, RoutedEventArgs e) { }
        private void TrainLine_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TrainLineView(frame);
        }
    }
}
