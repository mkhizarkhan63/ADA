using ADA.API.IRepositories;
using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ADA.API.DBManager;
using System.Data;

namespace ADA.API.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IDapper _dapper;

        public FlightRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public Flight Add(Flight obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@FltDateTime", obj.FltDateTime, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@FltNumber", obj.FltNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("@DestID", obj.DestID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DestID2", obj.DestID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltColor", obj.FltColor, DbType.String, ParameterDirection.Input);
            parameters.Add("@FltStatus", obj.FltStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("@FltRoute", obj.FltRoute, DbType.String, ParameterDirection.Input);
            parameters.Add("@PilotID1", obj.PilotID1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PilotID2", obj.PilotID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PilotID3", obj.PilotID3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID1", obj.FAID1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID2", obj.FAID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID3", obj.FAID3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID4", obj.FAID4, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CustID", obj.CustID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@RsrvdSeats", obj.RsrvdSeats, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@SeatMap", obj.SeatMap, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Payload", obj.Payload, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Fuel", obj.Fuel, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Temperature", obj.Temperature, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo1", obj.FwdCargo1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo2", obj.FwdCargo2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo3", obj.FwdCargo3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo4", obj.FwdCargo4, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo1", obj.AftCargo1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo2", obj.AftCargo2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo3", obj.AftCargo3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo4", obj.AftCargo4, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo5", obj.AftCargo5, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo6", obj.AftCargo6, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@GateNum", obj.GateNum, DbType.String, ParameterDirection.Input);
            parameters.Add("@FltTimeStamp", obj.FltTimeStamp, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@AgentID", obj.AgentID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ClosingAgentID", obj.ClosingAgentID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ClosingTimeStamp", obj.ClosingTimeStamp, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@ActualDepTime", obj.ActualDepTime, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltRemarks", obj.FltRemarks, DbType.String, ParameterDirection.Input);
            parameters.Add("@SplitGender", obj.SplitGender, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@SubManifestColor", obj.SubManifestColor, DbType.String, ParameterDirection.Input);
            parameters.Add("@ShowRCS", obj.ShowRCS, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltTSEdit", obj.FltTSEdit, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@FltTSEditAgentID", obj.FltTSEditAgentID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AircraftID", obj.AircraftID, DbType.Int32, ParameterDirection.Input);
            return _dapper.Insert<Flight>(@"", parameters);
        
        }

        public int Delete(int id, int ModifiedBy, DateTime ModifiedOn)
        {
            throw new NotImplementedException();
        }

        public List<Flight> GetAllFlights()
        {
            DynamicParameters parameters = new DynamicParameters();
            return _dapper.GetAll<Flight>(@"", parameters);
        }

        public int GetByid(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@FltID", id, DbType.Int32, ParameterDirection.Input);
            return _dapper.Get<int>(@"", parameters);
        }

        public Flight update(Flight obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@FltID", obj.FltID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltDateTime", obj.FltDateTime, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@FltNumber", obj.FltNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("@DestID", obj.DestID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DestID2", obj.DestID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltColor", obj.FltColor, DbType.String, ParameterDirection.Input);
            parameters.Add("@FltStatus", obj.FltStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("@FltRoute", obj.FltRoute, DbType.String, ParameterDirection.Input);
            parameters.Add("@PilotID1", obj.PilotID1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PilotID2", obj.PilotID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PilotID3", obj.PilotID3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID1", obj.FAID1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID2", obj.FAID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID3", obj.FAID3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID4", obj.FAID4, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CustID", obj.CustID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@RsrvdSeats", obj.RsrvdSeats, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@SeatMap", obj.SeatMap, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Payload", obj.Payload, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Fuel", obj.Fuel, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Temperature", obj.Temperature, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo1", obj.FwdCargo1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo2", obj.FwdCargo2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo3", obj.FwdCargo3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo4", obj.FwdCargo4, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo1", obj.AftCargo1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo2", obj.AftCargo2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo3", obj.AftCargo3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo4", obj.AftCargo4, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo5", obj.AftCargo5, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo6", obj.AftCargo6, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@GateNum", obj.GateNum, DbType.String, ParameterDirection.Input);
            parameters.Add("@FltTimeStamp", obj.FltTimeStamp, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@AgentID", obj.AgentID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ClosingAgentID", obj.ClosingAgentID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ClosingTimeStamp", obj.ClosingTimeStamp, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@ActualDepTime", obj.ActualDepTime, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltRemarks", obj.FltRemarks, DbType.String, ParameterDirection.Input);
            parameters.Add("@SplitGender", obj.SplitGender, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@SubManifestColor", obj.SubManifestColor, DbType.String, ParameterDirection.Input);
            parameters.Add("@ShowRCS", obj.ShowRCS, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltTSEdit", obj.FltTSEdit, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@FltTSEditAgentID", obj.FltTSEditAgentID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AircraftID", obj.AircraftID, DbType.Int32, ParameterDirection.Input);
            
            return _dapper.Update<Flight>(@"", parameters);
        }
    }
}
