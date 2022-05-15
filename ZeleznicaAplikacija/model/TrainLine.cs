﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaAplikacija.model
{
    public class TrainLine
    {
        public TrainLine() { }

        public TrainLine(TrainStation start, TrainStation end, List<Train> trains, List<string> timeSlots, List<string> timeSlotsWeekend, double price, Dictionary<TrainStation, TrainStationInfo> map)
        {
            Start = start;
            End = end;
            Trains = trains;
            TimeSlots = timeSlots;
            TimeSlotsWeekend = timeSlotsWeekend;
            Price = price;
            Map = map;
        }

        public TrainStation Start { get; set; }
        public TrainStation End { get; set; }
        public List<Train> Trains { get; set; }
        public List<string> TimeSlots { get; set; }
        public List<string> TimeSlotsWeekend { get; set; }
        public double Price { get; set; }
        public Dictionary<TrainStation, TrainStationInfo> Map { get; set; }
    }
}
