$(document).ready(function () {
    $('#btnupdateitem').hide();

    $("#tbl-item").dataTable({
        
        ajax:{
            type:"GET",
            url: '/Item/ItemDetails',
            dataSrc: ""

        },

        columns: [
          {
              data: "ItemName"
          },
         
          {
              data: "Price"
          },
          {
              data: "UnitPrice"
          },
          {
              data: "MfgDate",
              "type": "date ",
              "render":function (value) {
                  if (value === null) return "";

                  var pattern = /Date\(([^)]+)\)/;
                  var results = pattern.exec(value);
                  var dt = new Date(parseFloat(results[1]));

                  return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();}
          
                
          },
          {
              data: "ExpDate",
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
              data: "ProductCompany"
          },

           {
               data: "Quantity"
           },
       
          {
              data: "ItemId",
              render: function (data) {
                  return "<button class='btn btn-primary btn-sm delete' data-del-id= " + data + ">Remove</button>  " +
                      "<button class='btn btn-primary btn-sm edit' data-toggle='modal' data-target='#ItemAddModel' data-edit-id=" + data + ">Update</button>"
              },
          },
        ]
   })

   $('#addBtn').click(function () {
       $("#btnsaveitem").show();
       $('#btnupdateitem').hide();
   })

    $("#btnsaveitem").click(function () {
        debugger
        var form = $("#AddItemForm");
        form.validate();
        var isValid = form.valid();
        if (isValid) {
            debugger
            var itemData = {
                
                "CategoryId": $("#CategoryId").val(),
                "UnitId":$("#UnitId").val(),
                "ItemName": $("#txtItem").val(),
                "Price": $("#txtItemPrice").val(),
                "UnitPrice":$("#txtItemUnitPrice").val(),
                "MfgDate": $("#txtMfgDate").val(),
                "ExpDate": $("#txtExpDate").val(),
                "ProductCompany": $("#txtProductCompany").val(),
                "Quantity": $("#txtquantity").val(),
            };
            debugger

            $.ajax({

                type: "POST",
                url: "/Item/SaveItem",
                data: itemData,
               
                success: function (data,status,xhr) {
                    debugger
                    $("#ItemAddModel").modal("hide");
                    $("#AddItemForm")[0].reset();
                
                    $('#tbl-item').dataTable().api().ajax.reload();
               

                },
                error: function (xhr) {
                    alert(xhr.responseText);
                }
            });
        }
        else {

        }
    });


    //Update Entry Of Item
    $("#tbl-item").on("click", ".edit", function () {
        $("#btnsaveitem").hide();
        $('#btnupdateitem').show();
        debugger
        var button = $(this);
        debugger
        $.ajax({
            type: "GET",
            url: "/Item/ItemEdit/" + button.attr("data-edit-id"),
            dataType: "json",
            success: function (data) {
                debugger
                var pattern = /Date\(([^)]+)\)/;

                $("#CategoryId").val(data.CategoryId);
                $("#UnitId").val(data.UnitId);
                $("#txtItem").val(data.ItemName);
                $("#txtItemPrice").val(data.Price);
                $("#txtItemUnitPrice").val(data.UnitPrice);

                var results = pattern.exec(data.MfgDate);
                var dt = new Date(parseFloat(results[1]));
                var MfgDate = (dt.getMonth() + 1) + "-" + dt.getDate() + "-" + dt.getFullYear();
                $("#txtMfgDate").val(MfgDate);
                var results1 = pattern.exec(data.ExpDate);
                var dt1 = new Date(parseFloat(results1[1]));
                var ExpDate = (dt1.getMonth() + 1) + "-" + dt1.getDate() + "-" + dt1.getFullYear();
                $("#txtExpDate").val(ExpDate);
                $("#txtProductCompany").val(data.ProductCompany);
                $("#txtquantity").val(data.Quantity);
                $("#Id").val(data.ItemId);

            }

        });

    });



    //update
    $('#btnupdateitem').on("click", function () {
        var form = $("#AddItemForm");
        form.validate();
        var isValid = form.valid();
        if (isValid) {
            debugger
            var itemData = {
                "ItemId": $("#Id").val(),
                "CategoryId": $("#CategoryId").val(),
                "UnitId": $("#UnitId").val(),
                "ItemName": $("#txtItem").val(),
                "Price": $("#txtItemPrice").val(),
                "UnitPrice": $("#txtItemUnitPrice").val(),
                "MfgDate": $("#txtMfgDate").val(),
                "ExpDate": $("#txtExpDate").val(),
                "ProductCompany": $("#txtProductCompany").val(),
                "Quantity": $("#txtquantity").val(),
            };



            $.ajax({
                url: "/Item/UpdateItem",
                type: "POST",
                data: itemData,

                success: function (data) {
                    alert("data updated successfully");
                    $("#ItemAddModel").modal("hide");
                    $("#AddItemForm")[0].reset();

                    $('#tbl-item').dataTable().api().ajax.reload();
                },
                error: function () {
                    alert("Failed to Uploaded");
                }


            });
        }
        else {

        }
    });

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

    //*************Delete Item From Table***********

    $('#tbl-item').on("click", ".delete", function () {

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
                    url: '/Item/DeleteItem',
                    //contentType: "json",
                    data: {
                        "ItemId": s
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
    $('#ItemAddModel').on('hidden.bs.modal', function () {
        debugger
        $('#CategoryId').parent().next().empty();
        $('#CategoryId').val('').end();
        $('#UnitId').parent().next().empty();
        $('#UnitId').val('').end();
        $('#txtItem').parent().next().empty();
        $('#txtItem').val('').end();
        $('#txtItemPrice').parent().next().empty();
        $('#txtItemPrice').val('').end();
        $('#txtItemUnitPrice').parent().next().empty();
        $('#txtItemUnitPrice').val('').end();
        $('#txtMfgDate').parent().next().empty();
        $('#txtMfgDate').val('').end();
        $('#txtExpDate').parent().next().empty();
        $('#txtExpDate').val('').end();
        $('#txtProductCompany').parent().next().empty();
        $('#txtProductCompany').val('').end();
        $('#txtquantity').parent().next().empty();
        $('#txtquantity').val('').end();




    });
})