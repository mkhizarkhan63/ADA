using ADA.API.IRepositories;
using ADA.API.IServices;
using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportRepository;

        public AirportService(IAirportRepository airportRepository )
        {
            _airportRepository = airportRepository;
        }
        public Airport Add(Airport obj)
        {
            return _airportRepository.Add(obj);
        }

        public int Delete(int id, int ModifiedBy, DateTime ModifiedOn)
        {
            throw new NotImplementedException();
        }

        public List<Airport> GetAll()
        {
            return _airportRepository.GetALL();
        }

        public int GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Airport Update(Airport obj)
        {
            return _airportRepository.Update(obj);
        }
    }
}
