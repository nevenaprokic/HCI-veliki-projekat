using SyncfusionWpfApp1.dto;
using SyncfusionWpfApp1.help;
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
using System.Windows.Shapes;

namespace SyncfusionWpfApp1.gui
{
    /// <summary>
    /// Interaction logic for Review.xaml
    /// </summary>
    public partial class Review : Window
    {
        public ObservableCollection<RowDataSchedule> SelectedSchedual { get; set; }
        public TrainLine currentTrainLine { get; set; }
        private TrainLineDTO _selectedLine;
        private List<TrainLineDTO> _allLines { get; set; }
        public TrainLineDTO SelectedLine
        {
            get { return _selectedLine; }
            set
            {
                if (_selectedLine != value)
                {
                    _selectedLine = value;
                    RaisePropertyChanged(nameof(SelectedLine));
                }
            }
        }
        public List<TrainLineDTO> AllLines
        {
            get { return _allLines; }
            set
            {
                if (_allLines != value)
                {
                    _allLines = value;
                    RaisePropertyChanged(nameof(AllLines));

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

        protected void RaisePropertyChanged(String propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public Review(TrainLine CurrentTrainLine)
        {
            InitializeComponent();
            DataContext = this;
            currentTrainLine = CurrentTrainLine;

            AllLines = TrainLineService.converLinesToDTO(MainRepository.trainLines);
            SelectedLine = AllLines.First();
            SelectedSchedual = new ObservableCollection<RowDataSchedule>();
            List<TrainLineDirectionItem> trainStation = new List<TrainLineDirectionItem>();
            double time = 0.00;
            foreach (DictionaryEntry kvp in currentTrainLine.Map)
            {
                TrainStation t = (TrainStation)kvp.Key;
                TrainStationInfo info = (TrainStationInfo)kvp.Value;
                time += info.Price;
                trainStation.Add(new TrainLineDirectionItem(t, info.Price, info.FromDeparture));
            }
            SelectedLine = new TrainLineDTO(currentTrainLine.Start, currentTrainLine.End, trainStation, currentTrainLine.Price, currentTrainLine.Price * 2, (int)time, currentTrainLine.TimeSlots, currentTrainLine.TimeSlotsWeekend);
            drawTableSchedule(currentTrainLine.TimeSlots);

            nameLine.Content = SelectedLine.StartStation.Name + "  ---> " +
                                SelectedLine.EndStation.Name;
            scahedualSelector.SelectedIndex = 0;
        }
        private void drawTableSchedule(List<string> scheduleList)
        {
            SelectedSchedual.Clear();
            foreach (string s in scheduleList)
            {
                RowDataSchedule schedule = new RowDataSchedule(s);
                SelectedSchedual?.Add(schedule);
            }
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SchedualSelection_chancged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            ComboBoxItem selectedItem = (ComboBoxItem)box.SelectedItem;
            string selection = (string)selectedItem.Content;
            if (selection.Equals("Vikend"))
            {
                drawTableSchedule(currentTrainLine.TimeSlots);

            }
            else
            {
                drawTableSchedule(currentTrainLine.TimeSlotsWeekend);
            }
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
        private void playVideoHandler(object sender, RoutedEventArgs e)
        {
            MediaElement m = new MediaElement(@"../../../videos/voznaLinijaDetalji.wmv");
            m.ShowDialog();
        }

        

    }
}
