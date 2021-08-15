using ADA.API.IRepositories;
using ADAClassLibrary;
using Dapper;
using ADA.API.DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Repositories
{
    public class AirCraftRepository : IAirCraftRepository
    {

        private readonly IDapper _dapper;

        public AirCraftRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public Aircraft Add(Aircraft obj)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@ACReg", obj.ACReg, DbType.String, ParameterDirection.Input);
            parameters.Add("@ACType", obj.ACType, DbType.String, ParameterDirection.Input);
            parameters.Add("@ACCapacity", obj.ACCapacity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ACRows", obj.ACRows, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@MaleWt", obj.MaleWt, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FemaleWt", obj.FemaleWt, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ChildWt", obj.ChildWt, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@InfantWt", obj.InfantWt, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@MaxInfantQty", obj.MaxInfantQty, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ColumnLabel", obj.ColumnLabel, DbType.String, ParameterDirection.Input);
            parameters.Add("@ExitRows", obj.ExitRows, DbType.String, ParameterDirection.Input);
            parameters.Add("@RFFS", obj.RFFS, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row1", obj.Row1, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row2", obj.Row2, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row3", obj.Row3, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row4", obj.Row4, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row5", obj.Row5, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row6", obj.Row6, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row7", obj.Row7, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row8", obj.Row8, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row9", obj.Row9, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row10", obj.Row10, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row11", obj.Row11, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row12", obj.Row12, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row13", obj.Row13, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row14", obj.Row14, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row15", obj.Row15, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row16", obj.Row16, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row17", obj.Row17, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row18", obj.Row18, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row19", obj.Row19, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row20", obj.Row20, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row21", obj.Row21, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row22", obj.Row22, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row23", obj.Row23, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row24", obj.Row24, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row25", obj.Row25, DbType.String, ParameterDirection.Input);
            parameters.Add("@FWDCargoHold", obj.FWDCargoHold, DbType.Double, ParameterDirection.Input);
            parameters.Add("@AftCargoHold", obj.AftCargoHold, DbType.Double, ParameterDirection.Input);
            parameters.Add("@ACActive", obj.ACActive, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargoWT", obj.FwdCargoWT, DbType.String, ParameterDirection.Input);
            parameters.Add("@AftCargoWT", obj.AftCargoWT, DbType.String, ParameterDirection.Input);

            return _dapper.Insert<Aircraft>(@"[dbo].[usp_insertAircraft]", parameters);
        }

        public int Delete(int id, int ModifiedBy, DateTime ModifiedOn)
        {
            throw new NotImplementedException();
        }

        public List<Aircraft> GetALL()
        {
            DynamicParameters parameters = new DynamicParameters();
            return _dapper.GetAll<Aircraft>(@"[dbo].[usp_getAircrafts]", parameters);
        }

        public int GetById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@AircraftID", id, DbType.Int32, ParameterDirection.Input);
            return _dapper.Get<int>(@"[dbo].[usp_getAircraftByID]", parameters);
        }

        public Aircraft Update(Aircraft obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@AircraftID", obj.AircraftID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ACReg", obj.ACReg, DbType.String, ParameterDirection.Input);
            parameters.Add("@ACType", obj.ACType, DbType.String, ParameterDirection.Input);
            parameters.Add("@ACCapacity", obj.ACCapacity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ACRows", obj.ACRows, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@MaleWt", obj.MaleWt, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FemaleWt", obj.FemaleWt, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ChildWt", obj.ChildWt, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@InfantWt", obj.InfantWt, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@MaxInfantQty", obj.MaxInfantQty, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ColumnLabel", obj.ColumnLabel, DbType.String, ParameterDirection.Input);
            parameters.Add("@ExitRows", obj.ExitRows, DbType.String, ParameterDirection.Input);
            parameters.Add("@RFFS", obj.RFFS, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row1", obj.Row1, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row2", obj.Row2, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row3", obj.Row3, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row4", obj.Row4, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row5", obj.Row5, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row6", obj.Row6, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row7", obj.Row7, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row8", obj.Row8, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row9", obj.Row9, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row10", obj.Row10, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row11", obj.Row11, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row12", obj.Row12, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row13", obj.Row13, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row14", obj.Row14, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row15", obj.Row15, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row16", obj.Row16, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row17", obj.Row17, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row18", obj.Row18, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row19", obj.Row19, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row20", obj.Row20, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row21", obj.Row21, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row22", obj.Row22, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row23", obj.Row23, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row24", obj.Row24, DbType.String, ParameterDirection.Input);
            parameters.Add("@Row25", obj.Row25, DbType.String, ParameterDirection.Input);
            parameters.Add("@FWDCargoHold", obj.FWDCargoHold, DbType.Double, ParameterDirection.Input);
            parameters.Add("@AftCargoHold", obj.AftCargoHold, DbType.Double, ParameterDirection.Input);
            parameters.Add("@ACActive", obj.ACActive, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargoWT", obj.FwdCargoWT, DbType.String, ParameterDirection.Input);
            parameters.Add("@AftCargoWT", obj.AftCargoWT, DbType.String, ParameterDirection.Input);

            return _dapper.Update<Aircraft>(@"[dbo].[usp_updateAircraft]", parameters);
        }
    }
}
