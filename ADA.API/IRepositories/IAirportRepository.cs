using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IRepositories
{
   public interface IAirportRepository
    {

        Airport Add(Airport obj);
        Airport Update(Airport obj);
        int GetById(int id);
        int Delete(int id, int ModifiedBy, DateTime ModifiedOn);
        List<Airport> GetALL();

    }
}
