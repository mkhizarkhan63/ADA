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
    public class UsersRepositery:IUsersRepositery
    {



        private readonly IDapper _dapper;




        public UsersRepositery(IDapper dapper)
        {
 

            _dapper = dapper;
        }

        public Users Add(Users obj)
        {


            string RoleIds = String.Join(',', obj.RoleId);
            DynamicParameters parameters = new DynamicParameters();



            parameters.Add("@EmpNum", obj.EmpNum == null ? "" : obj.EmpNum, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffName", obj.StaffName == null ? "" : obj.StaffName, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffSurname", obj.StaffSurname == null ? "" : obj.StaffSurname, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffPwd", obj.StaffPwd == null ? "" : obj.StaffPwd, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffActive", obj.StaffActive, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@StaffRights", obj.StaffRights, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@SuperAdminRights", obj.SuperAdminRights, DbType.Boolean, ParameterDirection.Input);
            //parameters.Add("@RoleIds", RoleIds, DbType.String, ParameterDirection.Input);

           

            var data = _dapper.Insert<UsersPOCO>(@"[dbo].[usp_AddUsers]", parameters);


            Users Users = new Users();
            if (data != null)
            {
                Users = data;
              
                Users.RoleId = new List<int>();
                if (!String.IsNullOrEmpty(data.RoleIdText))
                {
                    Users.RoleId = data.RoleIdText.Split(',').Select(x => int.Parse(x.Trim())).ToList();
                }
            }

            return Users;
        }


        public int Delete(int id, int ModifiedBy, DateTime ModifiedOn)
        {
            ModifiedBy = 0;
            ModifiedOn = DateTime.Now;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", ModifiedBy, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedOn", ModifiedOn, DbType.DateTime, ParameterDirection.Input);
            return _dapper.Insert<int>(@"[dbo].[usp_UserChangeStatus]", parameters);
        }
        public int DeleteRecord(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            return _dapper.Insert<int>(@"[dbo].[usp_DeleteRecordUsers]", parameters);
        }
        public List<Users> GetAll()
        {
            DynamicParameters parameters = new DynamicParameters();
            var data = _dapper.GetAll<Users>(@"[dbo].[usp_GetALLStaff]", parameters);

            //List<Users> list = new List<Users>();


            //if (data != null && data.Count > 0)
            //{
            //    for (int i = 0; i < data.Count; i++)
            //    {
            //        Users Users = new Users();
            //        Users = data[i];

                   
            //        Users.RoleId = new List<int>();
            //        if (!String.IsNullOrEmpty(data[i].RoleIdText))
            //        {
            //            Users.RoleId = data[i].RoleIdText.Split(',').Select(x => int.Parse(x.Trim())).ToList();
            //        }
            //        list.Add(Users);
            //    }
            //}
            return data;
        }



        public Users GetUsersById(int id)
        {
            throw new NotImplementedException();
        }



        public Users Update(Users obj)
        {

           // string RoleIds = String.Join(',', obj.RoleId);

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@StaffID", obj.StaffID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@EmpNum", obj.EmpNum == null ? "" : obj.EmpNum, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffName", obj.StaffName == null ? "" : obj.StaffName, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffSurname", obj.StaffSurname == null ? "" : obj.StaffSurname, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffPwd", obj.StaffPwd == null ? "" : obj.StaffPwd, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffGrp", obj.StaffGrp == null ? "" : obj.StaffGrp, DbType.String, ParameterDirection.Input);
            parameters.Add("@StaffActive", obj.StaffActive, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@StaffRights", obj.StaffRights, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@SuperAdminRights", obj.SuperAdminRights, DbType.Boolean, ParameterDirection.Input);

            var data = _dapper.Insert<Users>(@"usp_UpdateUsers", parameters);


            //Users Users = new Users();
            //if (data != null)
            //{
            //    Users = data;
                
              
            //    Users.RoleId = new List<int>();
            //    if (!String.IsNullOrEmpty(data.RoleIdText))
            //    {
            //        Users.RoleId = data.RoleIdText.Split(',').Select(x => int.Parse(x.Trim())).ToList();
            //    }
            //}

            return data;
        }

    }
}
