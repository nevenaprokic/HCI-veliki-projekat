using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using SyncfusionWpfApp1.Model;
using Syncfusion.Data.Extensions;
using SyncfusionWpfApp1.dto;
using System.Collections;

namespace SyncfusionWpfApp1.repo
{
    public class MainRepository
    {
        public static List<Ticket> Tickets { get; set; }
        public static List<User> Clients { get; set; }
        public static List<User> Managers { get; set; }
        public static List<User> Users { get; set; }
        public static List<Schedule> Schedules { get; set; }

        public static List<TrainStation> trainStations { get; set; }

        public static string CurrentUser;

        public static List<TrainLine> trainLines { get; set; }

        public static List<Seat> seats { get; set; }


        static MainRepository()
        {
            User client1 = new User("p", "p", "Petar", "Peric", UserType.CLIENT, "063/9879-010", new DateTime(2000, 11, 29));
            User client2 = new User("mile@gmail.com", "sifra", "Mile", "Subotic", UserType.CLIENT, "064/1119-510", new DateTime(1998, 07, 10));
            User manager1 = new User("a", "a", "Ksenija", "Maric", UserType.MANAGER, "063/9559-343", new DateTime(1996, 03, 08));
            User manager2 = new User("vanja@gmail.com", "sifra", "Vanja", "Jovanovic", UserType.MANAGER, "065/9319-366", new DateTime(1996, 05, 15));

            Clients = new List<User> { client1, client2 };
            Managers = new List<User> { manager1, manager2 };
            Users = new List<User> { client1, client2, manager1, manager2 };

            Wagon w1 = new Wagon(1, 12, WagonClass.FIRST);
            Wagon w2 = new Wagon(2, 15, WagonClass.SECOND);
            Wagon w3 = new Wagon(3, 20, WagonClass.SECOND);
            List<Wagon> wagons = new List<Wagon> { w1, w2, w3 };

            // wagon1 seats
            seats = new List<Seat>();
            for (int i = 0; i < w1.NumberOfSeats; i++) seats.Add(new Seat(w1, i + 1));

            // wagon2 seats
            for (int i = 0; i < w2.NumberOfSeats; i++) seats.Add(new Seat(w2, i + 1));

            // wagon3 seats
            for (int i = 0; i < w3.NumberOfSeats; i++) seats.Add(new Seat(w3, i + 1));

            //trains
            List<Train> trains = new List<Train>();
            Train t1 = new Train("5432", new List<Wagon> { w1, w2 });
            Train t2 = new Train("5432", new List<Wagon> { w3 });
            trains.Add(t1);
            trains.Add(t2);

            //train stations
            TrainStation ts1 = new TrainStation("Bulevar Jase Tomica", 4, "Srbija", "Novi Sad", 1);
            TrainStation ts2 = new TrainStation("Franje Stefanovica", 7, "Srbija", "Novi Sad", 2);
            TrainStation ts3 = new TrainStation("Dunavska", 1, "Srbija", "Novi Sad", 3);
            TrainStation ts4 = new TrainStation("Zeleznicka", 9, "Srbija", "Indjija", 4);
            TrainStation ts5 = new TrainStation("Zeleznicka", 4, "Srbija", "Stara Pazova", 5);
            TrainStation ts6 = new TrainStation("Savski trg", 2, "Srbija", "Beograd", 6);

            TrainStation ts7 = new TrainStation("Knez Milosev venac", 1, "Srbija", "Pozarevac", 7);
            TrainStation ts8 = new TrainStation("Omladinska", 3, "Srbija", "Smederevo", 8);
            TrainStation ts9 = new TrainStation("Brace Badzak", 16, "Srbija", "Mladenovac", 9);


            TrainStation ts10 = new TrainStation("Aleksandra Vojinovića", 78, "Srbija", "Resnik", 10);
            TrainStation ts11 = new TrainStation("Patrijarha Dimitrija", 7, "Srbija", "Rakovica", 11);
            TrainStation ts12 = new TrainStation("Zeleznicka", 10, "Srbija", "Lazarevac", 12);
            TrainStation ts13 = new TrainStation("Avalska", 40, "Srbija", "Relja", 13);
            TrainStation ts14 = new TrainStation("Zeleznicka bb", 8, "Srbija", "Ripanj", 14);
            TrainStation ts15 = new TrainStation("Put za Kolarusu", 7, "Srbija", "Ripanj-tunel", 15);
            TrainStation ts16 = new TrainStation("Veliki Crljeni", 148, "Srbija", "Stepojevac", 16);
            TrainStation ts17 = new TrainStation("Zeleznica stanice Bar", 1, "Srbija", "Bar", 17);

            trainStations = new List<TrainStation> { ts1, ts2, ts3, ts4, ts5, ts6,
                ts7, ts8, ts9, ts10, ts11, ts12, ts13, ts14, ts15, ts16};

            //time slots
            List<string> schedule1 = new List<string> { "5:19", "6:11", "6:49", "8:10", "9:00", "10:00", "10:30", "11:00", "11:30", "12:00", "13:00", "13:30",
                "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "19:00", "19:30", "20:00", "20:45", "21:30", "22:30"};
            List<string> schedule2 = new List<string> { "6:49", "8:10", "9:00", "10:00", "11:00", "11:30", "13:00", "13:30",
                "14:00", "15:30", "16:00", "16:30", "17:30", "18:00", "19:30", "20:00", "21:30", "22:30", "23:00"};
            List<string> schedule3 = new List<string> { "5:30", "6:11", "6:49", "8:10", "9:00", "10:00", "10:30", "11:00", "11:30", "12:00", "13:00", "13:30",
                "14:15", "14:30", "15:20", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "19:00", "19:30", "20:00", "20:45", "21:30", "22:30", "23:00"};

            Schedules = new List<Schedule> { new Schedule("1", schedule1), new Schedule("2", schedule2), new Schedule("3", schedule3) };

             //train station info
             TrainStationInfo info1 = new TrainStationInfo(10, 200);
            TrainStationInfo info2 = new TrainStationInfo(10, 200);
            TrainStationInfo info3 = new TrainStationInfo(10, 250);
            TrainStationInfo info4 = new TrainStationInfo(10, 250);
            TrainStationInfo info5 = new TrainStationInfo(10, 300);


            // trainline1
            OrderedDictionary dictTL1 = new OrderedDictionary
            {
                { ts2, info1 },
                { ts3, info2 },
                { ts4, info3 },
                { ts5, info4 },
                { ts6, info5 }
            };
            TrainLine tl1 = new TrainLine(ts1, ts6, new List<Train> { t1 }, schedule1, schedule2, 300, dictTL1, 0);

            // trainline2
            TrainStationInfo info6 = new TrainStationInfo(20, 100);
            TrainStationInfo info7 = new TrainStationInfo(20, 200);
            OrderedDictionary dictTL2 = new OrderedDictionary
            {
                { ts8, info6 },
                { ts9, info7 }
            };
            TrainLine tl2 = new TrainLine(ts7, ts6, new List<Train> { t2 }, schedule3, schedule2, 300, dictTL2, 1);

            // trainline3
            TrainStationInfo info8 = new TrainStationInfo(20, 200);
            TrainStationInfo info9 = new TrainStationInfo(20, 600);
            TrainStationInfo info10 = new TrainStationInfo(20, 1500);
            OrderedDictionary dictTL3 = new OrderedDictionary
            {
                { ts11, info8 },
                { ts16, info10 },
                { ts12, info9 }
            };
            TrainLine tl3 = new TrainLine(ts6, ts17, new List<Train> { t1, t2 }, schedule1, schedule2, 2000, dictTL3, 2);
            trainLines = new List<TrainLine> { tl1, tl2, tl3 };

            //tickets
            //User client, bool returnTicket, TrainLine line, DateTime departureTime, Seat seat, Seat returnSeat
            Ticket ticket1 = new Ticket(client1, false, tl1, new DateTime(2022, 05, 25), seats[0], null, t1, ts1, ts6); // PODACI ZA FROM I TO ATRIBUTE SU STAVLJENI BEZ PROVERE DA LI IMAJU SMISLA
            Ticket ticket2 = new Ticket(client2, false, tl2, new DateTime(2022, 05, 25), seats[20], null, t2, ts6, ts6);
            Ticket ticket3 = new Ticket(client1, false, tl3, new DateTime(2022, 05, 25), seats[30], null, t1, ts1, ts6);
            Ticket ticket4 = new Ticket(client2, true, tl3, new DateTime(2022, 05, 26), seats[20], seats[21], t2, ts1, ts6);
            Tickets = new List<Ticket>();
            Tickets.Add(ticket1);
            Tickets.Add(ticket2);
            Tickets.Add(ticket3);
            Tickets.Add(ticket4);

        }
        public static void setLoggedUser(string username)
        {
            CurrentUser = username;
        }

        public static List<TrainLine> selectMatchingTrainLine(TrainStation startStation, TrainStation endStation)
        {
            IEnumerable<TrainLine> lines = from line in trainLines
                                           where (line.Map.Contains(startStation) && line.Map.Contains(endStation) &&
                                           GetIndex(startStation, line) < GetIndex(endStation, line))
                                           select line;
            return lines.ToList();
        }

        private static int GetIndex(TrainStation station, TrainLine line)
        {
            int index = 0;
            foreach (TrainStation s in line.Map.Keys)
            {
                if (s.Id == station.Id)
                {

                    return index;
                }
                index++;

            }
            return -1;
        }

        public static List<String> getTimeList(List<TrainLine> lines, DateTime date)
        {
            List<String> times = new List<string>();
            foreach (TrainLine line in lines)
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    foreach (String startTime in line.TimeSlots)
                    {
                        if (!times.Contains(startTime)) {
                            times.Add(startTime);
                        }
                    }
                }
                else
                {
                    foreach (String startTime in line.TimeSlotsWeekend)
                    {
                        if (!times.Contains(startTime))
                        {
                            times.Add(startTime);
                        }
                    }

                }

            }

