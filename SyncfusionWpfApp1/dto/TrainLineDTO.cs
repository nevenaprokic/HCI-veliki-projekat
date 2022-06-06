using SyncfusionWpfApp1.gui;
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.dto
{
    public class TrainLineDTO
    {
        public TrainStation StartStation { get; set; }
        public TrainStation EndStation { get; set; }
        public List<TrainLineDirectionItem> AllStations { get; set; }

        public double OneWayPrice { get; set; }
        public double TwoWayPrice { get; set; }
        public int TravelDurationMinutes { get; set; }
        public string TravelDurationStr { get; set; }
        public List<RowDataSchedule> WorkingDaySchedual { get; set; }
        public List<RowDataSchedule> WeekendDaySchedual { get; set; }

        public TrainLineDTO(TrainStation startStation, TrainStation endStation, List<TrainLineDirectionItem> allStations, double oneWayPrice, double twoWayPrice, int travelDurationMinutes,  List<string> workingDaySchedual, List<string> weekendDaySchedual)
        {
            this.StartStation = startStation;
            this.EndStation = endStation;
            this.AllStations = allStations;
            this.OneWayPrice = oneWayPrice;
            this.TwoWayPrice = twoWayPrice;
            this.TravelDurationMinutes = travelDurationMinutes;
            this.TravelDurationStr = TrainLineService.calculateTravelDuration(TravelDurationMinutes);
            this.WorkingDaySchedual = generateSchedual(workingDaySchedual);
            this.WeekendDaySchedual = generateSchedual(weekendDaySchedual);
        }

        public TrainLineDTO()
        {

        }

        public static List<RowDataSchedule> generateSchedual(List<string> data)
        {
            List<RowDataSchedule> schedual = new List<RowDataSchedule>();
            foreach(string time in data)
            {
                schedual.Add(new RowDataSchedule(time));
            }
            return schedual;
        }
    }
}
