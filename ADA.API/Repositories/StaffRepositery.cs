using ADA.API.DBManager;
using ADA.API.IRepositories;
using ADAClassLibrary;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Repositories
{
    public class StaffRepositery : IStaffRepositery
    {
        private readonly IDapper _dapper;
        public StaffRepositery(IDapper dapper)
        {
            _dapper = dapper;
        }
        public Staff Add(Staff staff)
        {
            DynamicParameters parameters = new DynamicParameters();

     
            parameters.Add("@EmpNum", staff.EmpNum, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffSurname", staff.StaffSurname, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffName", staff.StaffName, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffPwd", staff.StaffPwd, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffRights", staff.StaffRights, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@StaffActive", staff.StaffActive, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@StaffGrp", staff.StaffGrp, DbType.String, ParameterDirection.Input);

            return _dapper.Insert<Staff>(@"[dbo].[usp_AddStaff]", parameters);
        }

        public List<Staff> GetAll()
        {
            DynamicParameters parameters = new DynamicParameters();
            return _dapper.GetAll<Staff>(@"[dbo].[usp_GetAllStaff]", parameters);
        }
    }
}
