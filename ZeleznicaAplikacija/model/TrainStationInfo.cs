namespace ZeleznicaAplikacija.model
{
    public class TrainStationInfo
    {
        public TrainStationInfo() { }

        public TrainStationInfo(string arrivalTime, double price)
        {
            DepartureTime = arrivalTime;
            Price = price;
        }

        public string DepartureTime { get; set; }
        public double Price { get; set; }
    }
}