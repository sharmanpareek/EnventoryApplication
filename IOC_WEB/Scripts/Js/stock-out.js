$(function () {
    debugger
    $('#tblSaleGrid').appendGrid({
        caption: 'Sale Details',
        initRows: 1,
        columns: [
           { name: 'ItemName', display: 'ItemName', type: 'select',ctrlClass: 'class-dropdown',ctrlAttr: { maxlength: 100 }, ctrlCss: { width: '160px' } },
        { name: 'UnitPrice', display: 'UnitPrice', type: 'text',ctrlClass: 'class-price', ctrlAttr: { maxlength: 100 }, ctrlCss: { width: '100px' } },
    { name: 'UnitSold', display: 'UnitSold', type: 'text',ctrlClass: 'class-unitsold',  ctrlAttr: { maxlength: 4 }, ctrlCss: { width: '40px' } },
    { name: 'Total', display: 'SubTotal', type: 'text',ctrlClass: 'class-subtotal', ctrlAttr: { maxlength: 100 }, ctrlCss: { width: '100px' } },
    { name: 'RecordId', type: 'hidden', value: 0 }
        ],

        hideButtons: {
            remove: false,
            insert:true,
            moveUp:	true,
            moveDown:true,

        },

        customFooterButtons: [
   {
       uiButton: { icons: { primary: 'ui-icon-refresh' } },
       btnCss: { 'color': 'rgb(0, 126, 255)' ,'float': 'right','margin-right': '190px','height':'20px'},
       var: count=0,
       click: ("#tblSaleGrid_footer_td .ui-button ui-corner-all ui-widget", function () {
           debugger
           var lth=$("#tblSaleGrid .ui-widget-content > tr").length;
           var grandTotal=0;
           for(var i=1;i<=lth;i++)
           {
               var val=$('#tblSaleGrid_Total_'+i).val();
               grandTotal = grandTotal +parseInt(val);
               $('#txtTotal').val(grandTotal);

                     
           }
                  

       })

   }
        ]
             
           

    });
         
    $("#tblSaleGrid .ui-widget-content .class-subtotal").attr("readonly",true);
            

});

function dropdownAppend(count){

    $.each(@Html.Raw(Json.Encode(ViewBag.Items)),function(i,value){
        debugger;
        $("#tblSaleGrid_ItemName_td_"+count+" .class-dropdown").append("<option value="+value.ItemId+">"+value.ItemName+"</option>")

    })

}
 
            
         



$(document).ready(function () {
    var count=0;
    dropdownAppend(count=count+1)
    $('#tblSaleGrid_footer_td .append').click(function(){

        dropdownAppend(count=count+1)

    })
    $('.ui-widget-content .last .insert').click(function(){

        dropdownAppend(count=count+1)
    })

    $('#tblSaleGrid .ui-widget-content').on("change",".class-dropdown",function(){
        debugger
        var select=$(this);
        $.each(@Html.Raw(Json.Encode(ViewBag.Items)),function(i,value){
            debugger;
            if(value.ItemId==select.val()){
                //alert(select.closest("tr").find("input[class='class-price']").val());
                select.closest("tr").find("input[class='class-price']").val(value.UnitPrice)
            }
        })
    });

    $('#tblSaleGrid .ui-widget-content').on("keyup",".class-unitsold",function(){
        debugger
        var select=$(this);
        if(!isNaN(select.closest("tr").find("input[class='class-unitsold']").val())){
            debugger
            var a=select.closest("tr").find("input[class='class-price']").val();
            var b=select.closest("tr").find("input[class='class-unitsold']").val();
            var c=a*b;
            debugger
            select.closest("tr").find("input[class='class-subtotal']").val(c);
        }


    });
    $('#tblSaleGrid .ui-widget-content').on("keyup",".class-price",function(){
        debugger
        var select=$(this);
        if(!isNaN(select.closest("tr").find("input[class='class-price']").val())){
            debugger
            var a=select.closest("tr").find("input[class='class-price']").val();
            var b=select.closest("tr").find("input[class='class-unitsold']").val();
            var c=a*b;
            debugger
            select.closest("tr").find("input[class='class-subtotal']").val(c);
        }


    });
           
               
          
    $("#TaxId").on("change",function(){
        debugger
        var a= parseInt($('#TaxId :selected').text());
        debugger
        var b= parseInt($('#txtTotal').val());
        debugger
        var c=b*a/100+b;
        debugger
        $('#txtGrandTotal').val(c);

    })




});

$("#btn-save").click(function(){
    var form = $("#saleForm");
    form.validate();
    var isValid = form.valid();
    if (isValid) {
        debugger
        var saleDetailData=[];
        var count=1;
        var lth=$("#tblSaleGrid .ui-widget-content > tr").length;
        for(var i=0;i<lth;i++)
        {
            saleDetailData[i]={
                ItemId:$('#tblSaleGrid_ItemName_'+count +'  :selected ').val(),
                UnitPrice:$('#tblSaleGrid_UnitPrice_'+count).val(),
                UnitSold:$('#tblSaleGrid_UnitSold_'+count).val(),
                SubTotal:$('#tblSaleGrid_Total_'+count).val()
            }
            count++;
        }
        // saleDetailData = JSON.stringify({ 'saleModel': saleDetailData });
        debugger
            
            
        //debugger
        var saleFormData ={
            "BillNo":$("#txtBillNo").val(),
            "PartyId":$("#PartyId").val(),
            "CreatedDate":$("#createdDate").val(),
            "Total":$("#txtTotal").val(),
            "GrandTotal":$("#txtGrandTotal").val(),
            "TaxId":$("#TaxId").val(),
            "SaleDetailList":saleDetailData
        }
        debugger
        $.ajax({
            type: "POST",
            url: "/Sales/SaveSaleDetails",
            //contentType: 'application/json; charset=utf-8',
            saleFormData:  JSON.stringify({ 'saleModel': saleFormData }),
            data:saleFormData,
            dataType:"json",
            success: function(data){
                $("#saleModal").modal("hide");
                $("#saleForm")[0].reset();
            },
            error: function(){}
                
     
        })
    }
    else{

    }
                
})