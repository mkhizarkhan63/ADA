let BaseUrl;
let btnEdit = ".btnEdit";
let Save = "#Save";
let btnUpdate = "#Edit";
var ETD = "#ETD";
var FlightNumber = "#FlightNumber";
var SeatMap = "#SeatMap";
var Dest1 = "#Dest1";
var Dest2 = "#Dest2";
var AircraftType = "#AircraftType";
var RCS = "#RCS";
var FlightColor1 = "#FlightColor1";
var FlightColor2 = "#FlightColor2";
var Route = "#Route";
var ManifestColor1 = "#ManifestColor1";
var ManifestColor2 = "#ManifestColor2";
var ManifestColor3 = "#ManifestColor3";
var UsefulWeight1 = "#UsefulWeight1";
var UsefulWeight2 = "#UsefulWeight2";
var UsefulWeight3 = "#UsefulWeight3";
var UsefulWeightColor1 = "#UsefulWeightColor1";
var UsefulWeightColor2 = "#UsefulWeightColor2";
var UsefulWeightColor3 = "#UsefulWeightColor3";
var UsefulWeightBeta1 = "#UsefulWeightBeta1";
var UsefulWeightBeta2 = "#UsefulWeightBeta2";
var UsefulWeightBeta3 = "#UsefulWeightBeta3";
var Pilot1 = "#Pilot1";
var Pilot2 = "#Pilot2";
var Observer = "#Observer";
var FA1 = "#FA1";
var FA2 = "#FA2";
var Customer = "#Customer";
var PaxList = "#PaxList";
var Fuel = "#Fuel";
var SplitGender = "#SplitGender";
var MaxCargo = "#MaxCargo";
var Temperature = "#Temperature";
var RsrvdSeats = "#RsrvdSeats";
var GateNumber = "#GateNumber";
var Frt = "#Frt";
var Bag = "#Bag";
var FrtBagTotal = "#FrtBagTotal";
var FWDcargo1 = "#FWDcargo1";
var FWDcargo2 = "#FWDcargo2";
var FWDcargo3 = "#FWDcargo3";
var FWDcargo4 = "#FWDcargo4";
var AFTcargo1 = "#AFTcargo1";
var AFTcargo2 = "#AFTcargo2";
var AFTcargo3 = "#AFTcargo3";
var AFTcargo4 = "#AFTcargo4";
var AFTcargo5 = "#AFTcargo5";
var AFTcargo6 = "#AFTcargo6";
var FlightStatus = "#FlightStatus";
var Agent = "#Agent";
var ATD = "#ATD";
var Remarks = "#Remarks";

 $(document).ready(function () {
    BaseUrl = $("#baseUrlForMVCAction").val();
    if (BaseUrl == "null")
        BaseUrl = "";
    baseApiUrl = $("#baseApiUrl").val();

    baseWebUrl = $("#baseWebUrl").val();

     GetAllFlight();

    $(document).on('click', btnEdit, function (e) {
        let id = $(e.currentTarget).data('id');
        GetFLightByID(id);
    });


    $(Save).click(function () {

        AddFlight();
      
    });


   $(btnUpdate).click(function () {

        UpdateFlight();
     });
 });



function GetAllDropdown() {


    postRequest(BaseUrl +"/DashBoard/GetAllDropdown", null, function (res) {




        debugger
        if (res.status == 200)
            if (res.data && res.data != null) {

                fillData(res.data.arcraft, '#temp_DropDownaircraft', AircraftType, false);
                fillData(res.data.destination, '#temp_DropDowndest1', Dest1, false);
                fillData(res.data.destination, '#temp_DropDowndest2', Dest2, false);
                fillData(res.data.pilot, '#temp_DropDownpilot1', Pilot1, false);
                fillData(res.data.pilot, '#temp_DropDownpilot2', Pilot2, false);
                fillData(res.data.pilot, '#temp_DropDownobserver', Observer, false);
                fillData(res.data.staff, '#temp_DropDownFA1', FA1, false);
                fillData(res.data.staff, '#temp_DropDownFA2', FA2, false);
                fillData(res.data.staff, '#temp_DropDownAgent', Agent, false);
                fillData(res.data.customer, '#temp_DropDowncustomer', Customer, false);
                fillData(res.data.flightStatus, '#temp_DropDownflightStatus', FlightStatus, false);
            }
        if (res.Status == 401) {
            LoaderHide();
            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Account/Authenticate";
        }
        if (res.Status == 403) {


            swal(res.ResponseMsg, {
                icon: "error",
                title: "Error",
            });
        }
        if (res.Status == 500) {
            LoaderHide();
            swal({
                title: "Error",
                text: res.ResponseMsg,
                icon: "error",
                dangerMode: true,
            })
        }

        if (res.Status == 420) {
            LoaderHide();
            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Account/Authenticate";
        }

        if (res.Status == 600) {

            swal({
                title: "Error",
                text: res.ResponseMsg,
                icon: "error",
                dangerMode: true,
            })
        }

    });


}


