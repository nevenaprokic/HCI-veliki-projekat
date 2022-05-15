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

        public Wagon(int numberOfSeats, WagonClass @class)
        {
            NumberOfSeats = numberOfSeats;
            Class = @class;
        }

        public int NumberOfSeats { get; set; }
        public Train Train { get; set; }
        public WagonClass Class { get; set; }
    }
}