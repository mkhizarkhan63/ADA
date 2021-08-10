using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IServices
{
  public interface IAirCraftService : IService<Aircraft>
    {
        Aircraft Add(Aircraft obj);
        Aircraft Update(Aircraft obj);
        int GetById(int id);
        int Delete(int id, int ModifiedBy, DateTime ModifiedOn);
        
    }
}
