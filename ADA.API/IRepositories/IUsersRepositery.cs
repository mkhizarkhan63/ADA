using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IRepositories
{
   public interface IUsersRepositery
    {

        Users Add(Users obj);
        Users Update(Users obj);
        Users GetUsersById(int id);
        int Delete(int id, int ModifiedBy, DateTime ModifiedOn);
        int DeleteRecord(int id);
        List<Users> GetAll();
    }
}
