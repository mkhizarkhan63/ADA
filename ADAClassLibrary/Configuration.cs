using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ADAClassLibrary
{
    class Configuration
    {


    }

    public class Aircraft
    {
        public int AircraftID { get; set; }
        public string ACReg { get; set; }
        public string ACType { get; set; }
        public int ACCapacity { get; set; }
        public int ACRows { get; set; }
        public int MaleWt { get; set; }
        public int FemaleWt { get; set; }
        public int ChildWt { get; set; }
        public int InfantWt { get; set; }
        public int MaxInfantQty { get; set; }
        public string ColumnLabel { get; set; }
        public string ExitRows { get; set; }
        public string RFFS { get; set; }
        public string Row1 { get; set; }
        public string Row2 { get; set; }
        public string Row3 { get; set; }
        public string Row4 { get; set; }
        public string Row5 { get; set; }
        public string Row6 { get; set; }
        public string Row7 { get; set; }
        public string Row8 { get; set; }
        public string Row9 { get; set; }
        public string Row10 { get; set; }
        public string Row11 { get; set; }
        public string Row12 { get; set; }
        public string Row13 { get; set; }
        public string Row14 { get; set; }
        public string Row15 { get; set; }
        public string Row16 { get; set; }
        public string Row17 { get; set; }
        public string Row18 { get; set; }
        public string Row19 { get; set; }
        public string Row20 { get; set; }
        public string Row21 { get; set; }
        public string Row22 { get; set; }
        public string Row23 { get; set; }
        public string Row24 { get; set; }
        public string Row25 { get; set; }
        public double FWDCargoHold { get; set; }
        public double AftCargoHold { get; set; }
        public int ACActive { get; set; }
        public string FwdCargoWT { get; set; }
        public string AftCargoWT { get; set; }

    }

    public class Pilot {

        public int PilotID { get; set; }
        public string PilotEmpNum { get; set; }
        public string PilotSurname { get; set; }
        public string PilotName { get; set; }
        public string ACType { get; set; }
        public bool PilotActive { get; set; }

    }

    public class Staff
    {

        public int StaffID { get; set; }
        public string EmpNum { get; set; }
        public string StaffSurname { get; set; }
        public string StaffName { get; set; }
        public string StaffPwd { get; set; }
        public bool StaffRights { get; set; }
        public bool StaffActive { get; set; }
        public string StaffGrp { get; set; }
    }

    public class Flight : FlightView
    {
       
        public int FltID { get; set; }
        public DateTime? FltDateTime { get; set; }
        public string FltNumber { get; set; }

        public int DestID { get; set; }
        
        public int DestID2 { get; set; }
        public string FltColor { get; set; }
        
        public int FltStatus_Fk { get; set; }
        public string FltRoute { get; set; }
        
        public int PilotID1_Fk { get; set; }
        
        public int PilotID2_Fk { get; set; }
        
        public int PilotID3_Fk { get; set; }
        
        public int FAID1_FK { get; set; }
        
        public int FAID2_FK { get; set; }
        
        public int FAID3_FK { get; set; }
        
        public int FAID4_FK { get; set; }
        
        public int CustID_Fk { get; set; }
        public int RsrvdSeats { get; set; }
        public bool SeatMap { get; set; }
        public int Payload { get; set; }
        public int Fuel { get; set; }
        public int Temperature { get; set; }
        public int FwdCargo1 { get; set; }
        public int FwdCargo2 { get; set; }
        public int FwdCargo3 { get; set; }
        public int FwdCargo4 { get; set; }
        public int AftCargo1 { get; set; }
        public int AftCargo2 { get; set; }
        public int AftCargo3 { get; set; }
        public int AftCargo4 { get; set; }
        public int AftCargo5 { get; set; }
        public int AftCargo6 { get; set; }
        public string GateNum { get; set; }
        public DateTime? FltTimeStamp { get; set; }
        
        public int AgentID_Fk { get; set; }
        
        public int ClosingAgentID_Fk { get; set; }
        public DateTime? ClosingTimeStamp { get; set; }
        public int ActualDepTime { get; set; }
        public string FltRemarks { get; set; }
        public bool SplitGender { get; set; }
        public string SubManifestColor { get; set; }
        public bool ShowRCS { get; set; }
        public DateTime? FltTSEdit { get; set; }
        
        public int FltTSEditAgentID_Fk { get; set; }
        
        public int AircraftID_Fk { get; set; }


    }

    public class FlightView:MiniFestColors
    {

        public string Dest1 { get; set; }
        public string Dest2 { get; set; }
        public string FltStatus { get; set; }
        public string Pilot1 { get; set; }
        public string Pilot2 { get; set; }
        public string Pilot3 { get; set; }
        public string FA1 { get; set; }
        public string FA2 { get; set; }
        public string FA3 { get; set; }
        public string FA4 { get; set; }
        public string Customer { get; set; }
        public string Agent { get; set; }
        public string ClosingAgent { get; set; }
        public string FltTSEditAgent { get; set; }
        public string Aircraft { get; set; }
    }



    public class Destination
    {
        public int DestID { get; set; }
        public string DestICAO { get; set; }
        public string DestIATA { get; set; }
        public string DestName { get; set; }
        public int HomeBase { get; set; }
        public int OilField { get; set; }
        public int FieldDestID { get; set; }
        public int DestActive { get; set; }
        public string CustDestCode { get; set; }
        public string CustDestName { get; set; }
        public string FIDSName { get; set; }
        public int FltDest { get; set; }
    }
    public class Customer {

        public int CustID { get; set; }
        public int CustCode { get; set; }
        public string CustName { get; set; }
        public bool UsePaxList { get; set; }


    }
    public class FlightStatus {

        public int fltStatusID { get; set; }
        public string fltStatus { get; set; }


    }




    public class DropdownList{


        public List<Customer> customer { get; set; }
        public List<Destination> destination { get; set; }
        public List<Pilot> pilot { get; set; }
        public List<Staff> staff { get; set; }
        public List<Aircraft> arcraft { get; set; }
        public List<FlightStatus> flightStatus { get; set; }

    }


    public class MiniFestColors 
    {
        public string SubManifestColor1 { get; set; }
        public int SubManifestColor1Wgt { get; set; }
        public string SubManifestColor2 { get; set; }
        public int SubManifestColor2Wgt { get; set; }
        public string SubManifestColor3 { get; set; }
        public int SubManifestColor3Wgt { get; set; }
        public string SubManifestColor4 { get; set; }
        public int SubManifestColor4Wgt { get; set; }
        public string SubManifestColor5 { get; set; }
        public int SubManifestColor5Wgt { get; set; }
        public string SubManifestColor6 { get; set; }
        public int SubManifestColor6Wgt { get; set; }

    }

}
