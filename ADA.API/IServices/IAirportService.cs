using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IServices
{
   public interface IAirportService : IService<Airport>
    {
        Airport Add(Airport obj);
        Airport Update(Airport obj);
        int GetById(int id);
        int Delete(int id, int ModifiedBy, DateTime ModifiedOn);
       
    }
}