function GetAllFlight() {

    $("#FlightTable").DataTable({
        "responsive": true,
        "lengthChange": true,
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "pageLength": 10,
        "orderClasses": false,
        //"aaSorting": [
        //    [11, 'desc']
        //],
        //"initComplete": function (settings, json) {
        //    HideKeys();
        //},

        "ajax": {
            "url": BaseUrl +"/DashBoard/GetAllFlights",
            "type": "POST",
            "dataType": "json",

            "dataSrc": function (data) {

                debugger;
                if (data.status == 200) {
                    debugger;
                    GetAllDropdown();
                }

                if (data.status == 401) {

                    window.location.href = baseWebUrl + "Dashboard";
                }
                if (data.status == 403) {

                    swal(data.ResponseMsg, {
                        icon: "error",
                        title: "Error",
                    });
                }

                if (data.status == 420) {

                    localStorage.removeItem("Menu");
                    localStorage.removeItem("userData");
                    window.location.href = baseWebUrl + "Dashboard";
                }

                if (data.status == 500) {

                    swal({
                        title: "Error",
                        text: data.ResponseMsg,
                        icon: "error",
                        dangerMode: true,
                    })
                }

                if (data.status == 600) {

                    swal({
                        title: "Error",
                        text: data.ResponseMsg,
                        icon: "error",
                        dangerMode: true,
                    })
                }

                return data.data;
            }

        },


        //"columnDefs": [{
        //    "targets": [0],
        //    "visible": true,
        //    "searchable": false,
        //    "sortable": false
        //}
        //],

        "columns": [

            { "data": "fltID", "name": "fltID", "autoWidth": true },
            {
                "data": "fltDateTime",
                "name": "fltDateTime",
                "autoWidth": true
            },
            {
                "data": "fltNumber",
                "name": "fltNumber",
                "autoWidth": true
            },
            {
                "data": "dest1",
                "name": "dest1",
                "autoWidth": true
            },
            {
                "data": "dest2",
                "name": "dest2",
                "autoWidth": true
            },
            {
                "data": "fltColor",
                "name": "fltColor",
                "autoWidth": true
            },
            {
                "data": "fltStatus",
                "name": "fltStatus",
                "autoWidth": true
            },


            {
                "data": "fltRoute",
                "name": "fltRoute",
                "autoWidth": true
            },
            {
                "data": "pilot1",
                "name": "pilot1",
                "autoWidth": true
            },
            {
                "data": "pilot2",
                "name": "pilot2",
                "autoWidth": true
            },

            {
                "data": "pilot3",
                "name": "pilot3",
                "autoWidth": true
            },
            {
                "data": "fA1",
                "name": "fA1",
                "autoWidth": true
            },
            {
                "data": "fA2",
                "name": "fA2",
                "autoWidth": true
            },
            {
                "data": "customer",
                "name": "customer",
                "autoWidth": true
            },

            {
                "data": "rsrvdSeats",
                "name": "rsrvdSeats",
                "autoWidth": true
            },
            {
                "data": "seatMap",
                "name": "seatMap",
                "autoWidth": true
            },
            {
                "data": "payload",
                "name": "payload",
                "autoWidth": true
            },

            {
                "data": "fuel",
                "name": "fuel",
                "autoWidth": true
            },
            {
                "data": "temperature",
                "name": "temperature",
                "autoWidth": true
            },
            {
                "data": "fwdCargo1",
                "name": "fwdCargo1",
                "autoWidth": true
            },
            {
                "data": "fwdCargo2",
                "name": "fwdCargo2",
                "autoWidth": true
            },
            {
                "data": "fwdCargo3",
                "name": "fwdCargo3",
                "autoWidth": true
            },
            {
                "data": "fwdCargo4",
                "name": "fwdCargo4",
                "autoWidth": true
            },
            {
                "data": "aftCargo1",
                "name": "aftCargo1",
                "autoWidth": true
            },
            {
                "data": "aftCargo2",
                "name": "aftCargo2",
                "autoWidth": true
            },
            {
                "data": "aftCargo3",
                "name": "aftCargo3",
                "autoWidth": true
            },
            {
                "data": "aftCargo4",
                "name": "aftCargo4",
                "autoWidth": true
            },
            {
                "data": "aftCargo5",
                "name": "aftCargo5",
                "autoWidth": true
            },
            {
                "data": "aftCargo6",
                "name": "aftCargo6",
                "autoWidth": true
            },
            {
                "data": "gateNum",
                "name": "gateNum",
                "autoWidth": true
            },
            {
                "data": "fltTimeStamp",
                "name": "fltTimeStamp",
                "autoWidth": true
            },
            {
                "data": "agent",
                "name": "agent",
                "autoWidth": true
            },
            {
                "data": "closingAgent",
                "name": "closingAgent",
                "autoWidth": true
            },
            {
                "data": "closingTimeStamp",
                "name": "closingTimeStamp",
                "autoWidth": true
            },
            {
                "data": "actualDepTime",
                "name": "actualDepTime",
                "autoWidth": true
            },
            {
                "data": "fltRemarks",
                "name": "fltRemarks",
                "autoWidth": true
            },
            {
                "data": "splitGender",
                "name": "splitGender",
                "autoWidth": true
            },
            {
                "data": "subManifestColor",
                "name": "subManifestColor",
                "autoWidth": true
            },
            {
                "data": "showRCS",
                "name": "showRCS",
                "autoWidth": true
            },
            {
                "data": "fltTSEdit",
                "name": "fltTSEdit",
                "autoWidth": true
            },


            {
                "data": "fltTSEditAgent",
                "name": "fltTSEditAgent",
                "autoWidth": true
            },
            {
                "data": "aircraft",
                "name": "aircraft",
                "autoWidth": true
            },
            {
                "render": function (data, type, full, meta) {

                    return '<div class="btn-group btn-group-sm"><div class="d-flex"><a href="javascript:;" class="btn btn-primary shadow btn-xs sharp mr-1 btnEdit"  title="Edit" data-id="' + full.fltID + '"><i class="fa fa-pencil"></i></a><a href="javascript:;" class= "btn shadow btn-xs sharp mr-1  btnDelete" title="Cancel Flight"  style="background: #9c3636;color: white;" data-id="' + full.fltID + '"> <i class="fa fa-times-circle" style="background: #9c3636;color: white;"></i></a><a href="javascript:;" title="Delete" class="btn btn-danger shadow btn-xs sharp mr-1 btnDeleteRecord" data-id="' + full.fltID + '"><i class="fa fa-trash"></i></a></div>';


                }
            },




        ]


    });
}



