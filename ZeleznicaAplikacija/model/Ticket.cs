using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaAplikacija.model
{
    public class Ticket
    {
        public Ticket() { }

        public Ticket(User client, bool returnTicket, TrainLine line, DateTime departureTime, Seat seat, Seat returnSeat, Train train, TrainStation from, TrainStation to)
        {
            Train = train;
            ReturnTicket = returnTicket;
            Line = line;
            DepartureTime = departureTime;
            Seat = seat;
            ReturnSeat = returnSeat;
            Client = client;
            Price = calculatePrice();
            From = from;
            To = to;
        }

        public override string ToString()
        {
            return $"Ticket: {Train.Name}, returning: {ReturnTicket}, line: {Line.Start.Street} - {Line.End.Street}, departure time: {DepartureTime}, seat: {Seat.SeatNumber}.";
        }

        public Train Train { get; set; }
        public Boolean ReturnTicket { get; set; }
        public TrainLine Line { get; set; }
        public DateTime DepartureTime { get; set; }
        public Seat Seat { get; set; }
        public Seat ReturnSeat { get; set; }
        public User Client { get; set; }
        public TrainStation From { get; set; }
        public TrainStation To { get; set; }

        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }

        private double calculatePrice()
        {
            return 5;
        }
    }
}
