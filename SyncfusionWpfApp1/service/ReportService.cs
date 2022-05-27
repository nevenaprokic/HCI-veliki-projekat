using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.service
{
    public class ReportService
    {
        internal static List<Ticket> TicketsForMonthlyReport(DateTime displayDate)
        {
            List<Ticket> retList = new List<Ticket>();
            foreach (Ticket t in MainRepository.Tickets)
            {
                if (t.DepartureTime.Month == displayDate.Month &&
                     t.DepartureTime.Year == displayDate.Year)
                    retList.Add(t);
            }
            return retList;
        }

        internal static List<Ticket> GenerateReport(TrainStation selectedItem1, TrainStation selectedItem2)
        {
            List<Ticket> retList = new List<Ticket>();
            foreach (Ticket t in MainRepository.Tickets)
            {
                if (t.From.Equals(selectedItem1) && t.To.Equals(selectedItem2))
                {
                    retList.Add(t);
                }
            }
            return retList;
        }
    }
}
