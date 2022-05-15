using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaAplikacija.model
{
    public class TrainStation
    {
        public TrainStation() { }

        public TrainStation(string street, int number, string country, string city)
        {
            Street = street;
            Number = number;
            Country = country;
            City = city;
        }

        public string Street { get; set; }
        public int Number { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
