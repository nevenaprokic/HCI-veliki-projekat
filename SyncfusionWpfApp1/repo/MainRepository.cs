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
using SyncfusionWpfApp1.service;

namespace SyncfusionWpfApp1.repo
{
    public class MainRepository
    {
        public static List<Ticket> Tickets { get; set; }
        public static List<User> Clients { get; set; }
        public static List<User> Managers { get; set; }
        public static List<User> Users { get; set; }
        public static List<Schedule> Schedules { get; set; }
        public static List<Wagon> Wagons { get; set; }
        public static List<Train> Trains { get; set; }

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

            Wagon w1 = new Wagon(1, 12, WagonClass.FIRST, 1);
            Wagon w2 = new Wagon(2, 15, WagonClass.SECOND, 2);
            Wagon w3 = new Wagon(3, 20, WagonClass.SECOND, 1);
            Wagon w4 = new Wagon(4, 24, WagonClass.FIRST, 3);
            Wagon w5 = new Wagon(5, 27, WagonClass.FIRST, 4);

            // wagon1 seats
            seats = new List<Seat>();
            for (int i = 0; i < w1.NumberOfSeats; i++) seats.Add(new Seat(w1, i + 1));

            // wagon2 seats
            for (int i = 0; i < w2.NumberOfSeats; i++) seats.Add(new Seat(w2, i + 1));

            // wagon3 seats
            for (int i = 0; i < w3.NumberOfSeats; i++) seats.Add(new Seat(w3, i + 1));

            // wagon4 seats
            for (int i = 0; i < w4.NumberOfSeats; i++) seats.Add(new Seat(w4, i + 1));

            // wagon5 seats
            for (int i = 0; i < w5.NumberOfSeats; i++) seats.Add(new Seat(w5, i + 1));

            //trains
            List<Train> trains = new List<Train>();
            Train t1 = new Train("5432 Soko", new List<Wagon> { w1, w2, w4, w5 });
            Train t2 = new Train("5000 Voz Srbija", new List<Wagon> { w3 });

            Wagons = new List<Wagon> { w1, w2, w3, w4, w5 };

            //trains
            trains.Add(t1);
            trains.Add(t2);
            Trains = new List<Train> { t1, t2 };

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
            TrainStation ts17 = new TrainStation("Željeznicka Stanica Bar", 46, "Crna Gora", "Bar", 17);

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
            //Dictionary<TrainStation, TrainStationInfo> dictTL34 = new Dictionary<TrainStation, TrainStationInfo>();
            OrderedDictionary dictTL1 = new OrderedDictionary
            {
                { ts2, info1 },
                { ts3, info2 },
                { ts4, info3 },
                { ts5, info4 }
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
                { ts12, info9 },
                { ts16, info10 }
               
            };
            TrainLine tl3 = new TrainLine(ts6, ts17, new List<Train> { t1, t2 }, schedule1, schedule2, 2000, dictTL3, 2);
            trainLines = new List<TrainLine> { tl1, tl2, tl3 };

            //tickets
            //User client, bool returnTicket, TrainLine line, DateTime departureTime, Seat seat, Seat returnSeat
            Ticket ticket1 = new Ticket(client1, false, tl1, new DateTime(2022, 06, 2, 11, 0, 0), seats[0], null, t1, ts1, ts6); // PODACI ZA FROM I TO ATRIBUTE SU STAVLJENI BEZ PROVERE DA LI IMAJU SMISLA
            Ticket ticket2 = new Ticket(client2, false, tl1, new DateTime(2022, 06, 2, 11, 0, 0), seats[10], null, t2, ts6, ts6);
            Ticket ticket3 = new Ticket(client1, false, tl1, new DateTime(2022, 06, 2, 11, 0, 0), seats[11], null, t1, ts1, ts6);
            Ticket ticket4 = new Ticket(client2, true, tl3, new DateTime(2022, 06, 2, 11, 0, 0), seats[20], seats[21], t2, ts1, ts6);
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

        public static int GetIndex(TrainStation station, TrainLine line)
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

        public static List<TrainRide> filterSelectedLines(TrainStation startStation, TrainStation endStation, DateTime startDateTime, bool backTicket)
        {
            IEnumerable<TrainLine> matchingLines = selectMatchingTrainLine(startStation, endStation);

            List<TrainRide> trainRides = new List<TrainRide>();
            
            foreach(TrainLine line in matchingLines)
            {
                foreach(Train train in line.Trains)
                {
                    List<Seat> awailableSeats = SeatService.getLineAwailableSeats(line, train, startStation, startDateTime);
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
                            if (backTicket) price = price * 1.5;
                            int travelDuration = calculateDepartureTime(line, startStation, endStation);
                            price = classPercent * price;

                            TrainRide ride = new TrainRide(startStation, endStation, line, train, wagonClass, startDateTime, travelDuration, price, backTicket);
                            trainRides.Add(ride);

                        }
                    }
                }
            }
            return trainRides;
        }

        public static double calculateRidePrice(TrainLine line, TrainStation startStation, TrainStation endStation)
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

        public static int calculateDepartureTime(TrainLine line, TrainStation startStation, TrainStation endStation)
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

        
    }


}
