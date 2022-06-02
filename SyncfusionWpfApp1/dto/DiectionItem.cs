using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyncfusionWpfApp1.Model;

namespace SyncfusionWpfApp1.dto
{
    public class DirectionItem
    {
        public TrainLine line { get; set; }
        public TrainStation startStation {get; set;}
        public TrainStation endStation { get; set; }
        public int travelDuration { get; set; }

        public DirectionItem parentStation { get; set; }

        public List<TrainStation> allStations { get; set; }
        public double price { get; set; }

        public DirectionItem(TrainLine line, TrainStation startStation, TrainStation endStation, int travelDuration, double price)
        {
            this.line = line;
            this.startStation = startStation;
            this.endStation = endStation;
            this.travelDuration = travelDuration;
            this.price = price;
        }

        public DirectionItem(TrainLine line, TrainStation startStation, TrainStation endStation)
        {
            this.line = line;
            this.startStation = startStation;
            this.endStation = endStation;
            
        }

        public DirectionItem()
        {
        }
    }
}