function GetFLightByID(id) {
 

    postRequest(BaseUrl +"/DashBoard/GetFLightByID/" + id, null, function (res) {

        debugger
        if (res.status == 200)
        {
            if (res.data && res.data != null) {

                $("#FLTId").val(res.data.fltID);
                $(ETD).val(moment(res.data.fltDateTime).format('YYYY-MM-DD'));
                $(FlightNumber).val(res.data.fltNumber);
                $(SeatMap).prop("checked", res.data.seatMap);
                $(Dest1).val(res.data.destID);
                $(Dest2).val(res.data.destID2);
                $(AircraftType).val(res.data.aircraftID_Fk);
                $(RCS).prop("checked", res.data.showRCS);
                $(FlightColor1).val(res.data.fltColor.split(',')[0]);
                $(FlightColor2).val(res.data.fltColor.split(',')[1]);
                $(Route).val(res.data.fltRoute);
                $(ManifestColor1).val(res.data.subManifestColor1);
                $(ManifestColor2).val(res.data.subManifestColor2);
                $(ManifestColor3).val(res.data.subManifestColor3);
                $(UsefulWeight1).val(res.data.subManifestColor1Wgt);
                $(UsefulWeight2).val(res.data.subManifestColor2Wgt);
                $(UsefulWeight3).val(res.data.subManifestColor3Wgt);
                $(UsefulWeightColor1).val(res.data.subManifestColor4);
                $(UsefulWeightColor2).val(res.data.subManifestColor5);
                $(UsefulWeightColor3).val(res.data.subManifestColor6);
                $(UsefulWeightBeta1).val(res.data.subManifestColor4Wgt);
                $(UsefulWeightBeta2).val(res.data.subManifestColor5Wgt);
                $(UsefulWeightBeta3).val(res.data.subManifestColor6Wgt);
                $(Pilot1).val(res.data.pilotID1_Fk);
                $(Pilot2).val(res.data.pilotID2_Fk);
                $(Observer).val(res.data.pilotID3_Fk);
                $(FA1).val(res.data.faiD1_FK);
                $(FA2).val(res.data.faiD2_FK);
                $(Customer).val(res.data.custID_Fk);
                $(PaxList).val(true);
                $(Fuel).val(res.data.fuel);
                $(SplitGender).prop("checked", res.data.splitGender);
                $(MaxCargo).val("0");
                $(Temperature).val(res.data.temperature);
                $(RsrvdSeats).val(res.data.rsrvdSeats);
                $(GateNumber).val(res.data.gateNum);
                $(Frt).val("");
                $(Bag).val("");
                $(FrtBagTotal).val("");
                $(FWDcargo1).val(res.data.fwdCargo1);
                $(FWDcargo2).val(res.data.fwdCargo2);
                $(FWDcargo3).val(res.data.fwdCargo3);
                $(FWDcargo4).val(res.data.fwdCargo4);
                $(AFTcargo1).val(res.data.aftCargo1);
                $(AFTcargo2).val(res.data.aftCargo2);
                $(AFTcargo3).val(res.data.aftCargo3);
                $(AFTcargo4).val(res.data.aftCargo4);
                $(AFTcargo5).val(res.data.aftCargo5);
                $(AFTcargo6).val(res.data.aftCargo6);
                $(FlightStatus).val(res.data.fltStatus_Fk);
                $(Agent).val(res.data.agentID_Fk);
                $(ATD).val(res.data.actualDepTime);
                $(Remarks).val(res.data.fltRemarks);

            }
        }
        if (res.Status == 401) {
            LoaderHide();
            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Account/Authenticate";
        }
        if (res.Status == 403) {


            swal(res.ResponseMsg, {
                icon: "error",
                title: "Error",
            });
        }
        if (res.Status == 500) {
            LoaderHide();
            swal({
                title: "Error",
                text: res.ResponseMsg,
                icon: "error",
                dangerMode: true,
            })
        }

        if (res.Status == 420) {
            LoaderHide();
            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Account/Authenticate";
        }

        if (res.Status == 600) {

            swal({
                title: "Error",
                text: res.ResponseMsg,
                icon: "error",
                dangerMode: true,
            })
        }
  
    });


}

