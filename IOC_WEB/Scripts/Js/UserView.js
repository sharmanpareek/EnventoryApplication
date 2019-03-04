$(document).ready(function () {
    debugger
    $("#tbl-userView").dataTable({

        ajax: {
            type: "GET",
            url: '/Admin/UserDetails',
            dataSrc: ""

        },

        columns: [
          {
              data: "FirstName"
          },
          {
              data: "LastName"
          },
          {
              data: "Email"
          },
        
          {
              data:"MobileNumber"
          },
          {
              data: "DOB",
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
              data: "Gender"
          },
          {
              data: "Address"
          },

         
        ]
    })

   
});
