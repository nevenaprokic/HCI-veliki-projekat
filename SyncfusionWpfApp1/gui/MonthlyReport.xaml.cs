using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.service;

namespace SyncfusionWpfApp1.gui
{
    public class RowData
    {
        public string ClientName { get; set; }
        public string TrainLine { get; set; }
        public string FromTo { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Price { get; set; }
        public bool Returning { get; set; }

        public RowData(string clientName, string trainLine, string fromTo, DateTime departureTime, string price, bool returning)
        {
            ClientName = clientName;
            TrainLine = trainLine;
            FromTo = fromTo;
            DepartureTime = departureTime;
            Price = price;
            Returning = returning;
        }
    }

    public class ChosenMonthPeriod
    {
        public string Start { get; set; }
        public string End { get; set; }
    }

    public partial class MonthlyReport : Page
    {
        private Frame frame;
        public int ticketsCounter = 0;
        public double totalCost = 0;

        public MonthlyReport(Frame f)
        {
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
            frame = f;
            
            drawTable();
        }

        private void SelectedMonth_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            drawTable();
        }

        private void drawTable()
        {
            List<Ticket> ticketsOfMonth = ReportService.TicketsForMonthlyReport(SelectedMonth.DisplayDate);
            SelectedMonth.DisplayMode = CalendarMode.Year;
            var firstDayOfMonth = new DateTime(SelectedMonth.DisplayDate.Year, SelectedMonth.DisplayDate.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            ticketsCounter = ticketsOfMonth.Count;
            numberTextblock.Text = string.Format("Ukupno je prodato {0} karata", ticketsCounter); totalCost = CalculateTotalPrice(ticketsOfMonth);
            totalTextblock.Text = string.Format("Ukupna dobit je {0}", totalCost);
            periodTextblock.Text = string.Format("Period: {0} - {1}", firstDayOfMonth.ToShortDateString(), lastDayOfMonth.ToShortDateString());

            dataGrid?.Items.Clear();
            foreach (Ticket t in ticketsOfMonth)
            {
                RowData rowData = makeRow(t);
                dataGrid?.Items.Add(rowData);
            }
            
        }

        private double CalculateTotalPrice(List<Ticket> tickets)
        {
            double total = 0;
            foreach (Ticket t in tickets)
            {
                total += t.Price;
            }
            return total;
        }

        private RowData makeRow(Ticket t)
        {
            return new RowData($"{t.Client.FirstName} {t.Client.LastName}", $"{t.Line.Start.Street} - {t.Line.End.Street}", $"{t.From.Street} - {t.To.Street}", t.DepartureTime, $"{t.Price} €", t.ReturnTicket);
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
