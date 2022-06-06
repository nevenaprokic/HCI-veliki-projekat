using SyncfusionWpfApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.dto
{
    public class TrainLineDirectionItem
    {
        public TrainStation Station { get; set; }
        public double PriceToNextStation { get; set; }

        public int TimeToNextStation { get; set; }

        public TrainLineDirectionItem(TrainStation station, double priceToNextStation, int timeToNextStation)
        {
            Station = station;
            PriceToNextStation = priceToNextStation;
            TimeToNextStation = timeToNextStation;
        }
    }
}
