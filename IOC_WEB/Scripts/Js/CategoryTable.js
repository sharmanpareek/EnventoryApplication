$(document).ready(function () {
    $('#btn-update-category').hide();
    debugger
    $("#tbl-category").dataTable({

        ajax: {
            type: "GET",
            url: '/Category/CategoryDetails',
            dataSrc: ""

        },

        columns: [
          {
              data: "CategoryName"
          },


          {
              data: "CategoryId",
              render: function (data) {
                  return "<button class='btn btn-primary btn-sm delete' data-del-id= " + data + ">Remove</button>  " +
                      "<button class='btn btn-primary btn-sm edit' data-toggle='modal' data-target='#categoryModal' data-edit-id=" + data + ">Update</button>"
              },
          }, ]
    })


    $("#btn-save-category").click(function () {
        debugger
        var form = $("#categoryForm");
        form.validate();
        var isValid = form.valid();
        if (isValid) {
            debugger
            var categoryData = {

                "CategoryName": $("#category").val()

            };
            debugger

            $.ajax({

                type: "POST",
                url: "/Category/SaveCategory",
                data: categoryData,

                success: function (data, status, xhr) {
                    debugger
                    $("#categoryModal").modal("hide");
                    $("#categoryForm")[0].reset();

                    $('#tbl-category').dataTable().api().ajax.reload();

                },
                error: function (xhr) {
                    alert(xhr.responseText);
                }
            });
        }
        else {

        }
    });

    $('#addBtn').click(function () {
        $("#btn-save-category").show();
        $('#btn-update-category').hide();
    })

    $("#tbl-category").on("click", ".edit", function () {
        $("#btn-save-category").hide();
        $('#btn-update-category').show();
        debugger
        var button = $(this);
        debugger
        $.ajax({
            type: "GET",
            url: "/Category/CategoryEdit/" + button.attr("data-edit-id"),
            dataType: "json",
            success: function (data) {
                debugger

                $("#txtcategoryname").val(data.CategoryName);
                $("#Id").val(data.CategoryId);

            }

        });

    });



    //update
    $('#btn-update-category').on("click", function () {
        var form = $("#categoryForm");
        form.validate();
        var isValid = form.valid();
        if (isValid) {
            debugger
            var categoryData = {
                "CategoryId": $("#Id").val(),
                "CategoryName": $("#txtcategoryname").val(),
            };



            $.ajax({
                url: "/Category/UpdateCategory",
                type: "POST",
                data: categoryData,

                success: function (data) {
                    alert("data updated successfully");
                    $("#categoryModal").modal("hide");
                    $("#categoryForm")[0].reset();
                    $('#tbl-category').dataTable().api().ajax.reload();
                    
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

    $('#tbl-category').on("click", ".delete", function () {

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
                    url: '/Category/DeleteCategories',
                    //contentType: "json",
                    data: {
                        "CategoryId": s
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
    $('#categoryModal').on('hidden.bs.modal', function () {
        debugger
        $('#txtcategoryname').parent().next().empty();
        $('#txtcategoryname').val('').end();
    });
});