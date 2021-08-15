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
    public class PilotRepositery : IPilotRepositery
    {
        private readonly IDapper _dapper;

        public PilotRepositery(IDapper dapper)
        {
            _dapper = dapper;
        }
        public Pilot AddPilot(Pilot pilot)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@PilotEmpNum", pilot.PilotEmpNum, DbType.String, ParameterDirection.Input);
            parameters.Add("@PilotSurname", pilot.PilotSurname, DbType.String, ParameterDirection.Input);
            parameters.Add("@PilotName", pilot.PilotName, DbType.String, ParameterDirection.Input);
            parameters.Add("@ACType", pilot.ACType, DbType.String, ParameterDirection.Input);
            parameters.Add("@PilotActive", pilot.PilotActive, DbType.Boolean, ParameterDirection.Input);

            return _dapper.Insert<Pilot>(@"[dbo].[usp_AddPilot]", parameters);
        }

        public List<Pilot> GetAll()
        {
            DynamicParameters parameters = new DynamicParameters();
            return _dapper.GetAll<Pilot>(@"[dbo].[usp_getPilots]", parameters);
        }

       
    }
}
