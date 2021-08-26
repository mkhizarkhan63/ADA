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
            flight.FltTimeStamp = DateTime.Now;
            return _flightRepository.Add(flight);
        }

        public List<Flight> GetAll()
        {
            return _flightRepository.GetAll();
        }

        public object GetDropdownValues()
        {
            return _flightRepository.GetFlightsDropDown();
        }

        public Flight GetFlightBtID(int id)
        {
            return _flightRepository.GetByID(id);
        }

        public Flight UpdateFlight(Flight flight)
        {
            flight.FltTSEdit = DateTime.Now;

            if(flight.FltStatus_Fk == 3)
            {
                flight.ClosingTimeStamp = DateTime.Now;
            }
            return _flightRepository.Update(flight);
        }
    }
}
