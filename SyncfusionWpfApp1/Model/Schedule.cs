using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.Model
{
    public class Schedule
    {
        public int Id { get; set; }
        public List<String> Times { get; set; }

        public Schedule(int id) { }

        public Schedule(int id, List<string> times)
        {
            Id = id;
            Times = times;
        }

        public override string ToString()
        {
            return string.Format("Raspored {0}", Id);
        }
    }
}
