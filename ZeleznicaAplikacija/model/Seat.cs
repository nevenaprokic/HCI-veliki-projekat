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

        public Seat(int wagon, int seatNumber)
        {
            Wagon = wagon;
            SeatNumber = seatNumber;
        }

        public int Wagon { get; set; }
        public int SeatNumber { get; set; }
    }
}
