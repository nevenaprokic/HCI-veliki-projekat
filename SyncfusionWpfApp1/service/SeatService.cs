using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.service
{
    public class SeatService
    {
        public static Dictionary<Wagon, List<Seat>> wagonsAwailableSeats(TrainLine selectedLine, Train selectedTrain, TrainStation startStation, DateTime departureTime)
        {
            List<Seat> lineAwailableSeats = getLineAwailableSeats(selectedLine, selectedTrain, startStation, departureTime);
            Dictionary<Wagon, List<Seat>> waginsSeates = new Dictionary<Wagon, List<Seat>>();
            foreach(Wagon w in selectedTrain.Wagons)
            {
                List<Seat> awailableSeats = getWagonAwailableSeats(lineAwailableSeats, w);
                waginsSeates.Add(w, awailableSeats);
            }

            return waginsSeates;
        }

        public static List<Seat> getWagonAwailableSeats(List<Seat> lineAwailableSeats, Wagon wagon)
        {
            IEnumerable<Seat> wagonSeats = from seat in lineAwailableSeats
                                           where seat.Wagon.Id == wagon.Id
                                           select seat;
            return wagonSeats.ToList();
        }
    
        public static List<Seat> getLineAwailableSeats(TrainLine selectedLine, Train selectedTrain, TrainStation startStation, DateTime departureTime)
        {
            IEnumerable<Seat> allTrainSeats = from seat in MainRepository.seats
                                              where (selectedTrain.Wagons.Contains(seat.Wagon))
                                              select seat;

            IEnumerable<Ticket> lineTickets = from ticket in MainRepository.Tickets
                                              where (ticket.Line.Id == selectedLine.Id && allTrainSeats.Contains(ticket.Seat) && departureTime == ticket.DepartureTime)
                                              select ticket;

            IEnumerable<Seat> takenSeats = from ticket in lineTickets
                                           select ticket.Seat;

            IEnumerable<Seat> freeSeats = from seat in allTrainSeats
                                          where !takenSeats.Contains(seat)
                                          select seat;

            IEnumerable<Seat> laterFreeLineSeats = from ticket in lineTickets
                                                   where (!takenSeats.Contains(ticket.Seat) || (MainRepository.GetIndex(startStation, selectedLine) >= MainRepository.GetIndex(ticket.To, selectedLine)))
                                                   select ticket.Seat;

            IEnumerable<Seat> allAwailableSeats = freeSeats.Concat(laterFreeLineSeats);
            return allAwailableSeats.ToList();
        }

        public static List<Seat> allWagonSeats(Wagon w)
        {
            IEnumerable<Seat> wagonSeats = from seat in MainRepository.seats
                                           where seat.Wagon.Id == w.Id
                                           select seat;
            return wagonSeats.ToList();
        }
    }

}
