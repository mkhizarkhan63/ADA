let BaseUrl;
let btnEdit = ".btnEdit";
let Save = "#Save";
let btnUpdate = "#Edit";
let FltID = "#FltID";
let FltDateTime = "#ETD";
let FltNumber = "#FlightNumber";
let Dest1 = "#Dest1";
let Dest2 = "#Dest2";
let FltStatus = "#FlightStatus";
let FltRoute = "#Route";
let PilotID1 = "#Pilot1";
let PilotID2 = "#Pilot2";
let PilotID3 = "#Pilot3";
let FAID1 = "#FA1";
let FAID2 = "#FA2";
//let FAID3 = "#FAID3"
//let FAID4 = "#FAID4"
let CustId = "#Customer";
let RsrvdSeats = "#RsrvdSeats";
let SeatMap = "#SeatMap";
let Payload = "#MaxCargo";
let Fuel = "#Fuel";
let Temperature = "#Temperature";
let FwdCargo1 = "#FWDcargo1";
let FwdCargo2 = "#FWDcargo2";
let FwdCargo3 = "#FWDcargo3";
let FwdCargo4 = "#FWDcargo4";
let AftCargo1 = "#AFTcargo1";
let AftCargo2 = "#AFTcargo2";
let AftCargo3 = "#AFTcargo3";
let AftCargo4 = "#AFTcargo4";
let AftCargo5 = "#AFTcargo5";
let AftCargo6 = "#AFTcargo6";
let GateNum = "#GateNum";
let FltTimeStamp = "#FltTimeStamp";
let AgentID = "#Agent";
let ClosingAgentID = "#ClosingAgentID";
let ClosingTimeStamp = "#ClosingTimeStamp";
let ActualDepTime = "#ATD";
let FltRemarks = "#Remarks";
let SplitGender = "#SplitGender";
let ShowRCS = "#RCS";
let FltTSEdit = "#FltTSEdit";
let FltTSEditAgentID = "#FltTSEditAgentID";
let AircraftID = "#AircraftType";

var oTable;
var ddlAircraftType = "#ddlAircraftType";
var ClearFilter = "#ClearFilter";
var ApplyFilter = "#ApplyFilter";
var FromDate = "#FromDate";
var ToDate = "#ToDate";


