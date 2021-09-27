let baseApiUrl = "";
let baseWebUrl = "";
let btnSave = "#btnSave";
let btnUpdate = "#Edit";
let btnCloseForm = "#btnCancel";
let btnDelete = ".btnDelete";
let btnEdit = ".btnEdit";
let dataTable = "#dt_Role";
let hdRoleId = "#hdRoleId";
let txtRoleName = "#txtRoleName";
let btnCancel = "#btnCancel";
let chkIsActive = "#chkIsActive";
let RolesSetup = "#RolesSetup";
let BaseUrl;
let formRole = "#formRole";
let btnDeleteRecord = ".btnDeleteRecord";

$(document).ready(function () {

    BaseUrl = $("#baseUrlForMVCAction").val();
    baseApiUrl = $("#baseApiUrl").val();
    baseWebUrl = $("#baseWebUrl").val();


    GetAll();

    $(document).on('click', btnEdit, function (e) {


        let id = $(e.currentTarget).data('id');


        GetRoleByID(id);


    });


    $(document).on('click', btnDelete, function (e) {
        let id = $(e.currentTarget).data('id');
        Delete(id);
    });
    

    //$(btnShowForm).click(function () {

    //    $(RolesSetup).show("slow");
    //});
    //$(btnCancel).click(function () {
    //    
    //    $(RolesSetup).hide("slow");
    //});

    $(document).on('click', "#Clear", function (e) {

        Clear();
    });


    $(Save).click(function () {

        AddRole();

    });


    $(btnUpdate).click(function () {

        UpdateRole();
    });

});



