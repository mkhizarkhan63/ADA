using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IRepositories
{
   public interface IRoleRepository
    {

        Role Add(Role obj);
        Role Update(Role obj);
        int Delete(int id, int ModifiedBy, DateTime ModifiedOn);
        int DeleteRecord(int id);
        Role GetRoleById(int id);
        List<Role> GetAll();
    }
}
