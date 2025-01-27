







$(document).ready(function () {

                var counter = 0;

                $('#showCarton').DataTable();

            $("#save_button").click(function () {
                SaveCarton();

            });
            //$("#btn_carton_Details").click(function () {
            //    ModelShow();
            //});

            $("#remove_button").click(function () {
                window.location.href = '/CartonEntry/CartonEntry';
            });

            //function GetDate() {
            //    var dt = new Date();
            //    var dd;
            //    var mm;
            //    dd = dt.getDate();
            //    mm = dt.getMonth() + 1;
            //    //document.getElementById('current_date').value = mm + '/' + dd + '/' + dt.getFullYear();

            //}

   



                $("#addrow").on("click", function () {

                    counter = $('#myTable tr').length - 2;
                    //var assetCata = $("#assetSelect").children("option:selected").html();
                    var newRow = $("<tr>");
                    var cols = "";

                    cols += '<td><input type="text"  class="form-control"  name="Carton' + counter + '"  /></td>';
                    cols += '<td><input type="text" class="form-control"  name="Color' + counter + '"/></td>';
                    cols += '<td><input type="text" class="form-control"   name="SizeXS' + counter + '"/></td>';
                    cols += '<td><input type="text" class="form-control"  name="SizeS' + counter + '"/></td>';
                    cols += '<td><input type="text" class="form-control"  name="SizeM' + counter + '"/></td>';
                    cols += '<td><input type="text" class="form-control"  name="SizeL' + counter + '"/></td>';
                    cols += '<td><input type="text" class="form-control"  name="SizeXL' + counter + '"/></td>';
                    cols += '<td><input type="text" class="form-control"  name="SizeXX' + counter + '"/></td>';
                    cols += '<td><input type="text" class="form-control"  name="SizeXXX' + counter + '"/></td>';
                    cols += '<td><input type="text" class="form-control"  name="Quentity' + counter + '"/></td>';
                    cols += '<td><input type="text" class="form-control"  name="NET_WEIGHT' + counter + '"/></td>';
                    cols += '<td><input type="text" class="form-control"  name="GROSS_WEIGHT' + counter + '"/></td>';
                    cols += '<td><input type="button" class="btn btn-danger ibtnDel"  value="X"></td>';

                    newRow.append(cols);
                    if (counter == 4) $('#addrow').attr('disabled', true).prop('value', "You've reached the limit");
                    $("#tblBodyinput").append(newRow);
                    counter++;
                    //calculateGrandTotal();
                });

                //$("table.order-list").on("change", 'input[name^="Quentity"]', function (event) {
                //    /*calculateRow($(this).closest("tr"));*/
                //    /*calculateGrandTotal();*/
                //});


                $("table.order-list").on("click", ".ibtnDel", function (event) {
                    $(this).closest("tr").remove();
                    /* calculateGrandTotal();*/

                    /* counter -= 1*/
                    $('#addrow').attr('disabled', false).prop('value', "Add Row");
                });


            //    function ModelShow() {
            //        $("#myPreview").modal("show");
            //}
            function SaveCarton() {
                var valid = false;
                var jsonData = {};
                jsonData["BuyerID"] = $('#BuyerID').val();
                jsonData["BusinessUnitID"] = $('#BusinessUnitID').val();
                jsonData["PO"] = $('#PO').val();
                jsonData["Style"] = $('#Style').val();
                jsonData["ORDER_QTY"] = $('#ORDER_QTY').val();
                jsonData["WinShip_Quty"] = $('#WinShip_Quty').val();
                jsonData["PLUSE"] = $('#PLUSE').val();
                jsonData["PERCENTAGE"] = $('#PERCENTAGE').children("option:selected").html();
                jsonData["TOTAL_CTN"] = $('#TOTAL_CTN').val();
                jsonData["DESTIN"] = $('#DESTIN').val();
                jsonData["Solid_Colour"] = $('#Solid_Colour').val();
                jsonData["Solid_Size"] = $('#Solid_Size').val();
                jsonData["CartonMeasurement"] = $('#CartonMeasurement').val();
                jsonData["PERCENTAGE"] = $('#PERCENTAGE').val();
                var CartonDetailsList = [];
                $('#TblCartonList tr').each(function () {

                    var myData = {};
                    myData["CartonNo"] = $(this).find('input[name^="Carton"]').val();
                    myData["Color"] = $(this).find('input[name^="Color"]').val();
                    myData["SizeXS"] = $(this).find('input[name^="SizeXS"]').val();
                    myData["SizeS"] = $(this).find('input[name^="SizeS"]').val();
                    myData["SizeM"] = $(this).find('input[name^="SizeM"]').val();
                    myData["SizeL"] = $(this).find('input[name^="SizeL"]').val();
                    myData["SizeXL"] = $(this).find('input[name^="SizeXL"]').val();
                    myData["SizeXX"] = $(this).find('input[name^="SizeS"]').val();
                    myData["SizeXXX"] = $(this).find('input[name^="SizeXXX"]').val();
                    myData["Quentity"] = $(this).find('input[name^="Quentity"]').val();
                    myData["NET_WEIGHT"] = $(this).find('input[name^="NET_WEIGHT"]').val();
                    myData["GROSS_WEIGHT"] = $(this).find('input[name^="GROSS_WEIGHT"]').val();
                    if (Number.isNaN(myData["Quentity"]) == false && parseFloat(myData["Quentity"]) > 0) {
                        CartonDetailsList.push(myData);
                    }

                });
                if (CartonDetailsList.length > 0) {
                    valid = true;
                }

                jsonData["cartonDetails"] = CartonDetailsList;

                if (valid == true) {
                    var urlpath = "/CartonEntry/SaveCarton";
                    $.ajax({
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(jsonData),
                        dataType: 'json',
                        url: urlpath,
                        type: "Post",
                        async: true,
                        success: function (result) {
                            if (result.isSuccess) {
                                swal({
                                    title: 'Carton Saved Successfully!!',
                                    type: 'success',
                                    closeOnCancel: true
                                },
                                    function () {
                                        window.location.href = '/CartonEntry/CartonEntry';
                                    });
                            }
                        }
                    });
                } else {
                    swal({
                        title: 'PLEASE ENTER ALL THE FIELD!!',
                        type: 'error',
                        closeOnCancel: true
                    });
                }

            }

});

