using SyncfusionWpfApp1.dto;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections;

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

        public static List<TrainLine> getLinesWhichContainesStation(TrainStation startStation)
        {
            IEnumerable<TrainLine> lines = from line in MainRepository.trainLines
                                           where (line.Map.Contains(startStation) 
                                                   || line.Start.Id == startStation.Id 
                                                   || line.End.Id == startStation.Id)
                                           select line;
      
            return lines.ToList();
        }

        public static List<TrainStation> getFollowingStations(TrainStation station, TrainLine line)
        {
            List<TrainStation> followingStations = new List<TrainStation>();
            int stationIndex = MainRepository.GetIndex(station, line);
            int counter = 0;
            IDictionaryEnumerator myEnumerator = line.Map.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                TrainStation info = (TrainStation)myEnumerator.Key;
                if(counter > stationIndex)
                {
                    followingStations.Add(info);
                }
                counter++;
            }
            return followingStations;
        }

        public static OrderedDictionary getNextStation(TrainLine line, TrainStation station)
        {
            int stationIndex = MainRepository.GetIndex(station, line);
            int counter = 0;
            IDictionaryEnumerator myEnumerator = line.Map.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                if (counter == stationIndex + 1)
                {
                    OrderedDictionary info = new OrderedDictionary
                    {
                        { myEnumerator.Key, myEnumerator.Value },
                       
                    };
                    return info;
                }
                counter++;
            }
            return null;
        }

        //funkcija koja pronalazi liniju u kojoj su prosledjene stanice susedne
        public static TrainLine findMatchingLine(TrainStation startStation, TrainStation endStation)
        {
            IEnumerable<TrainLine> matchingLines = MainRepository.selectMatchingTrainLine(startStation, endStation);
            foreach (TrainLine line in matchingLines)
            {
                if(MainRepository.GetIndex(endStation, line) - MainRepository.GetIndex(startStation, line) == 1)
                {
                    return line;
                }
            }
            return null;
        }

        public static List<TrainLine> combileListOfTrainLines(List<TrainLine> first, List<TrainLine> second)
        {
            foreach(TrainLine line in second)
            {
                if (!first.Contains(line))
                {
                    first.Add(line);
                }
            }
            return first;
        }
    }


    
}
