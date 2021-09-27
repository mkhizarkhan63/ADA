using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IServices
{
   public interface IRoleService: IService<Role>
    {
        Role Add(Role obj);
        Role Update(Role obj);
        int Delete(int id, int ModifiedBy, DateTime ModifiedOn);
        int DeleteRecord(int id);
        Role GetRoleById(int id);
      
    }
}
