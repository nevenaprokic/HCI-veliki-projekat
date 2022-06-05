﻿using SyncfusionWpfApp1.dto;
using SyncfusionWpfApp1.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.Model
{
    public class Ticket
    {
        public Ticket() { }

        public Ticket(User client, bool returnTicket, TrainLine line, DateTime departureTime, Seat seat, Seat returnSeat, Train train, TrainStation from, TrainStation to)
        {
            Train = train;
            ReturnTicket = returnTicket;
            Line = line;
            DepartureTime = departureTime;
            Seat = seat;
            ReturnSeat = returnSeat;
            Client = client;
            From = from;
            To = to;
            Class = Seat.Wagon.Class;
            WagonNumber = Seat.Wagon.OrderdNumber;
            ClassNumber = (int)Class + 1;
            
        }

        public Ticket(User client, TrainRide selectedRide, Seat seat)
        {
            Client = client;
            Train = selectedRide.train;
            ReturnTicket = selectedRide.backTicket;
            Line = selectedRide.line;
            DepartureTime = selectedRide.start;
            Seat = seat;
            Price = selectedRide.price;
            From = selectedRide.startStation;
            To = selectedRide.endStation;
            PriceStr = Price.ToString() + ",00 din";
            DepartureTimeStr = this.DepartureTime.ToString("dd.MM.yyyy HH:mm");
            ClassNumber = (int)Class + 1;
            this.ArrivalTime = selectedRide.start.AddMinutes(selectedRide.travelDuration);

        }

        public Ticket(User client, DirectionItem selectedRide, double price, DateTime startTime)
        {
            Client = client;
            //From = selectedRide.allStations.ElementAt(0);
            To = selectedRide.endStation;
            this.Price = price;
            this.DepartureTime = startTime;
            this.ReturnTicket = selectedRide.selectedReturnDirection;
            this.SelectedRide = selectedRide;
            PriceStr = price.ToString() + ",00 din";
            DepartureTimeStr = this.DepartureTime.ToString("dd.MM.yyyy HH:mm");
            ClassNumber = (int)Class + 1;
            this.ArrivalTime = selectedRide.ArrivalTime;
            this.From = TicketService.getStartStation(selectedRide);
        }

        public override string ToString()
        {
            return $"Ticket: {Train.Name}, returning: {ReturnTicket}, line: {Line.Start.Street} - {Line.End.Street}, departure time: {DepartureTime}, seat: {Seat.SeatNumber}.";
        }

        public Ticket(int id, User client, bool returnTicket, TrainLine line, DateTime departureTime, Seat seat, Seat returnSeat, Train train, TrainStation from, TrainStation to, double price, DateTime arrivalTime)
        {
            this.Id = id;
            Train = train;
            ReturnTicket = returnTicket;
            Line = line;
            DepartureTime = departureTime;
            Seat = seat;
            ReturnSeat = returnSeat;
            Client = client;
            From = from;
            To = to;
            Class = Seat.Wagon.Class;
            ClassNumber = (int)Class + 1;
            WagonNumber = Seat.Wagon.OrderdNumber;
            Price = price;
            PriceStr = price.ToString() + ",00 din";
            DepartureTimeStr = this.DepartureTime.ToString("dd.MM.yyyy HH:mm");
            this.ArrivalTime = arrivalTime;
        }

        public int Id { get; set; }
        public Train Train { get; set; }
        public Boolean ReturnTicket { get; set; }
        public TrainLine Line { get; set; }
        public DateTime DepartureTime { get; set; }
        public Seat Seat { get; set; }
        public Seat ReturnSeat { get; set; }
        public User Client { get; set; }
        public TrainStation From { get; set; }
        public TrainStation To { get; set; }
        public WagonClass Class { get; set; }
        public int WagonNumber { get; set; }

        private double _price;
        public string PriceStr { get; set; }
        public string DepartureTimeStr { get; set; }

        public int ClassNumber { get; set; }

        public DateTime ArrivalTime { get; set; }

        public bool bought { get; set; }

        //koristi se kad ima presedanja
        public DirectionItem SelectedRide { get; set; }
        public bool IndirectRide { get; set; }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }

    }
}
