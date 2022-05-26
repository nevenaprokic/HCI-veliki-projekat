using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace SyncfusionWpfApp1.Model
{
    public class TrainLine
    {
        public TrainLine() { }

        public TrainLine(TrainStation start, TrainStation end, List<Train> trains, List<string> timeSlots, List<string> timeSlotsWeekend, double price, OrderedDictionary map, int id)
        {
            Start = start;
            End = end;
            Trains = trains;
            TimeSlots = timeSlots;
            TimeSlotsWeekend = timeSlotsWeekend;
            Price = price;
            Map = map;
            Id = id;
        }

        public TrainStation Start { get; set; }
        public TrainStation End { get; set; }
        public List<Train> Trains { get; set; }
        public List<string> TimeSlots { get; set; }
        public List<string> TimeSlotsWeekend { get; set; }
        public double Price { get; set; }
        public OrderedDictionary Map { get; set; }

        public int Id { get; set; }


        
    }
}
