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
    public class AirportRepository : IAirportRepository
    {
        private readonly IDapper _dapper;

        public AirportRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public Airport Add(Airport obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"DestICAO", obj.DestICAO , DbType.String , ParameterDirection.Input );
            parameters.Add(@"DestIATA", obj.DestIATA , DbType.String , ParameterDirection.Input);
            parameters.Add(@"DestName", obj.DestName , DbType.String , ParameterDirection.Input);
            parameters.Add(@"HomeBase", obj.HomeBase , DbType.Boolean , ParameterDirection.Input);
            parameters.Add(@"OilField", obj.OilField, DbType.Boolean, ParameterDirection.Input);
            parameters.Add(@"DestActive", obj.DestActive, DbType.Boolean, ParameterDirection.Input);
            return _dapper.Insert<Airport>(@"" , parameters);
        }

        public int Delete(int id, int ModifiedBy, DateTime ModifiedOn)
        {
            throw new NotImplementedException();
        }

        public List<Airport> GetALL()
        {
            DynamicParameters parameters = new DynamicParameters();
            return _dapper.GetAll<Airport>(@"" , parameters);
        }

        public int GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Airport Update(Airport obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"DestID", obj.DestID, DbType.Int32, ParameterDirection.Input);
            parameters.Add(@"DestICAO", obj.DestICAO, DbType.String, ParameterDirection.Input);
            parameters.Add(@"DestIATA", obj.DestIATA, DbType.String, ParameterDirection.Input);
            parameters.Add(@"DestName", obj.DestName, DbType.String, ParameterDirection.Input);
            parameters.Add(@"HomeBase", obj.HomeBase, DbType.Boolean, ParameterDirection.Input);
            parameters.Add(@"OilField", obj.OilField, DbType.Boolean, ParameterDirection.Input);
            parameters.Add(@"DestActive", obj.DestActive, DbType.Boolean, ParameterDirection.Input);
            return _dapper.Update<Airport>(@"", parameters);
        }
    }
}