            return sortTime(times, date);
        }

        private static List<String> sortTime(List<String> times, DateTime selectedDate)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (String time in times)
            {
                // year, month, day, hour, minute, and second.
                string[] timeTokens = time.Split(":");
                DateTime date = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, int.Parse(timeTokens[0]), int.Parse(timeTokens[1]), 0);
                dates.Add(date);
            }
            dates.Sort((x, y) => x.CompareTo(y));

            List<String> sortedTimes = new List<string>();
            foreach (DateTime date in dates)
            {
                String time = date.TimeOfDay.ToString();
                sortedTimes.Add(time);
            }

            return sortedTimes;
        }

        public static List<TrainRide> filterSelectedLines(TrainStation startStation, TrainStation endStation, DateTime startDateTime, DateTime backDateTime)
        {
            IEnumerable<TrainLine> matchingLines = selectMatchingTrainLine(startStation, endStation);

            List<TrainRide> trainRides = new List<TrainRide>();
            
            foreach(TrainLine line in matchingLines)
            {
                foreach(Train train in line.Trains)
                {
                    List<Seat> awailableSeats = getLineAwailableSeats(line, train, startStation, startDateTime);
                    if (awailableSeats.Count > 0)
                    {
                        List<WagonClass> trainWagonClasses = getTrainWagonClasses(train);
                        foreach(WagonClass wagonClass in trainWagonClasses)
                        {
                            double classPercent = 1;
                            if (wagonClass.Equals(WagonClass.FIRST))
                            {
                                classPercent = 1.2;
                            }

                            double price = calculateRidePrice(line, startStation, endStation);
                            int travelDuration = calculateDepartureTime(line, startStation, endStation);
                            price = classPercent * price;

                            TrainRide ride = new TrainRide(startStation, endStation, line, train, wagonClass, startDateTime, travelDuration, price);
                            trainRides.Add(ride);

                        }
                    }
                }
            }
            return trainRides;
        }

        private static double calculateRidePrice(TrainLine line, TrainStation startStation, TrainStation endStation)
        {
            //gledati po vrednosti uz kljuc stanice u recniku, treba da se uzmu one stanice koje su izmedju, gledati po indeksu
            int index = 0;
            double price = 0;
            int startStationIndex = GetIndex(startStation, line);
            int endStationIndex = GetIndex(endStation, line);
            IDictionaryEnumerator myEnumerator = line.Map.GetEnumerator();
            while(myEnumerator.MoveNext())
            {
                if(index >= startStationIndex && index < endStationIndex)
                {
                    TrainStationInfo station = (TrainStationInfo) myEnumerator.Value;
                    price += station.Price;
                    
                }
                index++;
            }

            return price;
            
        }

        private static int calculateDepartureTime(TrainLine line, TrainStation startStation, TrainStation endStation)
        {
            //gledati po vrednosti uz kljuc stanice u recniku, treba da se uzmu one stanice koje su izmedju, gledati po indeksu
            int index = 0;
            int travelDuration = 0;
            int startStationIndex = GetIndex(startStation, line);
            int endStationIndex = GetIndex(endStation, line);
            IDictionaryEnumerator myEnumerator = line.Map.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                if (index >= startStationIndex && index < endStationIndex)
                {
                    TrainStationInfo station = (TrainStationInfo)myEnumerator.Value;
                    travelDuration += station.FromDeparture;

                }
                index++;
            }

            return travelDuration;

        }



        private static List<WagonClass> getTrainWagonClasses(Train train)
        {
            List<WagonClass> wagonClasses = new List<WagonClass>();
            foreach(Wagon w in train.Wagons)
            {
                if (!wagonClasses.Contains(w.Class))
                {
                    wagonClasses.Add(w.Class);
                }
            }
            return wagonClasses;
        }

        public static List<Seat> getLineAwailableSeats(TrainLine selectedLine, Train selectedTrain, TrainStation startStation, DateTime departureTime)
        {
            IEnumerable<Seat> allTrainSeats = from seat in seats
                                              where (selectedTrain.Wagons.Contains(seat.Wagon))
                                              select seat;

            IEnumerable<Ticket> lineTickets = from ticket in Tickets
                                              where (ticket.Line.Id == selectedLine.Id && allTrainSeats.Contains(ticket.Seat) && departureTime == ticket.DepartureTime)
                                              select ticket;

            IEnumerable<Seat> takenSeats = from ticket in lineTickets
                                           select ticket.Seat;

            IEnumerable<Seat> freeSeats = from seat in allTrainSeats
                                          where !takenSeats.Contains(seat)
                                          select seat;

            IEnumerable<Seat> laterFreeLineSeats = from ticket in lineTickets
                                              where (!takenSeats.Contains(ticket.Seat) || (GetIndex(startStation, selectedLine) >= GetIndex(ticket.To, selectedLine)))
                                              select ticket.Seat;

            IEnumerable<Seat> allAwailableSeats = freeSeats.Concat(laterFreeLineSeats);
            return allAwailableSeats.ToList();
        }
    }


}
