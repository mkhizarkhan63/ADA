using ADA.API.IRepositories;
using ADA.API.IServices;
using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepositery _flightRepository;

        public FlightService(IFlightRepositery flightRepository)
        {
            _flightRepository = flightRepository;
        }
        public Flight AddFlight(Flight flight)
        {
            return _flightRepository.Add(flight);
        }

        public List<Flight> GetAll()
        {
            return _flightRepository.GetAll();
        }

        public Flight UpdateFlight(Flight flight)
        {
            return _flightRepository.Update(flight);
        }
    }
}