var Carton = {
    details: function (CartonID) {

        $("#myPreview").modal("show");
        var CartonId =$('CartonID').val();
        $.ajax({
            contentType: "application/json; charset=utf-8",
            data: CartonId,
            dataType: 'json',
            url:'/Carton/GetCartonDetailsAll',
            type: "Post",
            async: true,
            success: function (result) {
                if (result.isSuccess) {
                    
                }
            }
        });

    }
}
        //var result = "";

        //$('#masterdetails').empty();
        
       
        //var countRow = 1;
        //$("#tbl_PODetails tr td input[type='checkbox']:checked").each(function () {

        //    vEXTARNAL = $(this).attr('data-external');
        //    vDetailKey = $(this).attr('data-detail');
        //    //alert(vDetailKey);




        //    //vEXTARNAL += $(this).val() + ',';


        //    //alert($(this).attr('data-external'));
        //    //alert(vEXTARNAL);


          
        //        countRow++;



       /* }*/

            //totalAmt += parseInt($('.total').val());
            //alert(totalAmt);


   /* });*/

     

        ////$('#main').empty();
        ////$('#masterdetails').append('#tbl_PODetails tr');



        ////var row = $(this).closest('tr:has(td)').html();//.find("Table").find("TR:has(td)").clone();
        ////var tr = $("#tbl_PODetails").find("TR:has(td:not(:first-child))").clone();
        ////alert(tr);
        ////$("#main").append(tr);


        ////var row = $(this).closest('tr').html();
        ////$('#masterdetails').append('<tr>' + row + '</tr>');

        //result += "</tbody>";
        //result += "</table>";
        //result += "<div class='row'>";
        ////result += "<div style='width:250px;border: 1px solid black;float:right;'>";
        ////result += "<table class='table table-striped'>";
        ////result += "<tr><th style='width:100px;'>Total</th><th></th><th><span id='total'></span></th></tr>";
        ////result += "<tr><th>Discount</th><th style='width:100px;'><input type='text' class='form-control' value='0' id='input_discount' style='width:60px' onkeyup='discountKeyUp()' /></th><th><span id='total_discount'>0</span></th></tr>";
        ////result += "<tr><th style='width:100px;'>Total Amount</th><th></th><th><span id='total_amount'>0</span></th></tr>";
        ////result += "<tr><th>VAT/AIT</th><th><input type='text' class='form-control' value='0' id='input_vat' onkeyup='vatKeyUp()' style='width:60px' /></th><th><span id='vat'>0</span></th></tr>";
        ////result += "<tr><th>Net Value</th><th></th><th><span id='net_value'>0</span></th></tr>";
        ////result += "</table>";
        ////result += "</div>";
        //result += "</div>";

        //result += "<div class='row'>";
        //result += "<div class='col-md-2'>";
        //result += "<div class=''>";
        //result += "<input type='checkbox' id='finalInvoice' name='finalInvoice' value=''>";
        //result += "<label for='vehicle1'> &nbsp;&nbsp;Is Final Invoice</label>";
        //result += "</div>";
        //result += "</div>";

        //result += "<div class='col-md-3'>";
        //result += "<div class=''style=''>";
        //result += "<label for='total' id=''>Completion Note: &nbsp;&nbsp;</label>";
        //result += '<textarea id="note" name="note" rows="2" cols="30"></textarea>';
        //result += "</div>";
        //result += "</div>";
        //result += "<div class='col-md-3'>";
        //result += "<div class=''style=''>";
        //result += "<label for='total' id=''>Remarks: &nbsp;&nbsp;</label>";
        //result += '<textarea id="remarks" name="remarks" rows="2" cols="30"></textarea>';
        //result += "</div>";
        //result += "</div>";
        //result += "<div class='col-md-4'>";
        //result += "<div style='border: 1px solid black;float:right;'>";
        //result += "<table class='table table-striped'>";
        //result += "<tr><th style='min-width:100px'>Total</th><th></th><th style='min-width:150px;text-align: center;'><span id='total'></span></th></tr>";
        //result += "<tr><th style='min-width:100px'>Discount %</th><th style='min-width:50px'><input type='text' readonly class='form-control' value='0' id='input_discount' onkeyup='discountKeyUp()' /></th><th style='min-width:150px;text-align: center;'><span id='total_discount'>0</span></th></tr>";
        //result += "<tr><th style='min-width:100px;'>Total Amount</th><th></th><th style='min-width:150px;text-align: center;'><span id='total_amount'>0</span></th></tr>";
        //result += "<tr><th style='min-width:100px'>VAT/AIT %</th><th style='min-width:50px'><input type='text' class='form-control' readonly value='0' id='input_vat' onkeyup='vatKeyUp()' /></th><th style='min-width:150px;text-align: center;'><span id='vat'>0</span></th></tr>";
        //result += "<tr><th style='min-width:100px'>Net Value</th><th></th><th style='min-width:150px;text-align: center;'><span id='net_value'>0</span></th></tr>";
        //result += "</table>";
        //result += "</div>";
        //result += "</div>";
        //result += "</div>";
        //result += "<div class='text-center' style='padding-top:20px;'>";
        //result += "<button type='button' id='poSubmit' class='btn btn-success btn-sm' onclick='varifyInputElement()'>S U B M I T</button> &nbsp;";
        ////result += "<button type='button' id='' class='btn btn-info btn-sm' onclick='Swal()'>Preview</button>";
        //result += "</div>";

        //result += "<div>";

        //$('#masterdetails').append(result);

