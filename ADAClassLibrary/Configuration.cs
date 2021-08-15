using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

}
