using SyncfusionWpfApp1.dto;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

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
            if(stationIndex == line.Map.Count + 1)
            {
                return null;
            }
            int counter = 1;
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

        public static List<TrainLineDTO> converLinesToDTO(List<TrainLine> lines)
        {
            IEnumerable<TrainLineDTO> trainLines = from line in lines
                                                   select new TrainLineDTO()
                                                   {
                                                       StartStation = line.Start,
                                                       EndStation = line.End,
                                                       OneWayPrice = calculateLinePrice(line).First(),
                                                       TwoWayPrice = calculateLinePrice(line).First() * 1.5,
                                                       TravelDurationMinutes = (int)calculateLinePrice(line).ElementAt(1),
                                                       TravelDurationStr = calculateTravelDuration((int)calculateLinePrice(line).ElementAt(1)),
                                                       WorkingDaySchedual = TrainLineDTO.generateSchedual(line.TimeSlots),
                                                       WeekendDaySchedual = TrainLineDTO.generateSchedual(line.TimeSlotsWeekend),
                                                       AllStations = getAllLineStations(line)
                                                   };
            return trainLines.ToList();
        }

        internal static List<TrainLine> filterTrainLinesByStations(TrainStation startStation, TrainStation endStation, TrainStation containedStation)
        {
            string startStationName = getStationName(startStation);
            string endStationName = getStationName(endStation);
            string containedStationName = getStationName(containedStation);

            IEnumerable<TrainLine> lines = from line in MainRepository.trainLines
                                           where line.Start.Name.Contains(startStationName)
                                                 && line.End.Name.Contains(endStationName)
                                           select line;
            List<TrainLine> filteredLines = new List<TrainLine>();
            foreach (TrainLine line in lines)
            {
                IDictionaryEnumerator myEnumerator = line.Map.GetEnumerator();
                while (myEnumerator.MoveNext())
                {
                    TrainStation station = (TrainStation)myEnumerator.Key;
                    if (station.Name.Contains(containedStationName) && !filteredLines.Contains(line))
                    {
                        filteredLines.Add(line);
                    }

                }
            }
            return filteredLines;
        }
            

        private static List<double> calculateLinePrice(TrainLine line)
        {
            double price = 0;
            double travelDuration = 0;
            IDictionaryEnumerator myEnumerator = line.Map.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                TrainStationInfo info = (TrainStationInfo)myEnumerator.Value;
                price += info.Price;
                travelDuration += info.FromDeparture;
            }
            List<double> lineInfo = new List<double>() { price, travelDuration };
            return lineInfo;
        }

        public static string calculateTravelDuration(int travelMiniutes)
        {
            double hours = travelMiniutes / 60;
            string[] hourTokens = hours.ToString().Split(".");
            double minutes = travelMiniutes - int.Parse(hourTokens[0]) * 60;
            string[] minutesTokens = minutes.ToString().Split(".");
            return hourTokens[0] + "h " + minutesTokens[0] + "min";
        }

        public static List<TrainLineDirectionItem> getAllLineStations(TrainLine line)
        {
            List<TrainLineDirectionItem> stations = new List<TrainLineDirectionItem>();
            IDictionaryEnumerator myEnumerator = line.Map.GetEnumerator();
            TrainLineDirectionItem startItem = new TrainLineDirectionItem(line.Start, 0, 0);
            stations.Add(startItem);
            while (myEnumerator.MoveNext())
            {
                TrainStation station = (TrainStation)myEnumerator.Key;
                TrainStationInfo info = (TrainStationInfo)myEnumerator.Value;
                TrainLineDirectionItem item = new TrainLineDirectionItem(station, info.Price, info.FromDeparture);
                stations.Add(item);

            }
            
            return stations.ToList();
        }

        public static string getStationName(TrainStation station)
        {
            if (station == null) return "";
            return station.Name;
        } 

    }


    
}
