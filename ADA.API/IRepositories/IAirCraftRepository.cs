using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IRepositories
{
   public interface IAirCraftRepository
    {
        Aircraft Add(Aircraft obj);
        Aircraft Update(Aircraft obj);
        int GetById(int id);
        int Delete(int id,int ModifiedBy,DateTime ModifiedOn);
       List<Aircraft> GetALL();




    }
}
