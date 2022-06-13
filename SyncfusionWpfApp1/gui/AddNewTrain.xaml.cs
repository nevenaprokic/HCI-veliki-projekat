using SyncfusionWpfApp1.help;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
        private void playVideoHandler(object sender, RoutedEventArgs e)
        {
            MediaElement m = new MediaElement(@"../../../videos/dodavanjeVoza.mp4");
            m.ShowDialog();
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
        public void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Button b = null;
            var windows = Application.Current.Windows;
            foreach (var window in windows)
            {
                IEnumerable<Button> buttons = FindVisualChilds<Button>((DependencyObject)window);
                if (buttons != null)
                {
                    foreach (var button in buttons)
                    {
                        if (button.Name.Equals("helpButton"))
                        {
                            b = button;
                        }
                    }
                }
            }
            string path = HelpProvider.GetHelpKey((DependencyObject)b);
            HelpProvider.ShowHelp(path, this);
        }
        public IEnumerable<T> FindVisualChilds<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChilds<T>(ithChild)) yield return childOfChild;
            }
        }
    }
}
