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
using SyncfusionWpfApp1.repo;

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
        public ChosenMonthPeriod ChosenPeriod { get; set; }

        public MonthlyReport(Frame f)
        {
            ChosenPeriod = new ChosenMonthPeriod();
            InitializeComponent();
            frame = f;
            drawTable(MainRepository.Tickets);
            /*this.DataContext = this;*/
        }

        private void SelectedMonth_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {          
            List<Ticket> ticketsOfMonth = new List<Ticket>();
            foreach (Ticket t in MainRepository.Tickets)
            {
                if (t.DepartureTime.Month == SelectedMonth.DisplayDate.Month &&
                     t.DepartureTime.Year == SelectedMonth.DisplayDate.Year)
                    ticketsOfMonth.Add(t);
            }
            ChosenPeriod.Start = SelectedMonth.DisplayDate.ToShortDateString();
            ChosenPeriod.End = SelectedMonth.DisplayDate.ToShortDateString();
            SelectedMonth.DisplayMode = CalendarMode.Year;
            drawTable(ticketsOfMonth);
        }

        private void drawTable(List<Ticket> tickets)
        {
            dataGrid?.Items.Clear();
            foreach (Ticket t in tickets)
            {
                RowData rowData = makeRow(t);
                dataGrid?.Items.Add(rowData);
            }
            
        }

        private RowData makeRow(Ticket t)
        {
            return new RowData($"{t.Client.FirstName} {t.Client.LastName}", $"{t.Line.Start.Street} - {t.Line.End.Street}", $"{t.From.Street} - {t.To.Street}", t.DepartureTime, $"{t.Price} €", t.ReturnTicket);
        }

    }
}