$(document).ready(function () {




    if (localStorage.getItem("userData") != null) {


        if (JSON.parse(localStorage.getItem("userData")).superAdminRights != true) {

            $("#PermissionCheck").remove();
        }
    }




    $('html,body').animate({ scrollTop: 0 });


    BaseUrl = $("#baseUrlForMVCAction").val();
    if (BaseUrl == "null")
        BaseUrl = "";
    baseApiUrl = $("#baseApiUrl").val();

    baseWebUrl = $("#baseWebUrl").val();

   
    var today = new Date();
    var tomorrow = new Date();
    tomorrow.setDate(today.getDate() + 1)

    $(ETD).datetimepicker({
    
        format: 'MM/DD/yyy hh:mm a',

        minDate: tomorrow
       
    });
    $(FromDate).datetimepicker({

        format: 'MM/DD/yyy hh:mm a'

    });
    $(ToDate).datetimepicker({

        format: 'MM/DD/yyy hh:mm a'

    });
 

    $(".EtdImg").click(function () {
        $('#ETD').datetimepicker("show");
    });

    $(".EtdfromImg").click(function () {
        $('#FromDate').datetimepicker("show");
    });

    $(".EtdtoImg").click(function () {
        $('#ToDate').datetimepicker("show");
    })
   
    $("#Fuel").keypress(function (e) {
 
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
          
            return false;
        }
    });


    $("#MaxCargo").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#FWDcargo1").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#FWDcargo2").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#FWDcargo3").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#FWDcargo4").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#AFTcargo1").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#AFTcargo2").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#AFTcargo3").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#AFTcargo4").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#AFTcargo5").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#AFTcargo6").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#RsrvdSeats").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });

    $("#GateNumber").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });

    $("#Temperature").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });

    $("#ATD").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });


    $("#UsefulWeight1").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });

    $("#UsefulWeight2").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    
    $("#UsefulWeight3").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#UsefulWeightBeta1").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });

    $("#UsefulWeightBeta2").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });

    $("#UsefulWeightBeta3").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

            return false;
        }
    });
    $("#FlightNumber").on("keyup", function () {
        var valid = /^(?![\0-9-])[\w\s-]+$/.test(this.value),
            val = this.value;

        if (!valid) {
           
            this.value = val.substring(0, val.length - 1);
        }
    });
  

    $(Dest1).change(function () {
        debugger;
        $(Dest2).attr("disabled", false).selectpicker("refresh");

        var TextRoute = 'AUH-' + $('option:selected', this).attr('route');


        var route = $('option:selected', Dest2).attr('route2');

        if (route == undefined) {


            TextRoute = TextRoute;

        }
        else {


            TextRoute = (TextRoute + ("-" + $('option:selected', Dest2).attr('route2')) + '-AUH');
        }






        $(FltRoute).val(TextRoute);
    });


    $(Dest2).change(function () {

        debugger;
        var route1 = 'AUH-' + $('option:selected', Dest1).attr('route');

        var route = (route1 + ("-" + $('option:selected', this).attr('route2')) + '-AUH');



        $(FltRoute).val(route);
    });

    $("#ManifestColor1").change(function () {

        $("#ManifestColor2").attr("disabled", false).selectpicker("refresh");
        $("#UsefulWeight2").attr("disabled", false).selectpicker("refresh");

    });


    $("#ManifestColor2").change(function () {

        $("#ManifestColor3").attr("disabled", false).selectpicker("refresh");
        $("#UsefulWeight3").attr("disabled", false).selectpicker("refresh");

    });

    $("#ManifestColor3").change(function () {

        $("#UsefulWeightColor1").attr("disabled", false).selectpicker("refresh");
        $("#UsefulWeightBeta1").attr("disabled", false).selectpicker("refresh");

    });

    $("#UsefulWeightColor1").change(function () {

        $("#UsefulWeightColor2").attr("disabled", false).selectpicker("refresh");
        $("#UsefulWeightBeta2").attr("disabled", false).selectpicker("refresh");

    });

    $("#UsefulWeightColor2").change(function () {

        $("#UsefulWeightColor3").attr("disabled", false).selectpicker("refresh");
        $("#UsefulWeightBeta3").attr("disabled", false).selectpicker("refresh");

    });


    $("#Customer").change(function () {

        const paxList = $('option:selected', this).attr('usepaxlist');


        if (paxList == "false") {
            $("#PaxList").prop('checked', false);

        } else {

            $("#PaxList").prop('checked', true);
        }

    });


    $("#AircraftType").change(function () {

        debugger;

        let FWHOLD = $('option:selected', this).attr('fwhold');
        let AFTHOLD = $('option:selected', this).attr('afthold');


        if (Number(FWHOLD) == 0) {


            $("#FWDcargo1").val("").attr("disabled", true);
            $("#FWDcargo2").val("").attr("disabled", true);
            $("#FWDcargo3").val("").attr("disabled", true);
            $("#FWDcargo4").val("").attr("disabled", true);
           
        }

        if (Number(FWHOLD) == 1) {


            $("#FWDcargo1").val("").attr("disabled", false);
            $("#FWDcargo2").val("").attr("disabled", true);
            $("#FWDcargo3").val("").attr("disabled", true);
            $("#FWDcargo4").val("").attr("disabled", true);
                        

        }

        if (Number(FWHOLD) == 2) {


            $("#FWDcargo1").val("").attr("disabled", false);
            $("#FWDcargo2").val("").attr("disabled", false);
            $("#FWDcargo3").val("").attr("disabled", true);
            $("#FWDcargo4").val("").attr("disabled", true);

        }

        if (Number(FWHOLD) == 3) {


            $("#FWDcargo1").val("").attr("disabled", false);
            $("#FWDcargo2").val("").attr("disabled", false);
            $("#FWDcargo3").val("").attr("disabled", false);
            $("#FWDcargo4").val("").attr("disabled", true);

        }

        if (Number(FWHOLD) == 4) {


            $("#FWDcargo1").val("").attr("disabled", false);
            $("#FWDcargo2").val("").attr("disabled", false);
            $("#FWDcargo3").val("").attr("disabled", false);
            $("#FWDcargo4").val("").attr("disabled", false);

        }



        if (Number(AFTHOLD) == 0) {

            $("#AFTcargo1").val("").attr("disabled", true);
            $("#AFTcargo2").val("").attr("disabled", true);
            $("#AFTcargo3").val("").attr("disabled", true);
            $("#AFTcargo4").val("").attr("disabled", true);
            $("#AFTcargo5").val("").attr("disabled", true);
            $("#AFTcargo6").val("").attr("disabled", true);

        }

        if (Number(AFTHOLD) == 1) {

            $("#AFTcargo1").val("").attr("disabled", false);
            $("#AFTcargo2").val("").attr("disabled", true);
            $("#AFTcargo3").val("").attr("disabled", true);
            $("#AFTcargo4").val("").attr("disabled", true);
            $("#AFTcargo5").val("").attr("disabled", true);
            $("#AFTcargo6").val("").attr("disabled", true);


        }


        if (Number(AFTHOLD) == 2) {

            $("#AFTcargo1").val("").attr("disabled", false);
            $("#AFTcargo2").val("").attr("disabled", false);
            $("#AFTcargo3").val("").attr("disabled", true);
            $("#AFTcargo4").val("").attr("disabled", true);
            $("#AFTcargo5").val("").attr("disabled", true);
            $("#AFTcargo6").val("").attr("disabled", true);


        }

        if (Number(AFTHOLD) == 3) {

            $("#AFTcargo1").val("").attr("disabled", false);
            $("#AFTcargo2").val("").attr("disabled", false);
            $("#AFTcargo3").val("").attr("disabled", false);
            $("#AFTcargo4").val("").attr("disabled", true);
            $("#AFTcargo5").val("").attr("disabled", true);
            $("#AFTcargo6").val("").attr("disabled", true);


        }

        if (Number(AFTHOLD) == 4) {

            $("#AFTcargo1").val("").attr("disabled", false);
            $("#AFTcargo2").val("").attr("disabled", false);
            $("#AFTcargo3").val("").attr("disabled", false);
            $("#AFTcargo4").val("").attr("disabled", false);
            $("#AFTcargo5").val("").attr("disabled", true);
            $("#AFTcargo6").val("").attr("disabled", true);


        }

        if (Number(AFTHOLD) == 5) {

            $("#AFTcargo1").val("").attr("disabled", false);
            $("#AFTcargo2").val("").attr("disabled", false);
            $("#AFTcargo3").val("").attr("disabled", false);
            $("#AFTcargo4").val("").attr("disabled", false);
            $("#AFTcargo5").val("").attr("disabled", false);
            $("#AFTcargo6").val("").attr("disabled", true);


        }

        if (Number(AFTHOLD) == 6) {

            $("#AFTcargo1").val("").attr("disabled", false);
            $("#AFTcargo2").val("").attr("disabled", false);
            $("#AFTcargo3").val("").attr("disabled", false);
            $("#AFTcargo4").val("").attr("disabled", false);
            $("#AFTcargo5").val("").attr("disabled", false);
            $("#AFTcargo6").val("").attr("disabled", false);


        }



    });





    GetAllDropdown();

    $(document).on('click', btnEdit, function (e) {
        let id = $(e.currentTarget).data('id');
        GetFLightByID(id);
    });


    $(document).on('click', "#TopToBottom", function (e) {

        $('html,body').animate({ scrollTop: 980 }, 'slow');
    });


    $(document).on('change', "#ddlAircraftTypeFlightForm", function (e) {

        debugger;
        let value = e.currentTarget.value;

        Aircraft_Type(value);
    });


    $(Save).click(function () {
        debugger;


        AddFlight();

    });


    $(btnUpdate).click(function () {

        UpdateFlight();
    });



    $(ApplyFilter).click(function () {

        debugger;

        oTable.columns(0).search($(FromDate).val());
        oTable.columns(1).search($(ToDate).val());
        oTable.columns(2).search($(ddlAircraftType).val());

        oTable.draw();
    });

    $(ClearFilter).on('click', function () {
        $(FromDate).val('');
        $(ToDate).val('');
        $(ddlAircraftType).val('');
        oTable.search('').columns().search('').draw();
    })


});





