using SyncfusionWpfApp1.dto;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.service
{
    public class NotDirectionRideService
    {
        public  List<DirectionItem> directions { get; set; }

        public NotDirectionRideService()
        {
            directions = new List<DirectionItem>();
        }

        public  List<List<TrainRide>> getNotDirectionsRide(TrainStation startStation, TrainStation endStation, DateTime startDateTime)
        {
           
            List<List<TrainRide>> rides = new List<List<TrainRide>>();
            List<DirectionItem> matchingDirections = new List<DirectionItem>();
            List<TrainLine> linesContainsStartStation = TrainLineService.getLinesWhichContainesStation(startStation);
            
            foreach(TrainLine line in linesContainsStartStation)
            {
                //Directions dir = new Directions();
                /*dir.allStations = new List<TrainStation>();
                dir.allStations.Add(startStation);
                dir.directionItems = new List<DirectionItem>();*/

                /* getDirections(line, startStation, endStation, dir);
                 if (dir.allStations.ElementAt(dir.allStations.Count - 1).Id == endStation.Id)
                 {
                     matchingDirections.Add(dir);
                 }*/

                DirectionItem dir = new DirectionItem(line, startStation, null, 0, 0);
                dir.parentStation = null;
                dir.allStations = new List<TrainStation>();
                dir.allStations.Add(startStation);
                findDirections(line, startStation, endStation, dir);
                
            }
            filterUniqueDirections();
            return rides;
        }

        private void filterUniqueDirections()
        {
            for (int i= 0; i<directions.Count; i++)
            {
                for (int j =0; j<directions.Count; j++)
                {
                    if(i != j)
                    {
                        if(compareDirectionItems(directions.ElementAt(i), directions.ElementAt(j)))
                        {
                            directions.RemoveAt(j);
                        }
                    }
                }
            }
        }

        private bool compareDirectionItems(DirectionItem first, DirectionItem second)
        {
            if (first.allStations.Count != second.allStations.Count) return false;

            for (int i= 0; i < first.allStations.Count; i++) 
            {
                if(first.allStations.ElementAt(i).Id != second.allStations.ElementAt(i).Id)
                {
                    return false;
                }
            }
            return true;
        }

        public void findDirections(TrainLine line, TrainStation station, TrainStation endStation, DirectionItem dir)
        {
            OrderedDictionary nextStattion = TrainLineService.getNextStation(line, station);

            if (nextStattion == null) return;

            IDictionaryEnumerator myEnumerator = nextStattion.GetEnumerator();
            TrainStation nextTrainStation = null;
            TrainStationInfo info;
            DirectionItem item = new DirectionItem();


            while (myEnumerator.MoveNext())
            {
                nextTrainStation = (TrainStation)myEnumerator.Key;
                dir.endStation = nextTrainStation;
                if (!dir.allStations.Contains(nextTrainStation))
                {
                    dir.allStations.Add(nextTrainStation);
                    info = (TrainStationInfo)myEnumerator.Value;
                    dir.price = dir.price + info.Price;
                    dir.travelDuration = dir.travelDuration + info.FromDeparture;

                    if (nextTrainStation.Id == endStation.Id)
                    {
                        directions.Add(dir);
                        return;
                    }

                    item.line = line;
                    item.startStation = nextTrainStation;
                    item.parentStation = dir;
                    generateParentStations(item);
                }

            }
           
            List<TrainLine> linesContainsStartStation = TrainLineService.getLinesWhichContainesStation(nextTrainStation);
            foreach (TrainLine trainLine in linesContainsStartStation)
            {
                findDirections(trainLine, nextTrainStation, endStation, item);
            }
            
           
        }

        private void generateParentStations(DirectionItem currentDir)
        {
            currentDir.allStations = new List<TrainStation>();
            if(currentDir.parentStation != null)
            {
                foreach (TrainStation station in currentDir.parentStation.allStations)
                {
                    if (!currentDir.allStations.Contains(station))
                    {
                        currentDir.allStations.Add(station);
                    }
                }
            }
        }
    }
}
