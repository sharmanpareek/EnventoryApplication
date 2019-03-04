$(document).ready(function () {
    $("#signin").click(function () {
        debugger
        var LoginData = {
            "Email": $("#Email").val(),
            "Password": $("#Password").val()
        };
        $.ajax({
            type: "POST",
            Url: 'http://localhost:50236/User/Login',
            data: LoginData,
            dataType: "json",

            success: function (data) {
                debugger
                if (data == "Admin")
                    window.location.href = "/Admin/AdminDashboard";
                else if (data == "User")
                    window.location.href = "/Users/UserDashboard";
                else
                    alert(data);
            },
            error: function (xhr) { alert('Invalid Email and Password'); }
        })
    });
});