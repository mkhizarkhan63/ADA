using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IServices
{
   public interface IFlightService : IService<Flight>
    {
        Flight AddFlight(Flight flight);
        Flight UpdateFlight(Flight flight);

        Flight GetFlightBtID(int id);

        object GetDropdownValues();
    }
}
