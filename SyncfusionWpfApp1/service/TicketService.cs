using SyncfusionWpfApp1.dto;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.service
{
    public class TicketService
    {
        public static List<Ticket> getCurrentClientTickets()
        {
            string username = MainRepository.CurrentUser;
            IEnumerable<Ticket> clientTickets = from ticket in MainRepository.Tickets
                                                where ticket.Client.Email == username
                                                select ticket;
            return clientTickets.ToList();
        }

        public static List<Ticket> filterTickets(List<Ticket> clientTickets, TrainStation startStation, TrainStation endStation, double maxPrice, bool bought, bool allCategories)
        {
            string startStationName = "";
            string endStationName = "";
            if (startStation != null)
            {
                startStationName = startStation.Name;
            }
            if (endStation != null)
            {
                endStationName = endStation.Name;
            }

            IEnumerable<Ticket> tickets = from ticket in clientTickets
                                          where ticket.From.Name.Contains(startStationName)
                                          && ticket.To.Name.Contains(endStationName)
                                          && ticket.Price <= maxPrice
                                          select ticket;
            if (!allCategories) {
                tickets = from ticket in tickets
                          where ticket.bought == bought
                          select ticket;
            }
            return tickets.ToList();
        }

        public static List<Ticket> sortTicketsByDate(List<Ticket> tickets)
        {
            tickets.Sort((x, y) => y.DepartureTime.CompareTo(x.DepartureTime));
            return tickets;
        }

        public static List<Ticket> sortTicketsByPrice(List<Ticket> tickets)
        {
            tickets.Sort((x, y) => y.Price.CompareTo(x.Price));
            return tickets;
        }

        public static int getNextId()
        {
            MainRepository.Tickets.Sort((x, y) => y.Id.CompareTo(x.Id));
            return MainRepository.Tickets.First().Id;
        }

         public static TrainStation getStartStation(DirectionItem direction)
        {
            OrderedDictionary dictionary = direction.allStations.First();
            IDictionaryEnumerator myEnumerator = dictionary.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                return (TrainStation)myEnumerator.Key;
            }
            return null;
        }

        public static bool checkTickectsExpire(List<Ticket> tickets)
        {
            foreach(Ticket t in tickets)
            {
                if(!t.bought && ((t.DepartureTime - DateTime.Now <= TimeSpan.FromHours(48)) && !(t.DepartureTime - DateTime.Now <= TimeSpan.FromHours(24))))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
