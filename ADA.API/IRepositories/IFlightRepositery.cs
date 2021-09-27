using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IRepositories
{
   public interface IFlightRepositery
    {
        Flight Add(Flight obj);

        Flight Update(Flight obj);

        List<Flight> GetAll();
        Flight GetByID(int id);

        object GetFlightsDropDown();
        object GetAircraftType(string type);
    }
}
