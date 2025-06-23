using System;

namespace AirportApp
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string PlaneName { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public decimal TicketPrice { get; set; }

        public Flight(string flightNumber, string planeName, string departure, string destination,
                     string departureTime, string arrivalTime, decimal ticketPrice)
        {
            FlightNumber = flightNumber;
            PlaneName = planeName;
            Departure = departure;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            TicketPrice = ticketPrice;
        }

        public override string ToString()
        {
            return $"Рейс: {FlightNumber}, Літак: {PlaneName}, Відправлення: {Departure} ({DepartureTime}), " +
                   $"Призначення: {Destination} ({ArrivalTime}), Ціна: {TicketPrice:C}";
        }
    }
}