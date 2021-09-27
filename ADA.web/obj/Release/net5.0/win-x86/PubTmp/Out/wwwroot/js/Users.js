let baseApiUrl = "";
let baseWebUrl = "";
let btnUpdate = "#Edit";
let btnCloseForm = "#btnCancel";
let btnDelete = ".btnDelete";
let btnEdit = ".btnEdit";
let BaseUrl;
let formRole = "#formRole";
let dataTable = "#dt_User";
let hdUserId = "#hdUserId";
$(document).ready(function () {

    BaseUrl = $("#baseUrlForMVCAction").val();
    baseApiUrl = $("#baseApiUrl").val();
    baseWebUrl = $("#baseWebUrl").val();
    BaseUrl
    GetPageLoadData();
    $(document).on('click', btnEdit, function (e) {


        let id = $(e.currentTarget).data('id');


        GetUserDataID(id);


    });


    $(document).on('click', btnDelete, function (e) {
        let id = $(e.currentTarget).data('id');
        debugger;
        ChangeStatuUsers(Number(id));
    });
    






    $(btnUpdate).click(function () {

        UpdateUsers();
    });

});



function GetUserDataID(id) {


    postRequest(BaseUrl + "/DashBoard/GetUsersByID/" + id, null, function (res) {



        if (res.status == 200) {

            if (res.data != null || res.data != "") {



                $("#Edit").show();
                $("#EmpNum").val(res.data.empNum),
                    $("#StaffName").val(res.data.staffName),
                    $("#StaffSurname").val(res.data.staffSurname),
                    $("#StaffGrp").val(res.data.staffGrp).selectpicker("refresh"),
                    $("#ddlRoles").val(res.data.roleId).selectpicker("refresh"),
                    $("#StaffPwd").val(res.data.staffPwd),
                    $(hdUserId).val(res.data.staffID)

                if (res.data.staffRights) {
                    $("#StaffRightsActive").prop("checked", true);
                } else {
                    $("#StaffRightsActive").prop("checked", false);
                }

                if (res.data.superAdminRights) {
                    $("#StaffAdminRights").prop("checked", true);
                } else {
                    $("#StaffAdminRights").prop("checked", false);
                }
                if (res.data.staffActive) {
                    $("#chkIsActive").prop("checked", true);
                } else {
                    $("#chkIsActive").prop("checked", false);
                }

                $('html, body').animate({ scrollTop: 0 }, 400);
            }

        }
        if (res.status == 401) {
            
            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            //window.location.href = baseWebUrl + "Account/Authenticate";


        }
        if (res.status == 403) {

            
            swal(res.responseMsg, {
                icon: "error",
                title: "Error",
            });
        }
        if (res.status == 420) {
            
            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            //window.location.href = baseWebUrl + "Account/Authenticate";
        }
        if (res.status == 500) {
            

            swal({
                title: "Error",
                text: res.responseMsg,
                icon: "error",
                dangerMode: true,
            })
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


function GetAll() {

    //LoaderShow();

    $(dataTable).DataTable({

        "lengthChange": true,
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "pageLength": 10,
        "orderClasses": false,

        //"aaSorting": [[3, 'desc']],
        //"initComplete": function (settings, json) {
        //    HideKeys();
        //},
        "ajax": {
            "url": BaseUrl + "/DashBoard/GetAllUsers",
            "type": "POST",
            "datatype": "json",
            'beforeSend': function (request) {

            },
            "dataSrc": function (data) {
                if (data.status == 200) {
         

                }

                if (data.status == 401) {
                    
                    localStorage.removeItem("Menu");
                    localStorage.removeItem("userData");
                    //window.location.href = baseWebUrl + "Account/Authenticate";
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
                    //window.location.href = baseWebUrl + "Account/Authenticate";
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
                //
                //HideKeys();

               
                return data.data;

            }
        },

        //"columnDefs":
        //    [
        //        {
        //            "targets": [4],
        //            "visible": true,
        //            "searchable": false,
        //            "sortable": false
        //        }
        //    ],

        "columns": [

            { "data": "empNum", "name": "EmpNum", "autoWidth": true },
            { "data": "staffSurname", "name": "StaffSurname", "autoWidth": true },
            { "data": "staffName", "name": "StaffName", "autoWidth": true },
            {
                "data": "staffRights", "name": "StaffRights", "autoWidth": true,
                "render": function (data) {

                    if (data == false) {
                        return '0';
                    } else {
                        return '1';
                    }
                }
            },
            {
                "data": "superAdminRights", "name": "superAdminRights", "autoWidth": true,

                "render": function (data) {

                    if (data == false) {
                        return '0';
                    } else {
                        return '1';
                    }
                }

            },
            {
                "data": "staffActive", "name": "StaffActive", "autoWidth": true,

                "render": function (data) {

                    if (data == false) {
                        return '0';
                    } else {
                        return '1';
                    }
                }
            },
            { "data": "staffGrp", "name": "StaffGrp", "autoWidth": true },
    
   


            {
                "render": function (data, type, full, meta) {

                    if (full.staffActive)
                        return '<div class="btn-group btn-group-sm"><div class="d-flex"><a href="javascript:;" class="btn btn-primary shadow btn-xs sharp mr-1 btnEdit"  title="Edit" data-id="' + full.staffID + '"><i class="fa fa-pencil"></i></a><a href="javascript:;" class= "btn shadow btn-xs sharp mr-1  btnDelete" title="Mark as Deactive"  style="background: #9c3636;color: white;" data-id="' + full.staffID + '"> <i class="fa fa-times-circle" style="background: #9c3636;color: white;"></i></a></div>';
                    else
                        return '<div class="btn-group btn-group-sm"><div class="d-flex"><a href="javascript:;" class="btn btn-primary shadow btn-xs sharp mr-1  btnEdit" title="Edit" data-id="' + full.staffID + '"><i class="fa fa-pencil"></i></a><a href="javascript:;" class= "btn shadow btn-xs sharp mr-1  btnDelete"  title="Mark as Active" style="background: #28a745;color: white;" data-id="' + full.staffID + '"> <i class="fa fa-check-circle" style="background: #28a745;color: white;"></i></a></div>';

                }
            },


        ]

    })


}





function UpdateUsers() {

    let obj = {
        StaffID: $(hdUserId).val(),
        EmpNum: $("#EmpNum").val(),
        StaffSurname: $("#StaffSurname").val(),
        StaffName: $("#StaffName").val(),
        StaffPwd: $("#StaffPwd").val(),
        StaffGrp: $("#StaffGrp").val()[0],
        StaffRights: $("#StaffRightsActive").is(":checked"),
        StaffActive: $("#chkIsActive").is(":checked"),
        SuperAdminRights: $("#StaffAdminRights").is(":checked"),
        ModifiedOn: null,
        CreatedBy: 0
    };

   
   

        postRequest(BaseUrl + "/DashBoard/UpdateUsers", obj, function (res) {

            debugger
            if (res.status == 200) {
                if (res.data && res.data != null) {
                    debugger;

                    swal({
                        title: "Success",
                        text: res.responseMsg,
                        icon: "success",
                        dangerMode: false,
                    });
                    Clear();
                    $(dataTable).DataTable().destroy(); GetAll();

                }
            }
            if (res.status == 401) {
                
                localStorage.removeItem("Menu");
                localStorage.removeItem("userData");
                //window.location.href = baseWebUrl + "Account/Authenticate";
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
                //window.location.href = baseWebUrl + "Account/Authenticate";
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


function GetPageLoadData() {

    
         postRequest(BaseUrl + "/DashBoard/GetPageLoadData", null, function (res) {

            debugger
            if (res.status == 200) {
                if (res.data && res.data != null) {

                    fillData(res.data.sort(dynamicSort("roleName")), "#temp_Role", ddlRoles, true);

                    GetAll();
                }
            }
            if (res.status == 401) {
                
                localStorage.removeItem("Menu");
                localStorage.removeItem("userData");
                //window.location.href = baseWebUrl + "Account/Authenticate";
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
                //window.location.href = baseWebUrl + "Account/Authenticate";
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





function ChangeStatuUsers(Id) {



    swal({
        title: "Are You Sure?",
        text: "Do you want to change the status of this record?",
        icon: "warning",
        buttons: true,
        dangerMode: false,
    })
        .then((willDelete) => {

            if (willDelete) {
                debugger;
                postRequest(BaseUrl + "/DashBoard/ChangeStatus/" + Id, null, function (res) {
                    if (res.status == 200) {
                        

                        swal("Status has changed successfully!", {
                            icon: "success",
                            title: "Changed",
                        });

                        $(dataTable).DataTable().destroy(); GetAll();

                    }
                    if (res.status == 401) {
                        
                        localStorage.removeItem("Menu");
                        localStorage.removeItem("userData");
                        //window.location.href = baseWebUrl + "Account/Authenticate";

                    }
                    if (res.status == 403) {
                        
                        //HideLoader();
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
                        

                        //HideLoader();
                        localStorage.removeItem("Menu");
                        localStorage.removeItem("userData");
                        //window.location.href = baseWebUrl + "Account/Authenticate";
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
        });

}


//$(btnCancel).click(function () {
//    //to clear jquery validation error
//    var validator = $(formRole).validate();
//    validator.resetForm();
//    $(RolesSetup).hide("slow");
//    Clear();
//});


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


function Clear() {


        $("#Edit").hide();
        $("#EmpNum").val('');
        $("#StaffName").val('');
        $("#StaffSurname").val('');
        $("#StaffGrp").val('').selectpicker("refresh");
        $("#ddlRoles").val('').selectpicker("refresh");
        $("#StaffPwd").val('');
        $(hdUserId).val('0');
        $("#StaffRightsActive").prop("checked", false);
        $("#StaffAdminRights").prop("checked", false);
        $("#chkIsActive").prop("checked", false);
    

}



function isNullOrUndefined(value) {
    if (value == null || value == undefined || value == "undefined")
        return true;
    else
        return false;
}



function dynamicSort(property) {
    var sortOrder = 1;
    if (property[0] === "-") {
        sortOrder = -1;
        property = property.substr(1);
    }
    return function (a, b) {
        /* next line works with strings and numbers, 
         * and you may want to customize it to your needs
         */
        var result = (a[property] < b[property]) ? -1 : (a[property] > b[property]) ? 1 : 0;
        return result * sortOrder;
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

function DeleteRecord(id) {

    var validator = $(formRole).validate();
    validator.resetForm();
    $(RolesSetup).hide("slow");

    swal({
        title: "Are You Sure?",
        text: "Do you want to Delete  this record?",
        icon: "warning",
        buttons: true,
        buttons: ["No", "Yes"],
        showCancelButton: true,
        allowOutsideClick: false,
        confirmButtonText: "Yes",
        cancelButtonText: "No",
        dangerMode: false,
    })
        .then((willDelete) => {
            if (willDelete) {
               
                postRequest(BaseUrl + "/AdministratorModule/DeleteRoleRecord/" + id, null, function (res) {
                    if (res.status == 200) {
                        $(dataTable).DataTable().destroy(); GetAll();
                        
                        swal({
                            text: res.responseMsg,
                            icon: "success",
                            title: "Delete",
                        });





                    }
                    if (res.status == 401) {
                        
                        localStorage.removeItem("userData");
                        localStorage.removeItem("Menu");
                        //window.location.href = baseWebUrl + "Account/Authenticate";

                    }
                    if (res.status == 403) {
                        
                        swal({
                            title: "Error",
                            text: res.responseMsg,
                            icon: "error",
                            dangerMode: true,
                        });
                    }
                    if (res.status == 500) {
                        
                        swal({
                            title: "Error",
                            text: res.responseMsg,
                            icon: "error",
                            dangerMode: true,
                        });
                    }

                    if (res.status == 420) {
                        
                        localStorage.removeItem("userData");
                        localStorage.removeItem("Menu");
                        //window.location.href = baseWebUrl + "Account/Authenticate";
                    }

                    if (res.status == 600) {

                        swal({
                            title: "Error",
                            text: res.responseMsg,
                            icon: "error",
                            dangerMode: true,
                        });
                    }
                    
                });
            }
        });

}



