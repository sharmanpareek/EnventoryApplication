
jQuery(document).ready(function ($) {

    $('#Email').blur(function () {
        var url = "/User/CheckUserName";
        var name = $('#Email').val();
        $.get(url, { input: name }, function (data) {
            if (data == "Available") {
                
            }
            else {
                $("#result").html("<span style='color:red'>Email is already exist</span>");
             
            }
        });
    })

    //**********Post Form Data To Controller*****************

    $("#save").click(function () {
       
        var form = $("#registrationForm");
        form.validate();
        var isValid = form.valid();
        if (isValid) {
            var gen = "";
            if ($("#Gender").is(":checked")) {
                gen = "Male"
            }
            else gen = "Female"
            var user = {
                "FirstName": $("#FirstName").val(),
                "LastName": $("#LastName").val(),
                "Email": $("#Email").val(),
                "Password": $("#Password").val(),
                "MobileNumber": $("#MobileNumber").val(),
                "DOB": $("#DOB").val(),
                "Gender": gen,
                "Address": $("#Address").val()
            };
            if ($("#result > span").text() == "Email is already exist") {
               
                return false;
            }

            $.ajax({
                type: "POST",
                Url: 'http://localhost:50236/User/UserSave',
                data: user,

                success: function (data, status, xhr) {

                   window.location.href= '/User/Login'
               },
                error: function (xhr) {
                    alert("xhr.responseText");
                }

            });
        }
        else {
            
        }

    })


    //****************DatePicker************
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

   

    

})