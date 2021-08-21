using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADAClassLibrary;

namespace ADA.API.IRepositories
{
    public interface IFlightRepository
    {
        Flight Add(Flight obj);
        Flight update(Flight obj);
        int GetByid(int id);
        int Delete(int id, int ModifiedBy, DateTime ModifiedOn);
        List<Flight> GetAllFlights();

    }
}
