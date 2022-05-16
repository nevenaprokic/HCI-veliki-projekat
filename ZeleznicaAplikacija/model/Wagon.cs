using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaAplikacija.model
{
    public enum WagonClass
    {
        FIRST,
        SECOND
    }

    public class Wagon
    {
        public Wagon() { }

        public Wagon(int id, int numberOfSeats, WagonClass wagonClass)
        {
            Id = id;
            NumberOfSeats = numberOfSeats;
            Class = wagonClass;
        }

        private int Id { get; set; }
        public int NumberOfSeats { get; set; }
        public Train Train { get; set; }
        public WagonClass Class { get; set; }
    }
}