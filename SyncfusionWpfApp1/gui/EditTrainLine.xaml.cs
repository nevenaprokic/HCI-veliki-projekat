using Syncfusion.Linq;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using System.Windows.Shapes;
using static SyncfusionWpfApp1.gui.TrainLineCRUD;

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
        public bool IsClosed { get; private set; }
        private Frame frame;
        public TrainLine TrainLine { get; set; }
        public ObservableCollection<TrainLine> TrainLines { get; set; }
        public ObservableCollection<RowDataLine> RowsTrainLine { get; set; }
        public ObservableCollection<RowDataTrain> RowsTrain { get; set; }
        public TrainLine CurrentTrainLine { get; set; }
        public TrainLine CurrentTrainLineCopy { get; set; }
        public int Id;
        public delegate void someDelegate();
        //public event someDelegate someEvent;
        public delegate void trainDelegate(List<Train> trains);
        public static event trainDelegate trainEvent;
        public TrainLineCRUD Parent { get; set; }
        public EditTrainLine(int trainLineId, Frame f, TrainLineCRUD parent)
        {
            InitializeComponent();
            frame = f;
            Id = trainLineId;
            DataContext = this;
            IsClosed = false;
            Parent = parent;
            TrainLines = new ObservableCollection<TrainLine>(MainRepository.trainLines);
            CurrentTrainLine = TrainLines.FirstOrDefault(t => t.Id == trainLineId);
            CurrentTrainLineCopy = CurrentTrainLine.DeepCopy();
            RowsTrainLine = new ObservableCollection<RowDataLine>();
            RowsTrain = new ObservableCollection<RowDataTrain>();
            price.Text = CurrentTrainLine.Price.ToString();
            drawTableTrainLine();
            drawTableTrain();
        }
        private void Close_Handler(object sender, RoutedEventArgs e)
        {//treba sve izmene vratiti na pocetno stanje
            CurrentTrainLine = CurrentTrainLineCopy;
            this.Close();
        }
        private void Schedule_Handler(object sender, RoutedEventArgs e)
        {
            IsClosed = true;
            this.Close();
            frame.Content = new ScheduleUpdateDelete(frame);
        }

        public void drawTableTrainLine()
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
        private void AddNewTrainLine_Handler(object sender, RoutedEventArgs e)
        {
            AddNewLine line = new AddNewLine(CurrentTrainLine, this);
            line.Show();
        }
        private void DeleteTrainLine_Handler(object sender, RoutedEventArgs e)
        {
            int forRemove = dataGridTrainLine.SelectedIndex;
            RowDataLine tl = dataGridTrainLine.SelectedItem as RowDataLine;
            OrderedDictionary newDict = new OrderedDictionary();
            RowsTrainLine.RemoveAt(forRemove);
            IDictionaryEnumerator myEnumerator = CurrentTrainLine.Map.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                TrainStation t = (TrainStation)myEnumerator.Key;
                if (!tl.StationName.Equals(t.Name))
                {
                    newDict.Add(myEnumerator.Key, myEnumerator.Value);
                } 
            }
            CurrentTrainLine.Map.Clear();
            CurrentTrainLine.Map = newDict;  
            drawTableTrainLine();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void DeleteTrain_Handler(object sender, RoutedEventArgs e)
        {
            int forRemove = dataGridTrain.SelectedIndex;
            RowDataTrain tr = dataGridTrain.SelectedItem as RowDataTrain;
            
            RowsTrain.RemoveAt(forRemove);

            foreach (Train train in CurrentTrainLine.Trains.ToList())
            {
                if (tr.Name.Equals(train.Name))
                {
                    CurrentTrainLine.Trains.Remove(train);
                    train.HasTrain = false;
                }

            }
            drawTableTrainLine();

        }
        private void Save_Handler(object sender, RoutedEventArgs e)
        {
            CurrentTrainLine.Price = Convert.ToDouble(price.Text);
            IsClosed = true;
            someDelegate p = new someDelegate(Parent.drawTable);
            p.Invoke();
            this.Close();
        }
       
        private void AddTrain_Handler(object sender, RoutedEventArgs e)
        {
            trainEvent += AddNewTrain;
            AddNewTrain add = new AddNewTrain(trainEvent);
            add.Show();
        }
        public void AddNewTrain(List<Train> trains)
        {
            foreach(Train t in trains)
            {
                CurrentTrainLine.Trains.Add(t);
            }
            drawTableTrain();
        }


    }
}
