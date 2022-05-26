using SyncfusionWpfApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.dto
{
    public class TrainRide
    {
        public TrainStation startStation { get; set; }
        public TrainStation endStation { get; set; }
        public TrainLine line { get; set; }
        public Train train { get; set; }
        public WagonClass wagonClass { get; set;}
        public DateTime start { get; set; }
        public int travelDuration { get; set; }
        public double price { get; set; }

     }
}
