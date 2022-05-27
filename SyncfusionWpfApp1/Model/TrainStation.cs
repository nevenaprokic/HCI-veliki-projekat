using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.Model
{
    public class TrainStation
    {
        public TrainStation() { }

        public TrainStation(string street, int number, string country, string city, int id)
        {
            Street = street;
            Number = number;
            Country = country;
            City = city;
            Id = id;
            Name = City + ", " + Street + " " + Number + ", " + Country;
        }

        public string Street { get; set; }
        public int Number { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string Name { get; set;  }
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            TrainStation ts = (TrainStation)obj;
            return Name.Equals(ts.Name);
        }
    }
}
