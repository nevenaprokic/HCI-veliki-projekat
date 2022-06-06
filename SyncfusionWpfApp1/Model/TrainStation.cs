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

        public TrainStation(string street, string country, string city, int id)
        {
            Street = street;
            Country = country;
            City = city;
            Id = id;
            Name = City + ", " + Street + " " + ", " + Country;
        }

        public string Street { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string Name { get; set;  }
        public int Id { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            TrainStation ts = (TrainStation)obj;
            return Name.Equals(ts.Name);
        }
        public TrainStation DeepCopy()
        {
            TrainStation deepcopyTrainStation = new TrainStation(this.Street, this.Country, this.City, this.Id);
            return deepcopyTrainStation;
        }
    }
}
