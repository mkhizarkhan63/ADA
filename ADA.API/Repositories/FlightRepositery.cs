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

        public Flight Add(Flight obj)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@FltDateTime", obj.ETD, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@FltNumber", obj.FltNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("@DestID", obj.DestID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DestID2", obj.DestID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltColor", obj.Color, DbType.String, ParameterDirection.Input);
            parameters.Add("@FltStatus", obj.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("@FltRoute", obj.FltRoute, DbType.String, ParameterDirection.Input);
            parameters.Add("@PilotID1", obj.Pilot_ID1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PilotID2", obj.Pilot_ID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PilotID3", obj.Pilot_ID3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID1", obj.FA_ID1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID2", obj.FA_ID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID3", obj.FA_ID3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID4", obj.FA_ID4, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CustID", obj.CustID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@RsrvdSeats", obj.RsrvdSeats, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@SeatMap", obj.SeatMap, DbType.Boolean, ParameterDirection.Input);
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
            parameters.Add("@GateNum", obj.GateNum, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltTimeStamp", obj.FltTimeStamp, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@AgentID", obj.AgentID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ClosingAgentID", obj.ClosingAgentID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ClosingTimeStamp", obj.ClosingTimeStamp, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@ActualDepTime", obj.ActualDepTime, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltRemarks", obj.FltRemarks, DbType.String, ParameterDirection.Input);
            parameters.Add("@SplitGender", obj.SplitGender, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@SubManifest", obj.SubManifestColor, DbType.String, ParameterDirection.Input);
            parameters.Add("@ShowRCS", obj.ShowRCS, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@FltTSEditAgentID", obj.FltTSEditAgentID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AircraftID", obj.AircraftID, DbType.Int32, ParameterDirection.Input);
            return _dapper.Insert<Flight>(@"[dbo].[usp_AddFlight]", parameters);
        }

        public object GetAircraftType(string type)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Type", type, DbType.String, ParameterDirection.Input);
  
            var data = _dapper.GetMultipleObjects("[dbo].[GetAircraftType]", parameters, gr => gr.Read<AirCraftDropDown>(), qr => qr.Read<Pilot>(), pr => pr.Read<Staff>());
            DropdownList obj = new DropdownList();


            obj.AirCraft = data.Item1.ToList();
            obj.Pilot = data.Item2.ToList();
            obj.Staff = data.Item3.ToList();
        


            return obj;
        }

        public List<Flight> GetAll()
        {
            DynamicParameters parameters = new DynamicParameters();

            var data = _dapper.GetAll<Flight>(@"[dbo].[GetAllFlightSchedule]", parameters);
            return data;
        }

        public Flight GetByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@FltID", id , DbType.Int32, ParameterDirection.Input);
            return _dapper.Get<Flight>(@"[dbo].[usp_getFlightByID]", parameters);
        }

        public object GetFlightsDropDown()
        {
            DynamicParameters parameters = new DynamicParameters();
            var data= _dapper.GetMultipleObjects("[dbo].[usp_GetValuesDropDown]", parameters ,gr=>gr.Read<Destination>() , gr=> gr.Read<AirCraftDropDown>() , qr=>qr.Read<Pilot>(), pr=>pr.Read<Staff>(), jr=>jr.Read<Customer>() );

            DropdownList obj = new DropdownList();

            obj.Destination = data.Item1.ToList();
            obj.AirCraft = data.Item2.Where(x=>x.ACType.Contains("FW")).ToList();
            obj.Pilot = data.Item3.Where(x => x.ACType.Contains("FW")).ToList();
            obj.Staff = data.Item4.Where(x =>x.StaffActive==true && x.StaffGrp.Contains("FW") || x.StaffGrp.Contains("CM") || x.StaffGrp.Contains("AL")).ToList();
            obj.Customer = data.Item5.ToList();


            return obj;
        }



        public Flight Update(Flight obj)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@FltID", obj.FltID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltDateTime", obj.ETD, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@FltNumber", obj.FltNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("@DestID", obj.DestID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DestID2", obj.DestID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltColor", obj.Color, DbType.String, ParameterDirection.Input);
            parameters.Add("@FltStatus", obj.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("@FltRoute", obj.FltRoute, DbType.String, ParameterDirection.Input);
            parameters.Add("@PilotID1", obj.Pilot_ID1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PilotID2", obj.Pilot_ID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PilotID3", obj.Pilot_ID3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID1", obj.FA_ID1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID2", obj.FA_ID2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID3", obj.FA_ID3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FAID4", obj.FA_ID4, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CustID", obj.CustID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@RsrvdSeats", obj.RsrvdSeats, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@SeatMap", obj.SeatMap, DbType.Boolean, ParameterDirection.Input);
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
            parameters.Add("@GateNum", obj.GateNum, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltTimeStamp", obj.FltTimeStamp, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@AgentID", obj.AgentID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ClosingAgentID", obj.ClosingAgentID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ClosingTimeStamp", obj.ClosingTimeStamp, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@ActualDepTime", obj.ActualDepTime, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltRemarks", obj.FltRemarks, DbType.String, ParameterDirection.Input);
            parameters.Add("@SplitGender", obj.SplitGender, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@SubManifest", obj.SubManifestColor, DbType.String, ParameterDirection.Input);
            parameters.Add("@ShowRCS", obj.ShowRCS, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@FltTSEditAgentID", obj.FltTSEditAgentID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AircraftID", obj.AircraftID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FltTSEdit", obj.FltTSEdit, DbType.DateTime2, ParameterDirection.Input);
        

            return _dapper.Update<Flight>(@"[dbo].[usp_updateFlight]", parameters);
        }
    }
}
