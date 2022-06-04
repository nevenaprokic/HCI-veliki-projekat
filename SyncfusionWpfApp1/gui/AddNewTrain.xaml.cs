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
using System.Windows.Shapes;

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
        public AddNewTrain()
        {
            InitializeComponent();
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
        private void Save_Handler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
