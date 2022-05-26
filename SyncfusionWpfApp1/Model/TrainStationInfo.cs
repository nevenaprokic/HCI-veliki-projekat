namespace SyncfusionWpfApp1.Model
{
    public class TrainStationInfo
    {
        public TrainStationInfo() { }

        public TrainStationInfo(int minutes, double price)
        {
            FromDeparture = minutes;
            Price = price;
        }

        public TrainStationInfo(string arrivalTime, double price)
        {
            DepartureTime = arrivalTime;
            Price = price;
        }

        public string DepartureTime { get; set; }
        public int FromDeparture { get; set; }
        public double Price { get; set; }
    }
}