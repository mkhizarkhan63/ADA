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
        int GetById(int id);
        int Delete(int id, int ModifiedBy, DateTime ModifiedOn);


    }
}