function AddFlight() {

    var FlightColor = `${$(FlightColor1).val()},${$(FlightColor2).val()}`;
    var SubManifest = `${$(ManifestColor1).val() != null && $(ManifestColor1).val() != -1 ? $(ManifestColor1).val() : "---"}${$(UsefulWeight1).val() > 0 ? $(UsefulWeight1).val() : "---"},${$(ManifestColor2).val() != null && $(ManifestColor2).val() != -1 ? $(ManifestColor2).val() : "---"}${$(UsefulWeight2).val() > 0 ? $(UsefulWeight2).val() : "---"},${$(ManifestColor3).val() != null && $(ManifestColor3).val() != -1 ? $(ManifestColor3).val() : "---"}${$(UsefulWeight3).val() > 0 ? $(UsefulWeight3).val() : "---"},${$(UsefulWeightColor1).val() != null && $(UsefulWeightColor1).val() != -1 ? $(UsefulWeightColor1).val() : "---"}${$(UsefulWeightBeta1).val() > 0 ? $(UsefulWeightBeta1).val() : "---"},${$(UsefulWeightColor2).val() != null && $(UsefulWeightColor2).val() != -1 ? $(UsefulWeightColor2).val() : "---"}${$(UsefulWeightBeta2).val() > 0 ? $(UsefulWeightBeta2).val() : "---"},${$(UsefulWeightColor3).val() != null && $(UsefulWeightColor3).val() != -1 ? $(UsefulWeightColor3).val() : "---"}${$(UsefulWeightBeta3).val() > 0 ? $(UsefulWeightBeta3).val() : "---"}`;
    var checkedRCS = $(RCS).is(':checked');
    var checkedSeatMap = $(SeatMap).is(':checked');
    var checkedSplitGender = $(SplitGender).is(':checked');
    var data = {
        "FltDateTime": $(ETD).val(),
        "FltNumber": $(FlightNumber).val(),
        "SeatMap": checkedSeatMap,
        "DestID": Number($(Dest1).val()),
        "DestID2": Number($(Dest2).val()),
        "AircraftID_Fk": Number($(AircraftType).val()),
        "ShowRCS": checkedRCS,
        "FltColor": FlightColor,
        "FltRoute": $(Route).val(),
        "SubManifestColor": SubManifest,
        "PilotID1_Fk": Number($(Pilot1).val()),
        "PilotID2_Fk": Number($(Pilot2).val()),
        "PilotID3_Fk": Number($(Observer).val()),
        "FAID1_FK": Number($(FA1).val()),
        "FAID2_FK": Number($(FA2).val()),
        "CustID_Fk": Number($(Customer).val()),
        //       /* PaxList: PaxList,*/
        "Fuel": Number($(Fuel).val()),
        "SplitGender": checkedSplitGender,
        ///* MaxCargo: Number(MaxCargo),*/
        "Temperature": Number($(Temperature).val()),
        "RsrvdSeats": Number($(RsrvdSeats).val()),
        "GateNum": $(GateNumber).val(),
        "FltStatus_Fk": Number($(FlightStatus).val()),

        //// Frt: Frt,

        ////Bag: Bag,

        ////FrtBagTotal: FrtBagTotal,
        //        Payload : 0,

        "FwdCargo1": Number($(FWDcargo1).val()),
        "FwdCargo2": Number($(FWDcargo2).val()),
        "FwdCargo3": Number($(FWDcargo3).val()),
        "FwdCargo4": Number($(FWDcargo4).val()),
        "AftCargo1": Number($(AFTcargo1).val()),
        "AftCargo2": Number($(AFTcargo2).val()),
        "AftCargo3": Number($(AFTcargo3).val()),
        "AftCargo4": Number($(AFTcargo4).val()),
        "AftCargo5": Number($(AFTcargo5).val()),
        "AftCargo6": Number($(AFTcargo6).val()),
        "AgentID_Fk": Number($(Agent).val()),
        "ActualDepTime": Number($(ATD).val()),
        "FltRemarks": $(Remarks).val(),
        "SubManifestColor1": $(ManifestColor1).val(),
        "SubManifestColor1Wgt": Number($(UsefulWeight1).val()),
        "SubManifestColor2": $(ManifestColor2).val(),
        "SubManifestColor2Wgt": Number($(UsefulWeight2).val()),
        "SubManifestColor3": $(ManifestColor3).val(),
        "SubManifestColor3Wgt": Number($(UsefulWeight3).val()),
        "SubManifestColor4": $(UsefulWeightColor1).val(),
        "SubManifestColor4Wgt": Number($(UsefulWeightBeta1).val()),
        "SubManifestColor5": $(UsefulWeightColor2).val(),
        "SubManifestColor5Wgt": Number($(UsefulWeightBeta2).val()),
        "SubManifestColor6": $(UsefulWeightColor3).val(),
        "SubManifestColor6Wgt": Number($(UsefulWeightBeta3).val()),

    };

       postRequest(BaseUrl +"/DashBoard/AddFlight", data, function (res) {
        debugger
        if (res.status == 200)
        {
            if (res.data && res.data != null) {


                swal({
                    title: "Success",
                    text: "Submission was successful.",
                    icon: "success",
                    dangerMode: false,
                });


             }
        }
        if (res.Status == 401) {
            LoaderHide();
            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Account/Authenticate";
        }
        if (res.Status == 403) {


            swal(res.ResponseMsg, {
                icon: "error",
                title: "Error",
            });
        }
        if (res.Status == 500) {
            LoaderHide();
            swal({
                title: "Error",
                text: res.ResponseMsg,
                icon: "error",
                dangerMode: true,
            })
        }

        if (res.Status == 420) {
            LoaderHide();
            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Account/Authenticate";
        }

        if (res.Status == 600) {

            swal({
                title: "Error",
                text: res.ResponseMsg,
                icon: "error",
                dangerMode: true,
            })
        }

    });


}

