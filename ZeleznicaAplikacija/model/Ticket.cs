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

        public Ticket(bool returnTicket, TrainLine line, DateTime departureTime, Seat seat, Seat returnSeat, Train train)
        {
            Train = train;
            ReturnTicket = returnTicket;
            Line = line;
            DepartureTime = departureTime;
            Seat = seat;
            ReturnSeat = returnSeat;
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
    }
}
