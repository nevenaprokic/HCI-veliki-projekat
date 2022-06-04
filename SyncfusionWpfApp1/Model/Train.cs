using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.Model
{
    public class Train
    {
        public Train() { }

        public Train(string name, List<Wagon> wagons)
        {
            Name = name;
            Wagons = wagons;
            HasTrain = false;
        }
        public Train(string name, List<Wagon> wagons, bool hasTrain)
        {
            Name = name;
            Wagons = wagons;
            HasTrain = hasTrain;
        }

        public string Name { get; set; }
        public List<Wagon> Wagons { get; set; }
        public bool HasTrain { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
