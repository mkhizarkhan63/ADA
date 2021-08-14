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
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
           _flightRepository = flightRepository;
        }
       
        public Flight Add(Flight obj)
        {
            return _flightRepository.Add(obj);
          
        }

        public int Delete(int id, int ModifiedBy, DateTime ModifiedOn)
        {
            throw new NotImplementedException();
        }

        public List<Flight> GetAll()
        {
            return _flightRepository.GetAllFlights();
        }

        public int GetById(int id)
        {
            return _flightRepository.GetByid(id);
        }

        public Flight Update(Flight obj)
        {
            return _flightRepository.update(obj);
        }
    }
}
