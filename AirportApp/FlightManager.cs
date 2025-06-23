using System.Collections.Generic;

namespace AirportApp
{
    public class FlightManager
    {
        private List<Flight> flights;

        public FlightManager()
        {
            flights = new List<Flight>();
        }

        public void AddFlight(Flight flight)
        {
            flights.Add(flight);
        }

        public bool RemoveFlight(string flightNumber)
        {
            Flight flight = flights.Find(f => f.FlightNumber == flightNumber);
            if (flight != null)
            {
                flights.Remove(flight);
                return true;
            }
            return false;
        }

        public List<Flight> GetAllFlights()
        {
            return flights;
        }
    }
}