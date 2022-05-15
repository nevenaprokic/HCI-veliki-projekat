using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaAplikacija.model
{
    public class Train
    {
        public Train() { }

        public Train(string name, List<Wagon> wagons)
        {
            Name = name;
            Wagons = wagons;
        }

        public string Name { get; set; }
        public List<Wagon> Wagons { get; set; }
    }
}
