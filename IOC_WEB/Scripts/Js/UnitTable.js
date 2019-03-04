$(document).ready(function () {
    $('#btn-update-unit').hide();
 
    $("#tbl-unit").dataTable({

        ajax: {
            type: "GET",
            url: '/Unit/UnitDetails',
            dataSrc: ""

        },

        columns: [
          {
              data: "UnitTypes"
          },
         

          {
              data: "UnitId",
              render: function (data) {
                  return "<button class='btn btn-primary btn-sm delete' data-del-id= " + data + ">Remove</button>  " +
                      "<button class='btn btn-primary btn-sm edit' data-toggle='modal' data-target='#unitModal' data-edit-id=" + data + ">Update</button>"
              },
          }, ]
    })
    $('#addBtn').click(function () {
        $("#btn-save-unit").show();
        $('#btn-update-unit').hide();
    })
    //Save Unit 
    $("#btn-save-unit").click(function () {
        debugger
        var form = $("#unitForm");
        form.validate();
        var isValid = form.valid();
        if (isValid) {
            debugger
            var unitData = {

                "UnitTypes": $("#txtUnitType").val()
            };
            debugger

            $.ajax({

                type: "POST",
                url: "/Unit/SaveUnit",
                data: unitData,

                success: function (data, status, xhr) {
                    debugger
                    $("#unitModal").modal("hide");
                    $("#unitForm")[0].reset();

                    $('#tbl-unit').dataTable().api().ajax.reload();

                },
                error: function (xhr) {
                    alert(xhr.responseText);
                }
            });
        }
        else {

        }
    });

    //Update Unit
    $("#tbl-unit").on("click", ".edit", function () {
        $("#btn-save-unit").hide();
        $('#btn-update-unit').show();
        debugger
        var button = $(this);
        debugger
        $.ajax({
            type: "GET",
            url: "/Unit/UnitEdit/" + button.attr("data-edit-id"),
            dataType: "json",
            success: function (data) {
                debugger

                $("#txtUnitType").val(data.UnitTypes);
                $("#Id").val(data.UnitId);

            }

        });

    });



    //update
    $('#btn-update-unit').on("click", function () {
        var form = $("#unitForm");
        form.validate();
        var isValid = form.valid();
        if (isValid) {
            debugger
            var unitData = {
                "UnitId": $("#Id").val(),
                "UnitTypes": $("#txtUnitType").val(),
            };



            $.ajax({
                url: "/Unit/UpdateUnit",
                type: "POST",
                data: unitData,

                success: function (data) {
                    alert("data updated successfully");
                    $("#unitModal").modal("hide");
                    $("#unitForm")[0].reset();
                    $('#tbl-unit').dataTable().api().ajax.reload();
                  
                },
                error: function () {
                    alert("Failed to Uploaded");
                }


            });
        }
        else {

        }
    });


    //*********************Delete Unit From Table***********************//

    $('#tbl-unit').on("click", ".delete", function () {

        debugger
        var button = $(this);
        bootbox.confirm("are u sure to delete this entry", function (result) {
            if (result) {
                debugger
                var s = button.attr("data-del-id");
                alert(s);
                debugger
                $.ajax({
                    type: 'POST',
                    url: '/unit/DeleteUnits',
                    //contentType: "json",
                    data: {
                        "UnitId": s
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
    $('#unitModal').on('hidden.bs.modal', function () {
        debugger
        $('#txtUnitType').parent().next().empty();
        $('#txtUnitType').val('').end();


    });
});