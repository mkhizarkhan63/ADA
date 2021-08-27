
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
var example2 = "#example2";


$(document).ready(function () {

    GetFlights();

    $.ajax({
        type: "POST",
        url: "https://localhost:44317/api/Flight/GetAllDropdowns",

        success: function (data) {
            fillData(data.data.arcraft, '#temp_DropDownaircraft', AircraftType, false);
            fillData(data.data.destination, '#temp_DropDowndest1', Dest1, false);
            fillData(data.data.destination, '#temp_DropDowndest2', Dest2, false);
            fillData(data.data.pilot, '#temp_DropDownpilot1', Pilot1, false);
            fillData(data.data.pilot, '#temp_DropDownpilot2', Pilot2, false);
            fillData(data.data.pilot, '#temp_DropDownobserver', Observer, false);
            fillData(data.data.staff, '#temp_DropDownFA1', FA1, false);
            fillData(data.data.staff, '#temp_DropDownFA2', FA2, false);
            fillData(data.data.staff, '#temp_DropDownAgent', Agent, false);
            fillData(data.data.customer, '#temp_DropDowncustomer', Customer, false);
            fillData(data.data.flightStatus, '#temp_DropDownflightStatus', FlightStatus, false);


        },
        error: function (data) {
            console.log('An error occurred.');
            console.log(data);
        },


    });



    FrtBagTotal = Frt + Bag


    $('#Save').click(function () {

        var FlightColor = `${$(FlightColor1).val()},${$(FlightColor2).val()}`
        var SubManifest = `${$(ManifestColor1).val() != null && $(ManifestColor1).val() != -1 ? $(ManifestColor1).val() : "---"}${$(UsefulWeight1).val() > 0 ? $(UsefulWeight1).val() : "---"},${$(ManifestColor2).val() != null && $(ManifestColor2).val() != -1 ? $(ManifestColor2).val() : "---"}${$(UsefulWeight2).val() > 0 ? $(UsefulWeight2).val() : "---"},${$(ManifestColor3).val() != null && $(ManifestColor3).val() != -1 ? $(ManifestColor3).val() : "---"}${$(UsefulWeight3).val() > 0 ? $(UsefulWeight3).val() : "---"},${$(UsefulWeightColor1).val() != null && $(UsefulWeightColor1).val() != -1 ? $(UsefulWeightColor1).val() : "---"}${$(UsefulWeightBeta1).val() > 0 ? $(UsefulWeightBeta1).val() : "---"},${$(UsefulWeightColor2).val() != null && $(UsefulWeightColor2).val() != -1 ? $(UsefulWeightColor2).val() : "---"}${$(UsefulWeightBeta2).val() > 0 ? $(UsefulWeightBeta2).val() : "---"},${$(UsefulWeightColor3).val() != null && $(UsefulWeightColor3).val() != -1 ? $(UsefulWeightColor3).val() : "---"}${$(UsefulWeightBeta3).val() > 0 ? $(UsefulWeightBeta3).val() : "---"}`

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
            "SubManifest": SubManifest,
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

            "FltRemarks": $(Remarks).val()



        };

        console.log(data.flightStatus);

        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: 'https://localhost:44317/api/Flight/Add',
            data: JSON.stringify(data),

            success: function (data) {
                console.log('Submission was successful.');
                console.log(data);
            },
            error: function (data) {
                console.log('An error occurred.');
                console.log(data);
            },
        });
    });

});


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

$('#Edit').click(function () {
    $.ajax({
        url: 'https://localhost:44317/api/Flight/GetByID/' + ID,
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        /*data: JSON.parse(data),*/
        //dataSrc: function (data) {
        //    return data.data;
        //},
        success: function (data) {
            console.log(data);

        },
        failure: function (error) {
            console.log(error);
        }
    });

});


function GetFlights() {
    //DataTable
    /* LoaderShow();*/

    $("#FlightsTable").DataTable({
        //"responsive": true,
        
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "pageLength": 10,
        "orderClasses": false,
        //"dom": '<"top"i>rt<"bottom"lp><"clear">',
        //"paging": !0,
        //"aaSorting": [
        //    [11, 'desc']
        //],
        //"initComplete": function (settings, json) {
        //    HideKeys();
        //},

        "ajax": {

            "url": "/Areas/DashBoard/Controllers/Flight/GetAllFlights",
            "type": "POST",


            "datasrc": function (data) {
                console.log(data);
                return data.data;
            },


            "columnDefs": [{
                "targets": [0],
                "visible": true,
                "searchable": false,
                "sortable": false
            }
            ],

            "columns": [
                {
                    "data": "fltID",
                    "name": "fltID",
                    "autoWidth": true
                },
                {
                    "data": "fltDateTime",
                    "name": "fltDateTime",
                    "autoWidth": true
                }, {
                    "data": "fltNumber",
                    "name": "fltNumber",
                    "autoWidth": true
                },
                {
                    "data": "fltColor",
                    "name": "fltColor",
                    "autoWidth": true
                },
                {
                    "data": "fltRoute",
                    "name": "fltRoute",
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
                    "data": "closingTimeStamp",
                    "name": "closingTimeStamp",
                    "autoWidth": true
                },
                {
                    "data": "actualDepTime",
                    "name": "actualDepTime",
                    "autoWidth": true
                }, {
                    "data": "fltRemarks",
                    "name": "fltRemarks",
                    "autoWidth": true
                }, {
                    "data": "splitGender",
                    "name": "splitGender",
                    "autoWidth": true
                }, {
                    "data": "subManifest",
                    "name": "subManifest",
                    "autoWidth": true
                }, {
                    "data": "showRCS",
                    "name": "showRCS",
                    "autoWidth": true
                }, {
                    "data": "fltTSEdit",
                    "name": "fltTSEdit",
                    "autoWidth": true
                }, {
                    "data": "dest1",
                    "name": "dest1",
                    "autoWidth": true
                },
                {
                    "data": "dest2",
                    "name": "dest2",
                    "autoWidth": true
                }, {
                    "data": "fltStatus",
                    "name": "fltStatus",
                    "autoWidth": true
                }, {
                    "data": "pilot1",
                    "name": "pilot1",
                    "autoWidth": true
                }, {
                    "data": "pilot2",
                    "name": "pilot2",
                    "autoWidth": true
                },
                {
                    "data": "pilot2",
                    "name": "pilot2",
                    "autoWidth": true
                }, {
                    "data": "pilot3",
                    "name": "pilot3",
                    "autoWidth": true
                }, {
                    "data": "fA1",
                    "name": "fA1",
                    "autoWidth": true
                }, {
                    "data": "fA2",
                    "name": "fA2",
                    "autoWidth": true
                },
                {
                    "data": "fA3",
                    "name": "fA3",
                    "autoWidth": true
                },
                {
                    "data": "fA4",
                    "name": "fA4",
                    "autoWidth": true
                },
                {
                    "data": "customer",
                    "name": "customer",
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
                    "data": "fltTSEditAgent",
                    "name": "fltTSEditAgent",
                    "autoWidth": true
                },
                {
                    "data": "aircraft",
                    "name": "aircraft",
                    "autoWidth": true
                },
                

                
            ]
        }

    });

    // oTable = $(dt_TeamTarget).DataTable();

}