function GetRoleByID(id) {


    postRequest(BaseUrl + "/DashBoard/GetRoleByID/" + id, null, function (res) {



        if (res.status == 200) {

            if (res.data != null || res.data != "") {


                $("#Save").hide();
                $("#Edit").show();
                $(hdRoleId).val(res.data.id)

                var RoleId = $(hdRoleId).val();

                if (RoleId != null) {

                    $(txtRoleName).val(res.data.roleName);

                    if (res.data.active) {
                        $(chkIsActive).prop("checked", true);
                    } else {
                        $(chkIsActive).prop("checked", false);
                    }

                    $('html, body').animate({ scrollTop: 0 }, 400);
                }

               
            }

         

        }
        if (res.status == 401) {
            
            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Account/Authenticate";


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
            window.location.href = baseWebUrl + "Account/Authenticate";
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

        "aaSorting": [[3, 'desc']],
        //"initComplete": function (settings, json) {
        //    HideKeys();
        //},
        "ajax": {
            "url": BaseUrl + "/DashBoard/GetAllRoles",
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
                    window.location.href = baseWebUrl + "Account/Authenticate";
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
                    window.location.href = baseWebUrl + "Account/Authenticate";
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

        "columnDefs":
            [
                {
                    "targets": [4],
                    "visible": true,
                    "searchable": false,
                    "sortable": false
                }
            ],

        "columns": [
            {
                "data": "id", "name": "id", "autoWidth": true},
            { "data": "roleName", "name": "roleName", "autoWidth": true },
           
            
            {
                "data": "active", "name": "active", "autoWidth": true,
                "render": function (data) {
                    if (data) {
                        return '<h6><span class="badge badge-pill badge-primary">Yes</span></h6>'
                    } else {
                        return '<h6><span class="badge badge-pill badge-danger">No</span></h6>'
                    }

                }
            },



            {
                "data": "modifiedOn", "name": "modifiedOn", "autoWidth": true,
                "render": function (data) {
                    return moment(data.replace(/\Z$/, '')).format('DD/MM/YYYY hh:mm:ss a');
                }
            },


            {
                "render": function (data, type, full, meta) {

                    if (full.active)
                        return '<div class="btn-group btn-group-sm"><div class="d-flex"><a href="javascript:;" class="btn btn-primary shadow btn-xs sharp mr-1 btnEdit"  title="Edit" data-id="' + full.id + '"><i class="fa fa-pencil"></i></a><a href="javascript:;" class= "btn shadow btn-xs sharp mr-1  btnDelete" title="Mark as Deactive"  style="background: #9c3636;color: white;" data-id="' + full.id + '"> <i class="fa fa-times-circle" style="background: #9c3636;color: white;"></i></a></div>';
                    else
                        return '<div class="btn-group btn-group-sm"><div class="d-flex"><a href="javascript:;" class="btn btn-primary shadow btn-xs sharp mr-1  btnEdit" title="Edit" data-id="' + full.id + '"><i class="fa fa-pencil"></i></a><a href="javascript:;" class= "btn shadow btn-xs sharp mr-1  btnDelete"  title="Mark as Active" style="background: #28a745;color: white;" data-id="' + full.id + '"> <i class="fa fa-check-circle" style="background: #28a745;color: white;"></i></a></div>';

                }
            },


        ]

    })//.on("draw.dt", function () {
    //    HideKeys();
    //});


}




function AddRole() {
    let obj = {
        Id: 0,
        RoleName: $(txtRoleName).val(),
        Active: $(chkIsActive).is(":checked"),
        ModifiedOn: null,
        CreatedBy: 0
    };

    postRequest(BaseUrl + "/DashBoard/AddRole", obj, function (res) {
        debugger
        if (res.status == 200) {
            if (res.data && res.data != null) {

                swal({
                    title: "Success",
                    text: res.responseMsg,
                    icon: "success",
                    dangerMode: false,
                });

                Clear();
                $(dataTable).DataTable().ajax.reload();

            }
        }
        if (res.status == 401) {
            
            localStorage.removeItem("Menu");
            localStorage.removeItem("userData");
            window.location.href = baseWebUrl + "Account/Authenticate";
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
            window.location.href = baseWebUrl + "Account/Authenticate";
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

function UpdateRole() {

    let obj = {
        Id: 0,
        RoleName: $(txtRoleName).val(),
        Active: $(chkIsActive).is(":checked"),
        ModifiedOn: null,
        CreatedBy: 0
    };

    const Id = $(hdRoleId).val();
    if (Id > 0) {

        obj.Id = Id;

        postRequest(BaseUrl + "/DashBoard/UpdateRole", obj, function (res) {

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
                    $(dataTable).DataTable().ajax.reload();

                }
            }
            if (res.status == 401) {
                
                localStorage.removeItem("Menu");
                localStorage.removeItem("userData");
                window.location.href = baseWebUrl + "Account/Authenticate";
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
                window.location.href = baseWebUrl + "Account/Authenticate";
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

    } else {

        swal("Please Select  Record You Want to Update", {
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


function Delete(id) {
    //$(RolesSetup).hide("slow");
    //var validator = $(formRole).validate();
    //validator.resetForm();

    swal({
        title: "Are You Sure?",
        text: "Do you want to change the status of this record?",
        icon: "warning",
        buttons: true,
        dangerMode: false,
    })
        .then((willDelete) => {

            if (willDelete) {
               
                postRequest(BaseUrl + "/DashBoard/Delete/" + id, null, function (res) {
                    if (res.status == 200) {
                        

                        swal("status has changed successfully!", {
                            icon: "success",
                            title: "Changed",
                        });

                        $(dataTable).DataTable().destroy(); GetAll();

                    }
                    if (res.status == 401) {
                        
                        localStorage.removeItem("Menu");
                        localStorage.removeItem("userData");
                        window.location.href = baseWebUrl + "Account/Authenticate";

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
                        window.location.href = baseWebUrl + "Account/Authenticate";
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
    $("#Save").show();
    $("#Edit").hide();
    $(txtRoleName).val('');
    $(hdRoleId).val('0');
    $(chkIsActive).prop("checked", true);
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
                        window.location.href = baseWebUrl + "Account/Authenticate";

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
                        window.location.href = baseWebUrl + "Account/Authenticate";
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



