using Syncfusion.Linq;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace SyncfusionWpfApp1.gui
{
    public class RowDataLine
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public double Price { get; set; }

        public RowDataLine() { }
        public RowDataLine(int id, string stationName, double price)
        {
            this.Id = id;
            this.StationName = stationName;
            this.Price = price;
        }
    }


        public class RowDataTrain
        { 
            public string Name { get; set; }

            public RowDataTrain() { }
            public RowDataTrain( string trainName)
            {
                this.Name = trainName;
            }

        }

        public partial class EditTrainLine : Window
        {
        private Frame frame;
        public TrainLine TrainLine { get; set; }
        public ObservableCollection<TrainLine> TrainLines { get; set; }
        public ObservableCollection<RowDataLine> RowsTrainLine { get; set; }
        public ObservableCollection<RowDataTrain> RowsTrain { get; set; }
        public TrainLine CurrentTrainLine { get; set; }
        public EditTrainLine(int trainLineId, Frame f)
        {
            InitializeComponent();
            frame = f;
            DataContext = this;
            TrainLines = new ObservableCollection<TrainLine>(MainRepository.trainLines);
            CurrentTrainLine = TrainLines.FirstOrDefault(t => t.Id == trainLineId);
            RowsTrainLine = new ObservableCollection<RowDataLine>();
            RowsTrain = new ObservableCollection<RowDataTrain>();
            drawTableTrainLine();
            drawTableTrain();
        }
        private void Close_Handler(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }
        private void Schedule_Handler(object sender, RoutedEventArgs e)
        {
            this.Close();
            frame.Content = new ScheduleUpdateDelete(frame);
        }

        private void drawTableTrainLine()
        {
            RowsTrainLine.Clear();
            foreach (DictionaryEntry kvp in CurrentTrainLine.Map)
            {
                TrainStation t = (TrainStation)kvp.Key;
                TrainStationInfo info = (TrainStationInfo)kvp.Value;
                RowDataLine r = new RowDataLine(t.Id,t.Name, info.Price);
                RowsTrainLine.Add(r);
            }
            
        }
        private void drawTableTrain()
        {
            RowsTrain.Clear();
            foreach (Train t in CurrentTrainLine.Trains)
            {
                RowDataTrain r = new RowDataTrain(t.Name);
                RowsTrain.Add(r);
            }

        }


    }
}