function Aircraft_Type(value) {


    postRequest(BaseUrl + "/DashBoard/GetAircraftType?value="+value,null, function (res) {

     
        if (res.status == 200) {
            if (res.data && res.data != null) {

                debugger
                fillData(res.data.airCraft, '#temp_DropDownaircraft', AircraftID, true);
                fillData(res.data.pilot, '#temp_DropDownpilot1', PilotID1, true);
                fillData(res.data.pilot, '#temp_DropDownpilot1', PilotID2, true);
                fillData(res.data.pilot, '#temp_DropDownpilot1', PilotID3, true);
                fillData(res.data.staff, '#temp_DropDownFA1', FAID1, true);
                fillData(res.data.staff, '#temp_DropDownFA1', FAID2, true);
                fillData(res.data.staff, '#temp_DropDownAgent', AgentID, true);


                if (value == "RW") {

                    $("#ManifestColor1").attr("disabled", true).selectpicker("refresh");
                    $("#UsefulWeight1").attr("disabled", true).selectpicker("refresh");
                    $("#ManifestColor2").attr("disabled", true).selectpicker("refresh");
                    $("#UsefulWeight2").attr("disabled", true).selectpicker("refresh");
                    $("#ManifestColor3").attr("disabled", true).selectpicker("refresh");
                    $("#UsefulWeight3").attr("disabled", true).selectpicker("refresh");


                    $("#UsefulWeightColor1").attr("disabled", true).selectpicker("refresh");
                    $("#UsefulWeightBeta1").attr("disabled", true).selectpicker("refresh");
                    $("#UsefulWeightColor2").attr("disabled", true).selectpicker("refresh");
                    $("#UsefulWeightBeta2").attr("disabled", true).selectpicker("refresh");
                    $("#UsefulWeightColor3").attr("disabled", true).selectpicker("refresh");
                    $("#UsefulWeightBeta3").attr("disabled", true).selectpicker("refresh");
                    $("#Pilot3").attr("disabled", true).selectpicker("refresh");
                    $("#FA1").attr("disabled", true).selectpicker("refresh");
                    $("#FA2").attr("disabled", true).selectpicker("refresh");
                    $("#MaxCargo").text("Useful WT :")
                }
                else {

                    $("#ManifestColor1").attr("disabled", false).selectpicker("refresh");
                    $("#UsefulWeight1").attr("disabled", false).selectpicker("refresh");
                    $("#ManifestColor2").attr("disabled", false).selectpicker("refresh");
                    $("#UsefulWeight2").attr("disabled", false).selectpicker("refresh");
                    $("#ManifestColor3").attr("disabled", false).selectpicker("refresh");
                    $("#UsefulWeight3").attr("disabled", false).selectpicker("refresh");


                    $("#UsefulWeightColor1").attr("disabled", false).selectpicker("refresh");
                    $("#UsefulWeightBeta1").attr("disabled", false).selectpicker("refresh");
                    $("#UsefulWeightColor2").attr("disabled", false).selectpicker("refresh");
                    $("#UsefulWeightBeta2").attr("disabled", false).selectpicker("refresh");
                    $("#UsefulWeightColor3").attr("disabled", false).selectpicker("refresh");
                    $("#UsefulWeightBeta3").attr("disabled", false).selectpicker("refresh");
                    $("#Pilot3").attr("disabled", false).selectpicker("refresh");
                    $("#FA1").attr("disabled", false).selectpicker("refresh");
                    $("#FA2").attr("disabled", false).selectpicker("refresh");
                    $("#MaxCargo").text("Max Cargo :");
                }
               





            }
        }
        if (res.status == 401) {

            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Dashboard";
        
        }
        if (res.status == 403) {


            swal(res.responseMsg, {
                icon: "error",
                title: "Error",
            });
        }
        if (res.status == 500) {

            swal({
                title: "Error",
                text: res.responseMsg,
                icon: "error",
                dangerMode: true,
            })
        }

        if (res.status == 420) {

            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Dashboard";
        }

        if (res.status == 600) {

            swal({
                title: "Error",
                text: res.responseMsg,
                icon: "error",
                dangerMode: true,
            })
        }

    });


}



