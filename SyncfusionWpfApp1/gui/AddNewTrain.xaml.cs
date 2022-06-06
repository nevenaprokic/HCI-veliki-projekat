using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace SyncfusionWpfApp1.gui
{
    public class RowDataNewTrain
    {
        public string Name { get; set; }

        public RowDataNewTrain() { }
        public RowDataNewTrain(string trainName)
        {
            this.Name = trainName;
        }

    }
    public partial class AddNewTrain : Window
    {
        public ObservableCollection<RowDataNewTrain> RowsNewTrain { get; set; }
        private List<string> trains = new List<string>();
        private EditTrainLine.trainDelegate trainEvent;

        public AddNewTrain(EditTrainLine.trainDelegate trainEvent)
        {
            InitializeComponent();
            DataContext = this;
            this.trainEvent = trainEvent;
            RowsNewTrain = new ObservableCollection<RowDataNewTrain>();
            drawTableTrain();

        }

        private void drawTableTrain()
        {
            RowsNewTrain.Clear();
            foreach (Train t in MainRepository.Trains)
            {
                if (!t.HasTrain)
                {
                    RowDataNewTrain r = new RowDataNewTrain(t.Name);
                    RowsNewTrain.Add(r);
                }
            }
        }
        private void AddTrain_Handler(object sender, RoutedEventArgs e)
        {
            int forRemove = dataGridTrain.SelectedIndex;
            RowDataNewTrain tr = dataGridTrain.SelectedItem as RowDataNewTrain;
            trains.Add(tr.Name);
            RowsNewTrain.RemoveAt(forRemove);
            foreach (Train train in MainRepository.Trains)
            {
                if (tr.Name.Equals(train.Name))
                {
                    train.HasTrain = true;
                }

            }

            drawTableTrain();
        }
        private void Save_Handler(object sender, RoutedEventArgs e)
        {
            List<Train> newTrains = new List<Train>();
            foreach(string tr in trains)
            {
                foreach (Train train in MainRepository.Trains)
                {
                    if (tr.Equals(train.Name))
                    {
                        newTrains.Add(train);
                    }

                }
            }
            trainEvent?.Invoke(newTrains);

            this.Close();
        }
        private void Cancel_Handler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
