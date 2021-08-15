using ADA.API.IRepositories;
using ADA.API.IServices;
using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Services
{
    public class StaffService : IStaffService
    {

        private readonly IStaffRepositery _staffRepository;

        public StaffService(IStaffRepositery staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public Staff AddStaff(Staff staff)
        {
            return _staffRepository.Add(staff);
        }

        public List<Staff> GetAll()
        {
            return _staffRepository.GetAll();
        }
    }
}
