$(document).ready(function () {

    alert("helllo");
    $.ajax({
        url: "https://localhost:44317/api/Authentication/string",
        type: "GET",
        success: function (data) {
            console.warn(data);
        }, error: function (data) {
            console.warn(data);
        }



    });

});



