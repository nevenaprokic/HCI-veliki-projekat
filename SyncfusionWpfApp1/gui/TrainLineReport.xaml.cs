using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.service;
using System;
using System.Collections.Generic;
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
using SyncfusionWpfApp1.repo;

namespace SyncfusionWpfApp1.gui
{

    public partial class TrainLineReport : Page
    {
        private Frame frame;
        //public ReportService reportService = new ReportService();
        public List<TrainStation> trainStations { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<string> stationsNames { get; set; }
        public int ticketsCounter = 0;
        public double totalCost = 0;

        public TrainLineReport(Frame f)
        {
            DataContext = this;
            trainStations = MainRepository.trainStations;
            generateStationsNames();
            InitializeComponent();
            frame = f;
            comboEnd.SelectedIndex = 1;
            comboStart.SelectedIndex = 0;
            GenerateReport();
        }

        //private void StartStationChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ComboBox cmb = sender as ComboBox;
        //    startStation = (TrainStation)cmb.SelectedItem;
        //}

        //private void EndStationChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ComboBox cmb = sender as ComboBox;
        //    endStation = (TrainStation)cmb.SelectedItem;
        //}
        private void GenerateClicked(object sender, RoutedEventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            Tickets = ReportService.GenerateReport((TrainStation)comboStart.SelectedItem, (TrainStation)comboEnd.SelectedItem);
            drawTable();
            ticketsCounter = Tickets.Count;
            totalCost = CalculateTotalPrice();
            numberTextblock.Text = string.Format("Ukupno je prodato {0} karata", ticketsCounter);
            totalTextblock.Text = string.Format("Ukupna dobit je {0}", totalCost);

        }

        private double CalculateTotalPrice()
        {
            double total = 0;
            foreach(Ticket t in Tickets)
            {
                total += t.Price;
            }
            return total;
        }

        private void drawTable()
        {
            dataGrid?.Items.Clear();
            foreach (Ticket t in Tickets)
            {
                RowData rowData = makeRow(t);
                dataGrid?.Items.Add(rowData);
            }
        }

        private RowData makeRow(Ticket t)
        {
            return new RowData($"{t.Client.FirstName} {t.Client.LastName}", $"{t.Line.Start.Street}, {t.Line.Start.City} - {t.Line.End.Street}, {t.Line.End.City}", $"{t.From.Street}, {t.From.City} - {t.To.Street}, {t.To.City}", t.DepartureTime, $"{t.Price} din.", t.ReturnTicket);
        }

        private void generateStationsNames()
        {
            stationsNames = new List<string>();
            foreach (TrainStation station in trainStations)
            {
                String name = station.City + ", " + station.Street + " " + station.Number + ", " + station.Country;
                stationsNames.Add(name);
            }
        }

        private void DetailView_Handler(object sender, RoutedEventArgs e)
        {
            int toShow = dataGrid.SelectedIndex;
            TicketDetailsDialog dialog = new TicketDetailsDialog(Tickets[toShow]);
            if ((bool)dialog.ShowDialog())
                return;
        }


    }
}
