var oTable6;
$(document).ready(function () {
    $('#update').hide();
    $("#party").dataTable({




        ajax:{
            type:"GET",
            url: '/Party/PartyDetails',
            dataSrc: ""

        },

        columns: [
          {
              data: "PartyName"
          },
          {
              data: "Contact"
          },
          {
              data: "Address"
          },
          {
              data: "PartyId",
              render: function (data) {
                  return "<button class='btn btn-primary btn-sm delete' data-del-id= " + data + ">Remove</button>  " +
                      "<button class='btn btn-primary btn-sm edit' data-toggle='modal' data-target='#myModal' data-edit-id=" + data + ">Update</button>"
              },
          },
        ]
    })

    $('#addBtn').click(function () {
        $("#submit").show();
        $('#update').hide();
    })
    //update Party Record

    $("#party").on("click", ".edit", function () {
        $("#submit").hide();
        $('#update').show();
        debugger
        var button = $(this);
        debugger
        $.ajax({
            type: "GET",
            url: "/Party/PartyEdit/" + button.attr("data-edit-id"),
            dataType: "json",
            success: function (data) {
                debugger
              
                $("#PartyName").val(data.PartyName);
                $("#Contact").val(data.Contact);
                $("#Address").val(data.Address);
                $("#Id").val(data.PartyId);

            }
            
        });

    });



    //update
    $('#update').on("click", function () {
        var form = $("#partyForm");
        form.validate();
        var isValid = form.valid();
        if (isValid) {
            debugger
            var partyData = {
                "PartyId": $("#Id").val(),
                "PartyName": $("#PartyName").val(),
                "Contact": $("#Contact").val(),
                "Address": $("#Address").val()

            };



            $.ajax({
                url: "/Party/UpdateParty",
                type: "POST",
                data: partyData,

                success: function (data) {
                    alert("data updated successfully");
                    $("#myModal").modal("hide");
                    $("#partyForm")[0].reset();
                
                    $('#tbl-party').dataTable().api().ajax.reload();
                },
                error: function () {
                    alert("Failed to Uploaded");
                }


            });
        }
        else {

        }
    });


    //Delete a Party from database

    $('#party').on("click", ".delete", function () {

        debugger
        var button = $(this);
        bootbox.confirm("are u sure to delete this entry", function (result) {
            if (result) {
                debugger
                var partyid = button.attr("data-del-id");
                alert(s);
                debugger
                $.ajax({
                    type: 'POST',
                    url: '/Party/UpdatePartyStatus',
                    //contentType: "json",
                    data: {
                        "PartyId": partyid
                    },
                    dataType: "json",
                    success: function (data) {
                        if (data == true) {
                            button.parents("tr").remove();
                        }
                        else {
                            alert("Not Deleted");
                        }
                       
                     
                    },
                    error: function () { alert('error'); }
                });
            }
        });
    });

    //Add New Party to datbase....

    $("#submit").click(function () {
        var form = $("#partyForm");
        form.validate();
        var isValid = form.valid();
        if (isValid) {
            var partyData = {
                "PartyName": $("#PartyName").val(),
                "Contact": $("#Contact").val(),
                "Address": $("#Address").val()
            };
            $.ajax({

                type: "POST",
                url: "/Party/SaveParty",
                data: partyData,

                success: function (data, status, xhr) {
                    $("#myModal").modal("hide");
                    $("#partyForm")[0].reset();
                   
                    $('#tbl-party').dataTable().api().ajax.reload();

                },
                error: function (xhr) {
                    alert(xhr.responseText);
                }
            });
        }
        else {

        }
    });
    $('#myModal').on('hidden.bs.modal', function () {
        debugger
        $('#PartyName').parent().next().empty();
        $('#PartyName').val('').end();
        $('#Contact').parent().next().empty();
        $('#Contact').val('').end();
        $('#Address').parent().next().empty();
        $('#Address').val('').end();


    });
});