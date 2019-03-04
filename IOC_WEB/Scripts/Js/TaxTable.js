$(document).ready(function () {
    debugger
    $('#btn-update-tax').hide();
    $("#tbl-tax").dataTable({

        ajax: {
            type: "GET",
            url: '/Tax/TaxDetails',
            dataSrc: ""

        },

        columns: [
          {
              data: "TaxRate"
          },


          {
              data: "TaxId",
              render: function (data) {
                  return "<button class='btn btn-primary btn-sm delete' data-del-id= " + data + ">Remove</button>  " +
                      "<button class='btn btn-primary btn-sm edit' data-toggle='modal' data-target='#taxModal' data-edit-id=" + data + ">Update</button>"
              },
          }, ]
    })


    $('#addBtn').click(function () {
        $("#btn-save-tax").show();
        $('#btn-update-tax').hide();
    })
    //Add Tax
    $("#btn-save-tax").click(function () {
       
        debugger
        var form = $("#taxForm");
        form.validate();
        var isValid = form.valid();
        if (isValid) {
            debugger
            var taxData = {

                "TaxRate": $("#txtTaxType").val()
            };
            debugger

            $.ajax({

                type: "POST",
                url: "/Tax/SaveTax",
                data: taxData,

                success: function (data, status, xhr) {
                    debugger
                    $("#taxModal").modal("hide");
                    $("#taxForm")[0].reset();
                    $('#tbl-tax').dataTable().api().ajax.reload();


                },
                error: function (xhr) {
                    alert(xhr.responseText);
                }
            });
        }
        else {

        }
    });

    //Update Entry
    $("#tbl-tax").on("click", ".edit", function () {
        $("#btn-save-tax").hide();
        $('#btn-update-tax').show();
        debugger
        var button = $(this);
        debugger
        $.ajax({
            type: "GET",
            url: "/Tax/TaxEdit/" + button.attr("data-edit-id"),
            dataType: "json",
            success: function (data) {
                debugger

                $("#txtTaxType").val(data.TaxRate);
                $("#Id").val(data.TaxId);

            }

        });

    });



    //update
    $('#btn-update-tax').on("click", function () {
        var form = $("#taxForm");
        form.validate();
        var isValid = form.valid();
        if (isValid) {
            debugger
            var taxData = {
                "TaxId": $("#Id").val(),
                "TaxRate": $("#txtTaxType").val(),
            };



            $.ajax({
                url: "/Tax/UpdateTax",
                type: "POST",
                data: taxData,

                success: function (data) {
                    alert("data updated successfully");
                    $("#taxmodalupdate").modal("hide");
                    $("#taxForm")[0].reset();
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


    //*********************Delete Unit From Table***********************//

    $('#tbl-tax').on("click", ".delete", function () {

        debugger
        var button = $(this);
        bootbox.confirm("are u sure to delete this entry", function (result) {
            if (result) {
                debugger
                var taxid = button.attr("data-del-id");
               
                debugger
                $.ajax({
                    type: 'POST',
                    url: '/Tax/DeleteTax',
                    //contentType: "json",
                    data: {
                        "TaxId": taxid
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

    $('#taxModal').on('hidden.bs.modal', function () {
        debugger
        $('#txtTaxType').parent().next().empty();
        $('#txtTaxType').val('').end();
       

    });
});