function GetAllDropdown() {


    postRequest(BaseUrl + "/DashBoard/GetAllDropdown", null, function (res) {




        debugger
        if (res.status == 200)
            if (res.data && res.data != null) {




                fillData(res.data.destination, '#temp_DropDowndest1', Dest1, true);
                fillData(res.data.destination, '#temp_DropDowndest2', Dest2, true);
                fillData(res.data.airCraft, '#temp_DropDownaircraft', AircraftID, true);
                fillData(res.data.pilot, '#temp_DropDownpilot1', PilotID1, true);
                fillData(res.data.pilot, '#temp_DropDownpilot1', PilotID2, true);
                fillData(res.data.pilot, '#temp_DropDownpilot1', PilotID3, true);
                fillData(res.data.staff, '#temp_DropDownFA1', FAID1, true);
                fillData(res.data.staff, '#temp_DropDownFA1', FAID2, true);
                fillData(res.data.staff, '#temp_DropDownAgent', AgentID, true);
                fillData(res.data.customer, '#temp_DropDowncustomer', CustId, true);
                $(ETD).val("");
                GetAllFlight();

            }
        if (res.status == 401) {
           
            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Dashboard";
        }
        if (res.status == 403) {


            swal(res.responseMsg, {
                icon: "error",
                title: "Error",
            });
        }
        if (res.status == 500) {
           
            swal({
                title: "Error",
                text: res.responseMsg,
                icon: "error",
                dangerMode: true,
            })
        }

        if (res.status == 420) {

            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Dashboard";

        }

        if (res.status == 600) {

            swal({
                title: "Error",
                text: res.responseMsg,
                icon: "error",
                dangerMode: true,
            })
        }

    });


}


