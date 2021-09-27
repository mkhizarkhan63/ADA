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
        public Flight Add(Flight obj)
        {
     
            return _flightRepository.Add(obj);
        }

        public List<Flight> GetAll()
        {
            return _flightRepository.GetAll();
        }

        public object GetDropdownValues()
        {
            return _flightRepository.GetFlightsDropDown();
        }
        public object GetAircraftType(string type)
        {
            return _flightRepository.GetAircraftType(type);
        }

        public Flight GetFlightBtID(int id)
        {
            return _flightRepository.GetByID(id);
        }


        public Flight Update(Flight obj)
        {
            
            return _flightRepository.Update(obj);
        }
}
}
