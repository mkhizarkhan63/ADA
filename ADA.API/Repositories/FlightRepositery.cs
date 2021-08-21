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
    public class FlightRepositery : IFlightRepositery
    {
        private readonly IDapper _dapper;

        public FlightRepositery(IDapper dapper)
        {
            _dapper = dapper;
        }
        public Flight Add(Flight flight)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@FltDateTime", flight.FltDateTime , DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@FltNumber", flight.FltNumber , DbType.String, ParameterDirection.Input);
            parameters.Add("@DestID", flight.DestID , DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DestID2", flight.DestID2 , DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltColorID_Fk", flight.FltColorID_Fk , DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltStatus_Fk", flight.FltStatus_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltRoute", flight.FltRoute, DbType.String, ParameterDirection.Input);
            parameters.Add("@PilotID1_Fk", flight.PilotID1_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PilotID2_Fk", flight.PilotID2_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PilotID3_Fk", flight.PilotID3_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID1_FK", flight.FAID1_FK, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID2_Fk", flight.FAID2_FK, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID3_Fk", flight.FAID3_FK, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID4_Fk", flight.FAID4_FK, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CustID_Fk", flight.CustID_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@RsrvdSeats", flight.RsrvdSeats, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@SeatMap", flight.SeatMap, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@Payload", flight.Payload, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Fuel", flight.Fuel, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Temperature", flight.Temperature, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo1", flight.FwdCargo1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo2", flight.FwdCargo2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo3", flight.FwdCargo3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo4", flight.FwdCargo4, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo1", flight.AftCargo1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo2", flight.AftCargo2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo3", flight.AftCargo3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo4", flight.AftCargo4, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo5", flight.AftCargo5, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo6", flight.AftCargo6, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@GateNum", flight.GateNum, DbType.String, ParameterDirection.Input);
            parameters.Add("@FltTimeStamp", flight.FltTimeStamp, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@AgentID_Fk", flight.AgentID_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ClosingAgentID_Fk", flight.ClosingAgentID_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ClosingTimeStamp", flight.ClosingTimeStamp, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ActualDepTime", flight.ActualDepTime, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltRemarks", flight.FltRemarks, DbType.String, ParameterDirection.Input);
            parameters.Add("@SplitGender", flight.SplitGender, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@SubManifestID_Fk", flight.SubManifestID_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ShowRCS", flight.ShowRCS, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@FltTSEdit", flight.FltTSEdit, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@FltTSEditAgentID_Fk", flight.FltTSEditAgentID_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AircraftID_Fk", flight.AircraftID_Fk, DbType.Int32, ParameterDirection.Input);

            return _dapper.Insert<Flight>(@"[dbo].[usp_insertFlight]", parameters);
        }

        public List<Flight> GetAll()
        {
            DynamicParameters parameters = new DynamicParameters();
            return _dapper.GetAll<Flight>(@"[dbo].[usp_getFlights]", parameters);
        }

        public Flight Update(Flight flight)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@FltID", flight.FltID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltDateTime", flight.FltDateTime, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@FltNumber", flight.FltNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("@DestID", flight.DestID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DestID2", flight.DestID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltColorID_Fk", flight.FltColorID_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltStatus_Fk", flight.FltStatus_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltRoute", flight.FltRoute, DbType.String, ParameterDirection.Input);
            parameters.Add("@PilotID1_Fk", flight.PilotID1_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PilotID2_Fk", flight.PilotID2_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PilotID3_Fk", flight.PilotID3_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID1_FK", flight.FAID1_FK, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID2_Fk", flight.FAID2_FK, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID3_Fk", flight.FAID3_FK, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID4_Fk", flight.FAID4_FK, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CustID_Fk", flight.CustID_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@RsrvdSeats", flight.RsrvdSeats, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@SeatMap", flight.SeatMap, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@Payload", flight.Payload, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Fuel", flight.Fuel, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Temperature", flight.Temperature, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo1", flight.FwdCargo1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo2", flight.FwdCargo2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo3", flight.FwdCargo3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FwdCargo4", flight.FwdCargo4, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo1", flight.AftCargo1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo2", flight.AftCargo2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo3", flight.AftCargo3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo4", flight.AftCargo4, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo5", flight.AftCargo5, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AftCargo6", flight.AftCargo6, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@GateNum", flight.GateNum, DbType.String, ParameterDirection.Input);
            parameters.Add("@FltTimeStamp", flight.FltTimeStamp, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@AgentID_Fk", flight.AgentID_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ClosingAgentID_Fk", flight.ClosingAgentID_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ClosingTimeStamp", flight.ClosingTimeStamp, DbType.DateTime , ParameterDirection.Input);
            parameters.Add("@ActualDepTime", flight.ActualDepTime, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltRemarks", flight.FltRemarks, DbType.String, ParameterDirection.Input);
            parameters.Add("@SplitGender", flight.SplitGender, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@SubManifestID_Fk", flight.SubManifestID_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ShowRCS", flight.ShowRCS, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@FltTSEdit", flight.FltTSEdit, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@FltTSEditAgentID_Fk", flight.FltTSEditAgentID_Fk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AircraftID_Fk", flight.AircraftID_Fk, DbType.Int32, ParameterDirection.Input);

            return _dapper.Update<Flight>(@"[dbo].[usp_updateFlight]", parameters);
        }
    }
}
