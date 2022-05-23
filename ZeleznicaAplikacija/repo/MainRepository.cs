using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaAplikacija.model;
using System.Collections.Specialized;

namespace ZeleznicaAplikacija.repo
{
    public class MainRepository
    {
        public static List<Ticket> Tickets { get; set; }
        public static List<User> Clients { get; set; }
        public static List<User> Managers { get; set; }
        public static List<User> Users { get; set; }

        public static string CurrentUser;


        static MainRepository()
        {
            User client1 = new User("pera@gmail.com", "sifra", "Petar", "Peric", UserType.CLIENT, "063/9879-010", new DateTime(2000, 11, 29));
            User client2 = new User("mile@gmail.com", "sifra", "Mile", "Subotic", UserType.CLIENT, "064/1119-510", new DateTime(1998, 07, 10));
            User manager1 = new User("a", "a", "Ksenija", "Maric", UserType.MANAGER, "063/9559-343", new DateTime(1996, 03, 08));
            User manager2 = new User("vanja@gmail.com", "sifra", "Vanja", "Jovanovic", UserType.MANAGER, "065/9319-366", new DateTime(1996, 05, 15));

            Clients = new List<User> { client1, client2 };
            Managers = new List<User> { manager1, manager2 };
            Users = new List<User> { client1, client2, manager1, manager2};

            Wagon w1 = new Wagon(1, 12, WagonClass.FIRST);
            Wagon w2 = new Wagon(2, 15, WagonClass.SECOND);
            Wagon w3 = new Wagon(3, 20, WagonClass.SECOND);
            List<Wagon> wagons = new List<Wagon> { w1, w2, w3 };

            // wagon1 seats
            List<Seat> seats = new List<Seat>();
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
            TrainStation ts1 = new TrainStation("Bulevar Jase Tomica", 4, "Srbija", "Novi Sad");
            TrainStation ts2 = new TrainStation("Franje Stefanovica", 7, "Srbija", "Novi Sad");
            TrainStation ts3 = new TrainStation("Dunavska", 1, "Srbija", "Novi Sad");
            TrainStation ts4 = new TrainStation("Zeleznicka", 9, "Srbija", "Indjija");
            TrainStation ts5 = new TrainStation("Zeleznicka", 4, "Srbija", "Stara Pazova");
            TrainStation ts6 = new TrainStation("Savski trg", 2, "Srbija", "Beograd");

            TrainStation ts7 = new TrainStation("Knez Milosev venac", 1, "Srbija", "Pozarevac");
            TrainStation ts8 = new TrainStation("Omladinska", 3, "Srbija", "Smederevo");
            TrainStation ts9 = new TrainStation("Brace Badzak", 16, "Srbija", "Mladenovac");


            TrainStation ts10 = new TrainStation("Aleksandra Vojinovića", 78, "Srbija", "Resnik");
            TrainStation ts11 = new TrainStation("Patrijarha Dimitrija", 7, "Srbija", "Rakovica");
            TrainStation ts12 = new TrainStation("Zeleznicka", 10, "Srbija", "Lazarevac");
            TrainStation ts13 = new TrainStation("Avalska", 40, "Srbija", "Relja");
            TrainStation ts14 = new TrainStation("Zeleznicka bb", 8, "Srbija", "Ripanj");
            TrainStation ts15 = new TrainStation("Put za Kolarusu", 7, "Srbija", "Ripanj-tunel");
            TrainStation ts16 = new TrainStation("Veliki Crljeni", 148, "Srbija", "Stepojevac");
            TrainStation ts17 = new TrainStation("Zeleznica stanice Bar", 1, "Srbija", "Bar");

            List<TrainStation> trainStations = new List<TrainStation> { ts1, ts2, ts3, ts4, ts5, ts6,
                ts7, ts8, ts9, ts10, ts11, ts12, ts13, ts14, ts15, ts16};

            //time slots
            List<String> schedule1 = new List<string> { "5:19", "6:11", "6:49", "8:10", "9:00", "10:00", "10:30", "11:00", "11:30", "12:00", "13:00", "13:30",
                "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "19:00", "19:30", "20:00", "20:45", "21:30", "22:30"};
            List<String> schedule2 = new List<string> { "6:49", "8:10", "9:00", "10:00", "11:00", "11:30", "13:00", "13:30",
                "14:00", "15:30", "16:00", "16:30", "17:30", "18:00", "19:30", "20:00", "21:30", "22:30"};

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
            TrainLine tl1 = new TrainLine(ts1, ts6, new List<Train>{ t1 }, schedule1, schedule2, 300, dictTL1);

            // trainline2
            TrainStationInfo info6 = new TrainStationInfo(20, 100);
            TrainStationInfo info7 = new TrainStationInfo(20, 200);
            OrderedDictionary dictTL2 = new OrderedDictionary
            {
                { ts8, info6 },
                { ts9, info7 }
            };
            TrainLine tl2 = new TrainLine(ts7, ts6, new List<Train> { t2 }, schedule1, schedule2, 300, dictTL2);

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
            TrainLine tl3 = new TrainLine(ts6, ts17, new List<Train> { t1, t2}, schedule1, schedule2, 2000, dictTL3);
            List<TrainLine> trainLines = new List<TrainLine> { tl1, tl2, tl3 };

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

    }
}