function UpdateFlight() {

    var FlightColor = `${$(FlightColor1).val()},${$(FlightColor2).val()}`;
    var SubManifest = `${$(ManifestColor1).val() != null && $(ManifestColor1).val() != -1 ? $(ManifestColor1).val() : "---"}${$(UsefulWeight1).val() > 0 ? $(UsefulWeight1).val() : "---"},${$(ManifestColor2).val() != null && $(ManifestColor2).val() != -1 ? $(ManifestColor2).val() : "---"}${$(UsefulWeight2).val() > 0 ? $(UsefulWeight2).val() : "---"},${$(ManifestColor3).val() != null && $(ManifestColor3).val() != -1 ? $(ManifestColor3).val() : "---"}${$(UsefulWeight3).val() > 0 ? $(UsefulWeight3).val() : "---"},${$(UsefulWeightColor1).val() != null && $(UsefulWeightColor1).val() != -1 ? $(UsefulWeightColor1).val() : "---"}${$(UsefulWeightBeta1).val() > 0 ? $(UsefulWeightBeta1).val() : "---"},${$(UsefulWeightColor2).val() != null && $(UsefulWeightColor2).val() != -1 ? $(UsefulWeightColor2).val() : "---"}${$(UsefulWeightBeta2).val() > 0 ? $(UsefulWeightBeta2).val() : "---"},${$(UsefulWeightColor3).val() != null && $(UsefulWeightColor3).val() != -1 ? $(UsefulWeightColor3).val() : "---"}${$(UsefulWeightBeta3).val() > 0 ? $(UsefulWeightBeta3).val() : "---"}`;
    var checkedRCS = $(RCS).is(':checked');
    var checkedSeatMap = $(SeatMap).is(':checked');
    var checkedSplitGender = $(SplitGender).is(':checked');
    var data = {
        "FltID": Number($("#FLTId").val()),
        "FltDateTime": $(ETD).val(),
        "FltNumber": $(FlightNumber).val(),
        "SeatMap": checkedSeatMap,
        "DestID": Number($(Dest1).val()),
        "DestID2": Number($(Dest2).val()),
        "AircraftID_Fk": Number($(AircraftType).val()),
        "ShowRCS": checkedRCS,
        "FltColor": FlightColor,
        "FltRoute": $(Route).val(),
        "SubManifestColor": SubManifest,
        "PilotID1_Fk": Number($(Pilot1).val()),
        "PilotID2_Fk": Number($(Pilot2).val()),
        "PilotID3_Fk": Number($(Observer).val()),
        "FAID1_FK": Number($(FA1).val()),
        "FAID2_FK": Number($(FA2).val()),
        "CustID_Fk": Number($(Customer).val()),
        //       /* PaxList: PaxList,*/
        "Fuel": Number($(Fuel).val()),
        "SplitGender": checkedSplitGender,
        ///* MaxCargo: Number(MaxCargo),*/
        "Temperature": Number($(Temperature).val()),

        "RsrvdSeats": Number($(RsrvdSeats).val()),

        "GateNum": $(GateNumber).val(),
        "FltStatus_Fk": Number($(FlightStatus).val()),

        //// Frt: Frt,

        ////Bag: Bag,

        ////FrtBagTotal: FrtBagTotal,
        //        Payload : 0,

        "FwdCargo1": Number($(FWDcargo1).val()),

        "FwdCargo2": Number($(FWDcargo2).val()),

        "FwdCargo3": Number($(FWDcargo3).val()),

        "FwdCargo4": Number($(FWDcargo4).val()),

        "AftCargo1": Number($(AFTcargo1).val()),

        "AftCargo2": Number($(AFTcargo2).val()),

        "AftCargo3": Number($(AFTcargo3).val()),

        "AftCargo4": Number($(AFTcargo4).val()),

        "AftCargo5": Number($(AFTcargo5).val()),

        "AftCargo6": Number($(AFTcargo6).val()),

        "AgentID_Fk": Number($(Agent).val()),
        "ActualDepTime": Number($(ATD).val()),
        "FltRemarks": $(Remarks).val(),

        "SubManifestColor1": $(ManifestColor1).val(),
        "SubManifestColor1Wgt": Number($(UsefulWeight1).val()),
        "SubManifestColor2": $(ManifestColor2).val(),
        "SubManifestColor2Wgt": Number($(UsefulWeight2).val()),
        "SubManifestColor3": $(ManifestColor3).val(),
        "SubManifestColor3Wgt": Number($(UsefulWeight3).val()),
        "SubManifestColor4": $(UsefulWeightColor1).val(),
        "SubManifestColor4Wgt": Number($(UsefulWeightBeta1).val()),
        "SubManifestColor5": $(UsefulWeightColor2).val(),
        "SubManifestColor5Wgt": Number($(UsefulWeightBeta2).val()),
        "SubManifestColor6": $(UsefulWeightColor3).val(),
        "SubManifestColor6Wgt": Number($(UsefulWeightBeta3).val()),

    };

    const Id = $("#FLTId").val();
      if (Id > 0) {


          postRequest(BaseUrl+"/DashBoard/UpdateFlight", data, function (res) {

            debugger
            if (res.status == 200) {
                if (res.data && res.data != null) {
                    debugger;

                    swal({
                        title: "Success",
                        text: "Update successfuly.",
                        icon: "success",
                        dangerMode: false,
                    });

                }
            }
            if (res.Status == 401) {
                LoaderHide();
                localStorage.removeItem("Menu");
                localStorage.removeItem("userData");
                window.location.href = baseWebUrl + "Account/Authenticate";
            }
            if (res.Status == 403) {


                swal(res.ResponseMsg, {
                    icon: "error",
                    title: "Error",
                });
            }
            if (res.Status == 500) {
                LoaderHide();
                swal({
                    title: "Error",
                    text: res.ResponseMsg,
                    icon: "error",
                    dangerMode: true,
                })
            }

            if (res.Status == 420) {
                LoaderHide();
                localStorage.removeItem("Menu");
                localStorage.removeItem("userData");
                window.location.href = baseWebUrl + "Account/Authenticate";
            }

            if (res.Status == 600) {

                swal({
                    title: "Error",
                    text: res.ResponseMsg,
                    icon: "error",
                    dangerMode: true,
                })
            }

        });

    } else {

        swal("Please Select row Table After Update", {
            icon: "error",
            title: "Error",
            dangerMode: true,
        });
    }
}





function postRequest(url, requestData, handledata) {
    $.ajax({
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        dataType: "json",
        url: url,
        headers: {

        },

        data: JSON.stringify(requestData),
        success: function (data, textStatus, xhr) {
            handledata(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            swal({
                title: "Error",
                text: "Something Went Wrong!",
                icon: "error",
                dangerMode: true,
            })
        }
    });
}


function fillData(res, tempContainerId, fillContainerId, IsRefresh) {
    if (res) {
        $(fillContainerId).html('');
        let template = $(tempContainerId).html()
        var templateScript = Handlebars.compile(template);
        $(fillContainerId).html(templateScript(res));
        if (IsRefresh)
            $(fillContainerId).selectpicker('refresh');
    }
}