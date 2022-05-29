using SyncfusionWpfApp1.dto;
using SyncfusionWpfApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.service
{
    public class TrainLineService
    {
         public static List<TrainRide> filterTrainRidesByTrain(List<TrainRide> rides, Train train)
        {
            IEnumerable<TrainRide> filterdRides = from ride in rides
                                                  where ride.train == train
                                                  select ride;
            return filterdRides.ToList();
        }

        public static List<TrainRide> filterTrainRidesByMaxPrice(List<TrainRide> rides, Double maxPrice)
        {
            IEnumerable<TrainRide> filterdRides = from ride in rides
                                                  where ride.price <= maxPrice
                                                  select ride;
            return filterdRides.ToList();
        }

    }
}