function GetAllFlight() {

    oTable = $("#FlightTable").DataTable({
        "responsive": true,
        "lengthChange": true,
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "pageLength": 10,
        "orderClasses": false,
        "aaSorting": [
            [0, 'desc']
        ],
        //"initComplete": function (settings, json) {
        //    HideKeys();
        //},

        "ajax": {
            "url": BaseUrl + "/DashBoard/GetAllFlights",
            "type": "POST",
            "dataType": "json",

            "dataSrc": function (data) {

                debugger;
                if (data.status == 200) {
                    debugger;
                    //GetAllDropdown();
                }

                if (data.status == 401) {

                    window.location.href = baseWebUrl + "Dashboard";
                }
                if (data.status == 403) {

                    swal(data.responseMsg, {
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
                        text: data.responseMsg,
                        icon: "error",
                        dangerMode: true,
                    })
                }

                if (data.status == 600) {

                    swal({
                        title: "Error",
                        text: data.responseMsg,
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

            {
                "data": "etd",
                "name": "etd",
                "autoWidth": true,
                "render": function (data) {

                    return moment(data.replace(/\Z$/, '')).format('MM/DD/yyy hh:mm ');
                }
            },
            {
                "data": "fltNumber",
                "name": "fltNumber",
                "autoWidth": true
            },
            {
                "data": "destination",
                "name": "destination",
                "autoWidth": true
            },
            {
                "data": "destination2",
                "name": "destination2",
                "autoWidth": true
            },
            {
                "data": "status",
                "name": "status",
                "autoWidth": true
            },
            {
                "data": "aircraft",
                "name": "aircraft",
                "autoWidth": true
            },
            {
                "data": "color",
                "name": "color",
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
                "data": "gateNum",
                "name": "gateNum",
                "autoWidth": true
            },
            {
                "data": "rsrvdSeats",
                "name": "rsrvdSeats",
                "autoWidth": true
            },

            {
                "data": "custCode",
                "name": "custCode",
                "autoWidth": true
            },
            {
                "data": "usePaxList",
                "name": "usePaxList",
                "autoWidth": true,
                "render": function (data) {

                    if (data == false) {
                        return '0';
                    } else {
                        return '1';
                    }
                }
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
                "data": "fltTimeStamp",
                "name": "fltTimeStamp",
                "autoWidth": true,
                "render": function (data) {

                    return data == null ? "" : moment(data.replace(/\Z$/, '')).format('MM/DD/YYYY hh:mm ');
                }
            },
            {
                "data": "agent",
                "name": "agent",
                "autoWidth": true
            },
           
            {
                "data": "closingAgentID",
                "name": "closingAgentID",
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
                "data": "seatMap",
                "name": "seatMap",
                "autoWidth": true,
                "render": function (data) {

                    if (data == false) {
                        return '0';
                    } else {
                        return '1';
                    }
                }
            },

            {
                "data": "fltRemarks",
                "name": "fltRemarks",
                "autoWidth": true
            },

            {
                "data": "splitGender",
                "name": "splitGender",
                "autoWidth": true,
                "render": function (data) {

                    if (data == false) {
                        return '0';
                    } else {
                        return '1';
                    }
                }
            },
            {
                "data": "subManifestColor",
                "name": "subManifestColor",
                "autoWidth": true
            },
            {
                "data": "showRCS",
                "name": "showRCS",
                "autoWidth": true,
                "render": function (data) {

                    if (data == false) {
                        return '0';
                    } else {
                        return '1';
                    }
                }

            },
            {
                "render": function (data, type, full, meta) {

                    return '<div class="btn-group btn-group-sm"><div class="d-flex"><a href="javascript:;" class="btn btn-primary shadow btn-xs sharp mr-1 btnEdit"  title="Edit" data-id="' + full.fltID + '"><i class="fa fa-pencil"></i></a></div>';


                }
            },




        ]


    });
}



function GetFLightByID(id) {

    var validator = $("#formFlight").validate();
    validator.resetForm();

    postRequest(BaseUrl + "/DashBoard/GetFLightByID/" + id, null, function (res) {

        debugger
        if (res.status == 200) {
            if (res.data && res.data != null) {


               var CW= res.data.subManifestColor.split(/([0-9,]+)/);


                $("#Save").hide();
                $("#Edit").show();

                $("#ManifestColor1").val(CW[0].split(',')[0]).selectpicker("refresh");
                $("#UsefulWeight1").val(CW[1].split(',')[0]).selectpicker("refresh");
                $("#ManifestColor2").val(CW[2].split(',')[0]).attr("disabled",false).selectpicker("refresh");
                $("#UsefulWeight2").val(CW[3].split(',')[0]).attr("disabled", false);
                $("#ManifestColor3").val(CW[4].split(',')[0]).attr("disabled", false).selectpicker("refresh");
                $("#UsefulWeight3").val(CW[5].split(',')[0]).attr("disabled", false)


                $("#UsefulWeightColor1").val(CW[6].split(',')[0]).attr("disabled", false).selectpicker("refresh");
                $("#UsefulWeightBeta1").val(CW[7].split(',')[0]).attr("disabled", false).selectpicker("refresh");
                $("#UsefulWeightColor2").val(CW[8].split(',')[0]).attr("disabled", false).selectpicker("refresh");
                $("#UsefulWeightBeta2").val(CW[9].split(',')[0]).attr("disabled", false);
                $("#UsefulWeightColor3").val(CW[10].split(',')[0]).attr("disabled", false).selectpicker("refresh");
                $("#UsefulWeightBeta3").val(CW[11].split(',')[0]).attr("disabled", false)

                $("#FltID").val(res.data.fltID);
                $("#ETD").val(moment(res.data.etd.replace(/\Z$/, '')).format('MM/DD/yyy hh:mm a'));
                $("#FlightNumber").val(res.data.fltNumber);
                $("#SeatMap").prop("checked", res.data.seatMap);
                $("#Dest1").val(res.data.destID).selectpicker("refresh");
                $("#Dest2").val(res.data.destID2).attr("disabled", false).selectpicker("refresh");
                $("#AircraftType").val(res.data.aircraftID).selectpicker("refresh").change();
                $("#RCS").prop("checked", res.data.showRCS);
                $("#FlightColor1").val(res.data.color.split(',')[0]).selectpicker("refresh");
                $("#FlightColor2").val(res.data.color.split(',')[1]).selectpicker("refresh");
                $("#Route").val(res.data.fltRoute);
                $("#Pilot1").val(res.data.pilot_ID1).selectpicker("refresh");
                $("#Pilot2").val(res.data.pilot_ID2).selectpicker("refresh");
                $("#Pilot3").val(res.data.pilot_ID3).selectpicker("refresh");
                $("#FA1").val(res.data.fA_ID1).selectpicker("refresh");
                $("#FA2").val(res.data.fA_ID2).selectpicker("refresh");
                $("#Customer").val(res.data.custID).selectpicker("refresh");
                $("#PaxList").prop("checked", res.data.usePaxList);
                $("#Fuel").val(res.data.fuel);
                $("#SplitGender").prop("checked", res.data.splitGender);
                $("#MaxCargo").val(res.data.payload);
                $("#Temperature").val(res.data.temperature);
                $("#RsrvdSeats").val(res.data.rsrvdSeats);
                $("#GateNumber").val(res.data.gateNum);
                //$(Frt).val("");
                //$(Bag).val("");
                //$(FrtBagTotal).val("");
                $("#FWDcargo1").val(res.data.fwdCargo1);
                $("#FWDcargo2").val(res.data.fwdCargo2);
                $("#FWDcargo3").val(res.data.fwdCargo3);
                $("#FWDcargo4").val(res.data.fwdCargo4);
                $("#AFTcargo1").val(res.data.aftCargo1);
                $("#AFTcargo2").val(res.data.aftCargo2);
                $("#AFTcargo3").val(res.data.aftCargo3);
                $("#AFTcargo4").val(res.data.aftCargo4);
                $("#AFTcargo5").val(res.data.aftCargo5);
                $("#AFTcargo6").val(res.data.aftCargo6);
                $("#FlightStatus").val(res.data.status).selectpicker("refresh");
                $("#Agent").val(res.data.agentID).selectpicker("refresh");
                $("#ATD").val(res.data.actualDepTime);
                $("#Remarks").val(res.data.fltRemarks);

                $('html,body').animate({ scrollTop: 950 }, 'slow');
    

            }
        }
        if (res.status == 401) {

            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Dashboard";
        }
        if (res.status == 403) {


            swal(res.responseMsg, {
                icon: "error",
                title: "Error",
            });
        }
        if (res.status == 500) {
           
            swal({
                title: "Error",
                text: res.responseMsg,
                icon: "error",
                dangerMode: true,
            })
        }

        if (res.status == 420) {
           
            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Dashboard";
        }

        if (res.status == 600) {

            swal({
                title: "Error",
                text: res.responseMsg,
                icon: "error",
                dangerMode: true,
            })
        }

    });


}

function AddFlight() {

    if ($("#formFlight").valid()) {
        var MinifestColorCombineStringValues = ($("#ManifestColor1").val() == "" || $("#ManifestColor1").val() == null ? "---" : $("#ManifestColor1").val()) + ($("#UsefulWeight1").val() == "" || $("#UsefulWeight1").val() == null ? "0" : $("#UsefulWeight1").val()) + "," + ($("#ManifestColor2").val() == "" || $("#ManifestColor2").val() == null ? "---" : $("#ManifestColor2").val()) + ($("#UsefulWeight2").val() == "" || $("#UsefulWeight2").val() == null ? "0" : $("#UsefulWeight2").val()) + "," + ($("#ManifestColor3").val() == "" || $("#ManifestColor3").val() == null ? "---" : $("#ManifestColor3").val()) + ($("#UsefulWeight3").val() == "" || $("#UsefulWeight3").val() == null ? "0" : $("#UsefulWeight3").val()) + "," + ($("#UsefulWeightColor1").val() == "" || $("#UsefulWeightColor1").val() == null ? "---" : $("#UsefulWeightColor1").val()) + ($("#UsefulWeightBeta1").val() == "" || $("#UsefulWeightBeta1").val() == null ? "0" : $("#UsefulWeightBeta1").val()) + "," + ($("#UsefulWeightColor2").val() == "" || $("#UsefulWeightColor2").val() == null ? "---" : $("#UsefulWeightColor2").val()) + ($("#UsefulWeightBeta2").val() == "" || $("#UsefulWeightBeta2").val() == null ? "0" : $("#UsefulWeightBeta2").val()) + "," + ($("#UsefulWeightColor3").val() == "" || $("#UsefulWeightColor3").val() == null ? "---" : $("#UsefulWeightColor3").val()) + ($("#UsefulWeightBeta3").val() == "" || $("#UsefulWeightBeta3").val() == null ? "0" : $("#UsefulWeightBeta3").val());


        var data = {
            FltID: 0,
            "ETD": moment($(FltDateTime).val()).format("YYYY-MM-DD hh:mm:ss"),
            "FltNumber": $(FltNumber).val(),
            "SeatMap": $(SeatMap).is(":checked"),
            "DestID": Number($(Dest1).val()),
            "DestID2": Number($(Dest2).val()),
            "AircraftID": Number($(AircraftID).val()),
            "ShowRCS": $(ShowRCS).is(":checked"),
            "Color": ($("#FlightColor1").val() == "" || $("#FlightColor1").val() == null ? "," : $("#FlightColor1").val()) + ($("#FlightColor2").val() == "" || $("#FlightColor2").val() == null ? "," : "," + $("#FlightColor2").val() + ","),
            "FltRoute": $(FltRoute).val(),
            "SubManiFestColor": MinifestColorCombineStringValues,
            "Pilot_ID1": Number($(PilotID1).val()),
            "Pilot_ID2": Number($(Pilot2).val()),
            "Pilot_ID3": Number($(PilotID3).val()),
            "FA_ID1": Number($(FAID1).val()),
            "FA_ID2": Number($(FAID2).val()),
            "CustID": Number($(CustId).val()),
            "Fuel": Number($(Fuel).val()),
            "SplitGender": $(SplitGender).is(":checked"),
            "Payload": Number($(Payload).val()),
            "Temperature": Number($(Temperature).val()),
            "RsrvdSeats": Number($(RsrvdSeats).val()),
            "GateNum": Number($(GateNumber).val()),
            "Status": $(FltStatus).val(),
            "FwdCargo1": Number($(FwdCargo1).val()),
            "FwdCargo2": Number($(FwdCargo2).val()),
            "FwdCargo3": Number($(FwdCargo3).val()),
            "FwdCargo4": Number($(FwdCargo4).val()),
            "AftCargo1": Number($(AftCargo1).val()),
            "AftCargo2": Number($(AftCargo2).val()),
            "AftCargo3": Number($(AftCargo3).val()),
            "AftCargo4": Number($(AftCargo4).val()),
            "AftCargo5": Number($(AftCargo5).val()),
            "AftCargo6": Number($(AftCargo6).val()),
            "AgentID": Number($(AgentID).val()),
            "ActualDepTime": Number($(ActualDepTime).val()),
            "FltRemarks": $(FltRemarks).val(),



        };
        debugger;
        postRequest(BaseUrl + "/DashBoard/AddFlight", data, function (res) {
            debugger
            if (res.status == 200) {
                if (res.data && res.data != null) {


                    swal({
                        title: "Success",
                        text: "Submission was successful.",
                        icon: "success",
                        dangerMode: false,
                    });
                    ClearAllFields();
                    $("#FlightTable").DataTable().destroy(); GetAllFlight();
                }
            }
            if (res.status == 401) {

                localStorage.removeItem("Menu");
                localStorage.removeItem("userData");
                window.location.href = baseWebUrl + "Dashboard";
            }
            if (res.status == 403) {


                swal(res.responseMsg, {
                    icon: "error",
                    title: "Error",
                });
            }
            if (res.status == 500) {

                swal({
                    title: "Error",
                    text: res.responseMsg,
                    icon: "error",
                    dangerMode: true,
                })
            }

            if (res.status == 420) {

                localStorage.removeItem("Menu");
                localStorage.removeItem("userData");
                window.location.href = baseWebUrl + "Dashboard";
            }

            if (res.status == 600) {

                swal({
                    title: "Error",
                    text: res.responseMsg,
                    icon: "error",
                    dangerMode: true,
                })
            }

        });
    }

}

function UpdateFlight() {



  
    if ($("#formFlight").valid()) {

        var MinifestColorCombineStringValues = ($("#ManifestColor1").val() == "" || $("#ManifestColor1").val() == null ? "---" : $("#ManifestColor1").val()) + ($("#UsefulWeight1").val() == "" || $("#UsefulWeight1").val() == null ? "0" : $("#UsefulWeight1").val()) + "," + ($("#ManifestColor2").val() == "" || $("#ManifestColor2").val() == null ? "---" : $("#ManifestColor2").val()) + ($("#UsefulWeight2").val() == "" || $("#UsefulWeight2").val() == null ? "0" : $("#UsefulWeight2").val()) + "," + ($("#ManifestColor3").val() == "" || $("#ManifestColor3").val() == null ? "---" : $("#ManifestColor3").val()) + ($("#UsefulWeight3").val() == "" || $("#UsefulWeight3").val() == null ? "0" : $("#UsefulWeight3").val()) + "," + ($("#UsefulWeightColor1").val() == "" || $("#UsefulWeightColor1").val() == null ? "---" : $("#UsefulWeightColor1").val()) + ($("#UsefulWeightBeta1").val() == "" || $("#UsefulWeightBeta1").val() == null ? "0" : $("#UsefulWeightBeta1").val()) + "," + ($("#UsefulWeightColor2").val() == "" || $("#UsefulWeightColor2").val() == null ? "---" : $("#UsefulWeightColor2").val()) + ($("#UsefulWeightBeta2").val() == "" || $("#UsefulWeightBeta2").val() == null ? "0" : $("#UsefulWeightBeta2").val()) + "," + ($("#UsefulWeightColor3").val() == "" || $("#UsefulWeightColor3").val() == null ? "---" : $("#UsefulWeightColor3").val()) + ($("#UsefulWeightBeta3").val() == "" || $("#UsefulWeightBeta3").val()==null ? "0" : $("#UsefulWeightBeta3").val());

        var data = {
            FltID: Number($("#FltID").val()),
            "ETD": moment($(FltDateTime).val()).format("YYYY-MM-DD hh:mm:ss"),
            "FltNumber": $(FltNumber).val(),
            "SeatMap": $(SeatMap).is(":checked"),
            "DestID": Number($(Dest1).val()),
            "DestID2": Number($(Dest2).val()),
            "AircraftID": Number($(AircraftID).val()),
            "ShowRCS": $(ShowRCS).is(":checked"),
            "Color": ($("#FlightColor1").val() == "" || $("#FlightColor1").val() == null ? "," : $("#FlightColor1").val()) + ($("#FlightColor2").val() == "" || $("#FlightColor2").val()==null ? "," : "," + $("#FlightColor2").val() + ","),
            "FltRoute": $(FltRoute).val(),
            "SubManiFestColor": MinifestColorCombineStringValues,
            "Pilot_ID1": Number($(PilotID1).val()),
            "Pilot_ID2": Number($(Pilot2).val()),
            "Pilot_ID3": Number($(PilotID3).val()),
            "FA_ID1": Number($(FAID1).val()),
            "FA_ID2": Number($(FAID2).val()),
            "CustID": Number($(CustId).val()),
            "Fuel": Number($(Fuel).val()),
            "SplitGender": $(SplitGender).is(":checked"),
            "Payload": Number($(Payload).val()),
            "Temperature": Number($(Temperature).val()),
            "RsrvdSeats": Number($(RsrvdSeats).val()),
            "GateNum": Number($(GateNumber).val()),
            "Status": $(FltStatus).val(),
            "FwdCargo1": Number($(FwdCargo1).val()),
            "FwdCargo2": Number($(FwdCargo2).val()),
            "FwdCargo3": Number($(FwdCargo3).val()),
            "FwdCargo4": Number($(FwdCargo4).val()),
            "AftCargo1": Number($(AftCargo1).val()),
            "AftCargo2": Number($(AftCargo2).val()),
            "AftCargo3": Number($(AftCargo3).val()),
            "AftCargo4": Number($(AftCargo4).val()),
            "AftCargo5": Number($(AftCargo5).val()),
            "AftCargo6": Number($(AftCargo6).val()),
            "AgentID": Number($(AgentID).val()),
            "ActualDepTime": Number($(ActualDepTime).val()),
            "FltRemarks": $(FltRemarks).val(),

        }

            postRequest(BaseUrl + "/DashBoard/UpdateFlight", data, function (res) {

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
                        ClearAllFields();
                        /*$("#FlightTable").DataTable().destroy(); GetAllFlight();*/
                        $('#FlightTable').DataTable().ajax.reload();
                       
                    }
                }
                if (res.status == 401) {

                    localStorage.removeItem("Menu");
                    localStorage.removeItem("userData");
                    window.location.href = baseWebUrl + "Dashboard";
                }
                if (res.status == 403) {


                    swal(res.responseMsg, {
                        icon: "error",
                        title: "Error",
                    });
                }
                if (res.status == 500) {

                    swal({
                        title: "Error",
                        text: res.responseMsg,
                        icon: "error",
                        dangerMode: true,
                    })
                }

                if (res.status == 420) {

                    localStorage.removeItem("Menu");
                    localStorage.removeItem("userData");
                    window.location.href = baseWebUrl + "Dashboard";
                }

                if (res.status == 600) {

                    swal({
                        title: "Error",
                        text: res.responseMsg,
                        icon: "error",
                        dangerMode: true,
                    })
                }

            });

        } 


}


$("#formFlight").validate({
    //errorClass: "alert alert-danger text-center errorClass",
    /*rrorElement: "div",*/

    rules: {
        ETD: {
            required: true,

        },
        FlightNumber: {
            required: true,

        },
    },
    messages: {

    },
    highlight: function (element) {
        $(element).parent().addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).parent().removeClass('has-error');
    },
    errorElement: 'span',
    errorClass: 'validation-error-message help-block form-helper bold',
    errorPlacement: function (error, element) {
        if (element.parent('.input-group').length) {
            error.insertAfter(element.parent());
        } else {
            error.insertAfter(element);
        }
    }
    
});


function postRequest(url, requestData, handledata) {
    $.ajax({
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        dataType: "json",
        url: url,
        headers: {

        },

        data: JSON.stringify(requestData),
        success: function (data, textstatus, xhr) {
            handledata(data);
        },
        error: function (xhr, textstatus, errorThrown) {
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


$("#Clear").click(function () {


    ClearAllFields();

})

function ClearAllFields() {

    var validator = $("#formFlight").validate();
    validator.resetForm();

    $("#Save").show();
    $("#Edit").hide();

    $("#ManifestColor1").val("0").selectpicker("refresh");
    $("#UsefulWeight1").val("0").selectpicker("refresh");
    $("#ManifestColor2").val("0").attr("disabled", true).selectpicker("refresh");
    $("#UsefulWeight2").val("0").attr("disabled", true);
    $("#ManifestColor3").val("0").attr("disabled", true).selectpicker("refresh");
    $("#UsefulWeight3").val("0").attr("disabled", true);


    $("#UsefulWeightColor1").val("0").attr("disabled", true).selectpicker("refresh");
    $("#UsefulWeightBeta1").val("0").attr("disabled", true).selectpicker("refresh");
    $("#UsefulWeightColor2").val("0").attr("disabled", true).selectpicker("refresh");
    $("#UsefulWeightBeta2").val("0").attr("disabled", true);
    $("#UsefulWeightColor3").val("0").attr("disabled", true).selectpicker("refresh");
    $("#UsefulWeightBeta3").val("0").attr("disabled", true);

    $("#FltID").val("0");
    $("#ETD").val("");
    $("#FlightNumber").val("");
    $("#SeatMap").prop("checked", false);
    $("#Dest1").val("0").selectpicker("refresh");
    $("#Dest2").val("0").attr("disabled", true).selectpicker("refresh");
    $("#AircraftType").val("0").selectpicker("refresh");
    $("#RCS").prop("checked", false);
    $("#FlightColor1").val("0");
    $("#FlightColor2").val("0");
    $("#Route").val("");
    $("#Pilot1").val("0").selectpicker("refresh");
    $("#Pilot2").val("0").selectpicker("refresh");
    $("#Pilot3").val("0").selectpicker("refresh");
    $("#FA1").val("0").selectpicker("refresh");
    $("#FA2").val("0").selectpicker("refresh");
    $("#Customer").val("0").selectpicker("refresh");
    $("#PaxList").prop("checked", false);
    $("#Fuel").val("");
    $("#SplitGender").prop("checked", false);
    $("#MaxCargo").val('0');
    $("#Temperature").val("");
    $("#RsrvdSeats").val("");
    $("#GateNumber").val("");
    //$(Frt).val("");
    //$(Bag).val("");
    //$(FrtBagTotal).val("");
    $("#FWDcargo1").val("0");
    $("#FWDcargo2").val("0");
    $("#FWDcargo3").val("0");
    $("#FWDcargo4").val("0");
    $("#AFTcargo1").val("0");
    $("#AFTcargo2").val("0");
    $("#AFTcargo3").val("0");
    $("#AFTcargo4").val("0");
    $("#AFTcargo5").val("0");
    $("#AFTcargo6").val("0");
    $("#FlightStatus").val("0").selectpicker("refresh");
    $("#Agent").val("0").selectpicker("refresh");
    $("#ATD").val("");
    $("#Remarks").val("");

}