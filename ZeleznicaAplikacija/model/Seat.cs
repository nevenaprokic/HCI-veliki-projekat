using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaAplikacija.model
{
    public class Seat
    {
        public Seat() { }

        public Seat(Wagon wagon, int seatNumber)
        {
            Wagon = wagon;
            SeatNumber = seatNumber;
        }

        public Wagon Wagon { get; set; }
        public int SeatNumber { get; set; }
    }
}
