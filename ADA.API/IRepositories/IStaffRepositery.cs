using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IRepositories
{
   public interface IStaffRepositery
    {
        Staff Add(Staff staff);
        List<Staff> GetAll();
    }
}
