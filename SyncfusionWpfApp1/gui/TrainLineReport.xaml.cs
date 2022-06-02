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
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
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
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_ticket.Visibility = Visibility.Collapsed;
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
                tt_ticket.Visibility = Visibility.Visible;
                tt_schedule.Visibility = Visibility.Visible;
                tt_trainLine.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_trainLineReport.Visibility = Visibility.Visible;
                tt_train.Visibility = Visibility.Visible;
                tt_report_monthly.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
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

    }
}
