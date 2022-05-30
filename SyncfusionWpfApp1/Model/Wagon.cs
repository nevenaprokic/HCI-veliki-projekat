using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.Model
{
    public enum WagonClass
    {
        FIRST,
        SECOND
    }

    public class Wagon
    {
        public Wagon() { }

        public Wagon(int id, int numberOfSeats, WagonClass wagonClass, int orderdNum)
        {
            Id = id;
            NumberOfSeats = numberOfSeats;
            Class = wagonClass;
            OrderdNumber = orderdNum;
        }

        public int Id { get; set; }
        public int NumberOfSeats { get; set; }
        public Train Train { get; set; }
        public WagonClass Class { get; set; }

        public int OrderdNumber { get; set; }
    }
}