using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IServices
{
    public interface IStaffService : IService<Staff>
    {
        Staff AddStaff(Staff staff);
    }
}
