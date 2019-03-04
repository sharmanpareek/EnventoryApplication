

     $("#key").click(function () {
         $(".tab-content").hide();
         $("#change").show();
     });

$("#profile").click(function () {
    $("#change").hide();
    $(".tab-content").show();
});




$('#btn-user-update').on("click", function () {
    var form = $("#userForm");
    form.validate();
    var isValid = form.valid();
    if (isValid) {
        debugger
        var gen = "";
        if ($("#Gender").is(":checked")) {
            gen = "Male"
        }
        else gen = "Female"
        var userData = {
            "UserId": $("#UserId").val(),
            "FirstName": $("#txtFirstName").val(),
            "LastName": $("#txtLastName").val(),
            "MobileNumber": $("#txtMobileNumber").val(),
            "DOB": $("#txtDOB").val(),
            "Address": $("#txtAddress").val(),
            "Gender":gen,

        };


        debugger
        $.ajax({
            url: "/Users/UpdateUser",
            type: "POST",
            data: userData,

            success: function (data) {
               
               
                $(".tab-content").show();
                $("#change").hide();
               // $("#userForm").trigger("reset");
             
                $("#profile-data").load(window.location + " #profile-data");
               
                
               
               
            },
            error: function () {
                alert("Failed to Uploaded");
            }


        });
    }
    else {

    }
});
//****************DatePicker**************//
var date = new Date();
var FromEndDate = new Date();
$(function () {
    $('.datepicker').datepicker({

        format: 'mm-dd-yyyy',
        endDate: FromEndDate,
        autoclose: true,
        onRender: function (date) {
            return date.valueOf() > FromEndDate.valueOf() ? 'disabled' : ' ';
        }
    }).on('changeDate', function (e) {
        $(this).datepicker('hide');
    });

});
