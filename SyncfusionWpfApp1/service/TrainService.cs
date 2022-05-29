using SyncfusionWpfApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.service
{
    public class TrainService
    {
        public static List<Train> getTrainsForLines(List<TrainLine> lines)
        {
            List<Train> trains = new List<Train>();
            foreach(TrainLine line in lines)
            {
                foreach(Train t in line.Trains)
                {
                    if (!trains.Contains(t)) trains.Add(t);
                }
            }
            return trains;
        }
    }
}
