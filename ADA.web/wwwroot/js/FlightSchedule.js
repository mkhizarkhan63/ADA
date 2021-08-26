
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
        "FltStatus_Fk":  Number($(FlightStatus).val()),

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


function GetAllBranchTarget() {
    //DataTable
    LoaderShow();

    oTable = $(dt_TeamTarget).DataTable({
        //"responsive": true,
        "lengthChange": true,
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "pageLength": 10,
        "orderClasses": false,
        //"dom": '<"top"i>rt<"bottom"lp><"clear">',
        //"paging": !0,
        "aaSorting": [
            [11, 'desc']
        ],
        "initComplete": function (settings, json) {
            HideKeys();
        },

        "ajax": {
            "url": BaseUrl + "/GoalsModule/GetAllBranchTarget",
            "type": "POST",

            'beforeSend': function (request) {

            },
            "dataSrc": function (data) {
                if (data.Status == 200) {
                    console.log(data);
                    LoaderHide();
                    if (IsPageLoad) {
                        //GetAllProductsList();
                        IsPageLoad = false;

                    }

                }

                if (data.Status == 401) {
                    LoaderHide();
                    localStorage.removeItem("Menu");
                    localStorage.removeItem("userData");
                    window.location.href = baseWebUrl + "Account/Authenticate";
                }
                if (data.Status == 403) {
                    LoaderHide();
                    swal(data.ResponseMsg, {
                        icon: "error",
                        title: "Error",
                    });
                }

                if (data.Status == 420) {
                    LoaderHide();
                    localStorage.removeItem("Menu");
                    localStorage.removeItem("userData");
                    window.location.href = baseWebUrl + "Account/Authenticate";
                }

                if (data.Status == 500) {
                    LoaderHide();
                    swal({
                        title: "Error",
                        text: data.ResponseMsg,
                        icon: "error",
                        dangerMode: true,
                    })
                }

                if (data.Status == 600) {

                    swal({
                        title: "Error",
                        text: data.ResponseMsg,
                        icon: "error",
                        dangerMode: true,
                    })
                }
                LoaderHide();
                return data.Data;

            }
        },

        "columnDefs": [{
            "targets": [9],
            "visible": true,
            "searchable": false,
            "sortable": false
        },
        {
            "targets": [12],
            "visible": true,
            "searchable": false,
            "sortable": false
        }
        ],

        "columns": [
            {
                "data": "CustomId",
                "name": "CustomId",
                "autoWidth": true
            },

            //    {
            //    "data": "Id",
            //    "name": "Id",
            //    "autoWidth": true,
            //    "render": function (data) { return '<a href="javascript:;" class=" d-block" data-id="' + data + '">' + data + '</a>' }
            //},
            {
                "data": "CompanyName",
                "name": "CompanyName",
                "autoWidth": true
            }, {
                "data": "BranchName",
                "name": "BranchName",
                "autoWidth": true
            },
            {
                "data": "TargetYear",
                "name": "TargetYear",
                "autoWidth": true
            },
            {
                "data": "TargetType",
                "name": "TargetType",
                "autoWidth": true
            },


            {

                "data": "TargetDateRange",
                "name": "TargetDateRange",
                "autoWidth": true,
                "render": function (data) {

                    return data;
                }

            },
            {

                "data": "Amount",
                "name": "Amount",
                "autoWidth": true,
                "render": function (data) {
                    return formatCurrency(data);
                }

            },
            {
                "data": "NoOfVisits",
                "name": "NoOfVisits",
                "autoWidth": true
            },
            {
                "data": "ForcastAmount",
                "name": "ForcastAmount",
                "autoWidth": true,
                "render": function (data) {
                    return formatCurrency(data);
                }
            },




            {

                "render": function (data, type, full, meta) {
                    let html = '';
                    if (full.Products != null && full.Products.length > 0) {
                        html = fillDataWithReturnHtml(full.Products);
                    }
                    return html;
                }
            },


            {
                "data": "IsTeamAssigned",
                "name": "IsTeamAssigned",
                "autoWidth": true,
                "render": function (data) {
                    if (data) {
                        return '<h6><span class="badge badge-pill badge-primary">Yes</span></h6>'
                    } else {
                        return '<h6><span class="badge badge-pill badge-danger">No</span></h6>'
                    }

                }
            },
            //{
            //    "data": "IsTeamMemberAssigned", "name": "IsTeamMemberAssigned", "autoWidth": true,
            //    "render": function (data) {
            //        if (data) {
            //            return '<h6><span class="badge badge-pill badge-primary">Yes</span></h6>'
            //        } else {
            //            return '<h6><span class="badge badge-pill badge-danger">No</span></h6>'
            //        }

            //    }
            //},

            {
                "data": "ModifiedOn",
                "name": "ModifiedOn",
                "autoWidth": true,
                "render": function (data) {

                    return moment(data.replace(/\Z$/, '')).format('DD/MM/YYYY hh:mm:ss a');
                }
            },


            {
                "render": function (data, type, full, meta) {


                    return '<div class="btn-group btn-group-sm"><div class="d-flex"><a href="javascript:;" class="btn btn-primary shadow btn-xs sharp mr-1 btnTeamTargetEdit" title="Edit" data-id="' + full.Id + '"><i class="fa fa-pencil"></i></a></div>';

                }
            },


        ]

    }).on("draw.dt", function () {
        HideKeys();
    });

    // oTable = $(dt_TeamTarget).DataTable();



}