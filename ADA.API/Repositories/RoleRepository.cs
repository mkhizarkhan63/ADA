using ADA.API.DBManager;
using ADA.API.IRepositories;
using ADAClassLibrary;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private readonly IDapper _dapper;
        private readonly TextInfo myTI;

        public RoleRepository(IDapper dapper)
        {
            myTI = new CultureInfo("en-US", false).TextInfo;
            _dapper = dapper;
        }

        public Role Add(Role obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Role", obj.RoleName == null ? "" : obj.RoleName, DbType.String, ParameterDirection.Input);
            parameters.Add("@Active", obj.Active, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@CreatedBy", obj.CreatedBy, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CreatedOn", obj.ModifiedOn, DbType.DateTime, ParameterDirection.Input);

            return _dapper.Insert<Role>(@"[dbo].[usp_AddRole]", parameters);
        }

        public int Delete(int id, int ModifiedBy, DateTime ModifiedOn)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", ModifiedBy, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedOn", ModifiedOn, DbType.DateTime, ParameterDirection.Input);
            return _dapper.Insert<int>(@"[dbo].[usp_DeleteRole]", parameters);
        }
        public int DeleteRecord(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            return _dapper.Insert<int>(@"[dbo].[usp_DeleteRecordRole]", parameters);
        }
        public List<Role> GetAll()
        {
            DynamicParameters parameters = new DynamicParameters();
            return _dapper.GetAll<Role>(@"[dbo].[usp_GetAllRole]", parameters);




        }

        public Role GetRoleById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            return _dapper.Get<Role>(@"[dbo].[usp_GetRoleById]", parameters);
        }

        public Role Update(Role obj)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", obj.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Role", obj.RoleName == null ? "" : obj.RoleName, DbType.String, ParameterDirection.Input);
            parameters.Add("@Active", obj.Active, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", obj.CreatedBy, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedOn", obj.ModifiedOn, DbType.DateTime, ParameterDirection.Input);
            return _dapper.Insert<Role>(@"[dbo].[usp_UpdateRole]", parameters);



        }
    }
}
