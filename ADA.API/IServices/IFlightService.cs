using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IServices
{
   public interface IFlightService : IService<Flight>
    {
        Flight Add(Flight obj);
        Flight Update(Flight obj);

        Flight GetFlightBtID(int id);

        object GetDropdownValues();


        object GetAircraftType(string type);
    }
}
