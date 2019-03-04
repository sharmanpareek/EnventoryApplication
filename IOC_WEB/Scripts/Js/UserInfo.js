$("#tbl-UserInfo").dataTable({

    ajax: {
        type: "GET",
        url: '/Admin/UserPersonalInfo',
        dataSrc: ""

    },

    columns: [
      {
          data: "Email"
      },

     

      {
          data: "CreatedDate",
          "type": "date ",
          "render": function (value) {
              if (value === null) return "";

              var pattern = /Date\(([^)]+)\)/;
              var results = pattern.exec(value);
              var dt = new Date(parseFloat(results[1]));

              return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
          }
      },


      {
          data: "Role"
      },
      
        {
            data: "IsActive",

            render: function (data, type, full, meta) {
              
                if (data == true) {
                    return "<input checked type='checkbox' value=" + data + " class='chk-active' data-chk-id= " + full.UserId + "></input>"
                }
                else {
                    return "<input type='checkbox' value=" + data + " class='chk-active' data-chk-id= " + full.UserId + "></input>"
                }

            },


        },




    ]
})

$('#tbl-UserInfo').on("click", ".chk-active", function () {

    debugger
    var checkbox = $(this).is(":checked");


    debugger
    var s = $(this).attr("data-chk-id");
    alert(s);
    debugger
    $.ajax({
        type: 'POST',
        url: '/Admin/Activeuser',
        //contentType: "json",
        data: {
            "IsActive": checkbox,
            "UserId": s
        },
        dataType: "json",
        success: function (data) {
           


        },
        error: function () { alert('error'); }
    });


});

