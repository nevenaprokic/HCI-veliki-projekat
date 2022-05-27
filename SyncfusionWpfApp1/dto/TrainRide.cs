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

        public TrainRide(TrainStation startStation, TrainStation endStation, TrainLine line, Train train, WagonClass wagonClass, DateTime start, int travelDuration, double price)
        {
            this.startStation = startStation;
            this.endStation = endStation;
            this.line = line;
            this.train = train;
            this.wagonClass = wagonClass;
            this.start = start;
            this.travelDuration = travelDuration;
            this.price = price;
        }
    }
}
