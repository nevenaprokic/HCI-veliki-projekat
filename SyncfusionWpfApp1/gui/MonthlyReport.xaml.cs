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

    }
}
