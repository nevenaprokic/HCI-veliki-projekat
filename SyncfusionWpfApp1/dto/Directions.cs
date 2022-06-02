using SyncfusionWpfApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.dto
{
    public class Directions
    {
        public List<DirectionItem> directionItems { get; set; }
        public int travelDuration { get; set; }
        public double oneWayPrice { get; set; }
        public double returnPrice { get; set; }
        public List<TrainStation> allStations { get; set; }


    }
}
