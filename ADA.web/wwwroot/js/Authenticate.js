
let baseApiUrl = "";
let baseWebUrl = "";
let Form = "#loginForm";
let btnLogin = "#btnLogin"
let txtUsername = "#txtUsername"
let txtPassword = "#txtPassword"
let BaseUrl;
$(document).ready(function () {
    BaseUrl = $("#baseUrlForMVCAction").val();
    if (BaseUrl == "null")
        BaseUrl = "";
    baseApiUrl = $("#baseApiUrl").val();

    baseWebUrl = $("#baseWebUrl").val();

 
    $(btnLogin).click(function () {
        Login();
    });

});


$(txtUsername).on('keypress', function (e) {
    if (e.which === 13) {

        //Disable textbox to prevent multiple submit
        $(this).attr("disabled", "disabled");
        Login();

        $(this).removeAttr("disabled");
    }
});

$(txtPassword).on('keypress', function (e) {
    if (e.which === 13) {

        //Disable textbox to prevent multiple submit
        $(this).attr("disabled", "disabled");
        Login();

        $(this).removeAttr("disabled");
    }
});


function Login() {
    /*    window.location.href = baseWebUrl + "Home/Index"*/

    if ($(Form).valid()) {
       debugger
        //ShowLoader();
        let data = {
            Username: $(txtUsername).val(),
            Password: $(txtPassword).val(),
            PlatformId: 10
        }
        postRequest(BaseUrl + '/Dashboard/AuthenticateUser', data, function (res) {

            if (res.status == 200) {
                
                localStorage.setItem("userData", JSON.stringify(res.data.dataObj));

                window.location.href = baseWebUrl + "Dashboard/Flight";
                //localStorage.setItem("Menu", JSON.stringify(res.Data.Menu));

                
                //window.location.href = baseWebUrl + "" + res.Data.IndexPageController + "/" + res.Data.IndexPageAction;
            }
            if (res.status == 304) {
               // $(btnLogin).buttonLoader('stop');
                localStorage.removeItem("userData");
                //HideLoader();
                swal({
                    title: "Error",
                    text: res.responseMsg,
                    icon: "error",
                    dangerMode: true,
                })
            }
            if (res.status == 305) {
                localStorage.setItem('RedirectionId', res.Data)
                window.location.href = baseWebUrl + "Account/ExpiredPasswordChanged";
            }
            if (res.status == 401) {
               // $(btnLogin).buttonLoader('stop');
                localStorage.removeItem("userData");
                //HideLoader();
                swal({
                    title: "Error",
                    text: res.responseMsg,
                    icon: "error",
                    dangerMode: true,
                })
            }
            if (res.status == 403) {
               // $(btnLogin).buttonLoader('stop');
                //HideLoader();
                swal(res.responseMsg, {
                    icon: "error",
                    title: "Error",
                });
            }
            if (res.status == 320) {
               

                swal({
                    title: "Error",
                    text: "Invalid Username and Password",
                    icon: "error",
                    dangerMode: true,
                })
            }
            if (res.status == 500) {
               // $(btnLogin).buttonLoader('stop');
                //HideLoader();
                swal({
                    title: "Error",
                    text: res.responseMsg,
                    icon: "error",
                    dangerMode: true,
                })
            }
            if (res.status == 600) {
               // $(btnLogin).buttonLoader('stop');
                //HideLoader();
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



$(Form).validate({
    errorClass: "alert alert-danger text-center errorClass",
    errorElement: "div",
    rules: {
        txtUsername: {
            required: true
        },
        txtPassword: {
            required: true
        }
    },

    highlight: function (inputelement, errorClass) {
        $(inputelement).removeClass(errorClass)
    }
});


function postRequest(url, requestData, handledata) {
    $.ajax({
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        dataType: "json",
        url: url,
        headers: {
            "Authorization": GetAuthorizationHeader()
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

function GetAuthorizationHeader() {
    let token = localStorage.getItem('authorization');
    if (isNullOrUndefined(token)) {
        token = "";
    }
    return token = "Bearer " + token;
}

function isNullOrUndefined(value) {
    if (value == null || value == undefined || value == "undefined")
        return true;
    else
        return false;
}