jQuery(document).ready(function ($) {
    $("#logout").click(function () {
        debugger

        $.ajax({
            type: "POST",
            url: '/User/Logout',
            datatype: "json",

            success: function () {
                debugger
                document.location = "/User/Login"
             


            },
            error: function () {
                alert("something goes wrong");
            },

        })




    });
});