//    //}
//}















//$(document).ready(function () {
//    ////$("#btn_Submin").click(function () {
//    ////    SaveCarton();
//    ////});
//    //$('#CartonDetails').DataTable();
//    //$('#Colortble').DataTable();

//    $(document).ready(function () {
//        var counter = 0;

//        //$("#addrow").on("click", function () {

//        //    counter = $('#myTable tr').length - 2;
//        //    var assetCata = $("#assetSelect").children("option:selected").html();
//        //    var newRow = $("<tr>");
//        //    var cols = "";

//        //    cols += '<td><input type="text"  class="form-control"  name="asset_catagory' + counter + '" value="" /></td>';  /*' + assetCata + '*/
//        //    cols += '<td><input type="text" class="form-control"  name="asset_description' + counter + '"/></td>';
//        //    cols += '<td><input type="text" class="form-control"   name="asse_qty' + counter + '"/></td>';
//        //    cols += '<td><input type="text" class="form-control name="asset_unitPrice' + counter + '"/></td>';
//        //    cols += '<td><input type="text" class="form-control"  name="asset_estimated_cost' + counter + '"/></td>';
//        //    cols += '<td><input type="text" class="form-control"  name="asset_estimated_cost' + counter + '"/></td>';
//        //    cols += '<td><input type="text" class="form-control"  name="asset_estimated_cost' + counter + '"/></td>';
//        //    cols += '<td><input type="text" class="form-control"  name="asset_estimated_cost' + counter + '"/></td>';
//        //    cols += '<td><input type="text" class="form-control"  name="asset_estimated_cost' + counter + '"/></td>';
//        //    cols += '<td><input type="text" class="form-control"  name="asset_estimated_cost' + counter + '"/></td>';

//        //    cols += '<td><input type="button" class="btn btn-danger ibtnDel"  value="X"></td>';
//        //    newRow.append(cols);
//        //    if (counter == 4) $('#addrow').attr('disabled', true).prop('value', "You've reached the limit");
//        //    $("table.order-list").append(newRow);
//        //    counter++;
//        //    calculateGrandTotal();
//        //});

//        $("table.order-list").on("change", 'input[name^="asset_estimated_cost"]', function (event) {
//            calculateRow($(this).closest("tr"));
//            calculateGrandTotal();
//        });


//        $("table.order-list").on("click", ".ibtnDel", function (event) {
//            $(this).closest("tr").remove();
//            calculateGrandTotal();

//            counter -= 1
//            $('#addrow').attr('disabled', false).prop('value', "Add Row");
//        });
//    });
//});


////$('#SubQuentity').keyup(function () {
////    var subQntity= ('#SubQuentity').val();
////    $('#Quentity').val(subQntity);
////})


//$('#SubQuentity').keyup(function () {
//    var subQntity = ($('#SubQuentity').val());
//    $("#SubQuentity").val(subQntity);
//});

////$("#SubQuentity").keyup(function () {
////    var subQntity = ('#SubQuentity').val();
////    $("#Quentity").css("background-color", "pink");
////});

////function SaveCarton() {
////    var valid = true;
////    var _Carton = {
////        BusinessUnitId: $('#BusinessUnitId').val()
////    }
    

////    if (valid == true) {
////        var urlpath = '/CartonEntry/SaveChange';
////        $.ajax({
////            type: "Post",
////            data: JSON.stringify(_Carton),
////            contentType: "application/json; charset=utf-8",
////            dataType: 'json',
////            url: urlpath,
            
////            async: true,
////            success: function (result) {
////                if (result.isSuccess) {
////                    swal({
////                        title: 'Capex Saved Successfully!!',
////                        type: 'success',
////                        closeOnCancel: true
////                    },
////                        function () {
////                            window.location.href = '@Url.Action("CapexInformationView", "CapexApproval")';
////                        });
////                }
////            }
////        });
////    } else {
////        swal({
////            title: 'PLEASE ENTER ALL THE FIELD!!',
////            type: 'error',
////            closeOnCancel: true
////        });
////    }

////}