Browser = {
    LineID: 0,
    Warehouse: 1,
    ItemCode: 2,
    ItemLink: 3,
    ItemName: 4,
    Quantity: 5,
    BonusQuantity: 6,
    ItemCost: 7,
    ItemDiscountPercentage: 8,
    ItemDiscountAmount: 9,
    MarginPercentage: 10,
    MarginAmount: 11,
    DiscountPercentage: 12,
    DiscountAmount: 13,
    TotalCost: 14,
    TotalDiscount: 15,
    NetTotal:16,
    Naration: 17,
    TrackingTypeID:18,
    DeleteLink:19
}

var itemJson='';
var ledgerJson='';
var defaultWarehouseID = 0;
var defaultWarehouse = '';
var gridColumns = [];
var gridData = [];

var CommaFormatter = function (row, cell, value, columnDef, dataContext) {
    return parseFloat(value, 10).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1,").toString();
}

var deleteLinkFormatter = function (row, cell, value, columnDef, dataContext) {
    return "<a  href='javascript:' onclick='DeleteLineItem(" + dataContext.id + ");'  controltobindid='" + dataContext.id + "' title='Search Items' class='fa fa-external-link frameworkItemLookup' tabindex='0'></a>";
};


var linkFormatter = function (row, cell, value, columnDef, dataContext) {
    return "<a  href='javascript:' onclick='LoadItemHelp(" + dataContext.id + ");'  controltobindid='" + dataContext.id + "' title='Search Items' class='fa fa-external-link frameworkItemLookup' tabindex='0'></a>";
};

var gridOption = {
    editable: true,
    showHeaderRow: true,
    enableCellNavigation: true,
    asyncEditorLoading: true,
    topPanelHeight: 25,
    headerRowHeight: 25,
    rtl: direction
};

gridColumns = [
       { id: "LineID", name: "Line#", field: "id", sortable: true, width: 2 },
       { id: "Warehouse", name: "Warehouse", field: "Warehouse", width: 100, editor: Slick.Editors.ComboBox, idProperty: 'WarehouseID', cssClass: "inactivecell" },
       { id: "ItemCode", name: "Item Code", field: "ItemCode", sortable: true, width: 100, editor: Slick.Editors.Text },
       { id: "Link", name: "", field: "Link", sortable: false, width: 1, formatter: linkFormatter },
       { id: "ItemName", name: "Item Name", field: "ItemName", sortable: true, width: 200, editor: Slick.Editors.Auto },
       { id: "Quantity", name: "Quantity", field: "Quantity", width: 100, cssClass: "NumberCell QuantityCell", headerCssClass: "NumberCell", editor: Slick.Editors.Float },
       { id: "BonusQuantity", name: "Bonus", field: "BonusQuantity", width: 100, cssClass: "NumberCell", headerCssClass: "NumberCell", editor: Slick.Editors.Float },
       { id: "ItemCost", name: "ItemCost", field: "ItemCost", width: 100, cssClass: "NumberCell PriceCell", headerCssClass: "NumberCell", editor: Slick.Editors.Float },
       { id: "ItemDiscountPercentage", name: "Item Discount (%)", field: "ItemDiscountPercentage", width: 100, cssClass: "NumberCell inactivecell", headerCssClass: "NumberCell", editor: Slick.Editors.Float },
       { id: "ItemDiscountAmount", name: "Item Discount", field: "ItemDiscountAmount", width: 100, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter },
       { id: "MarginPercentage", name: "Margin(%)", field: "MarginPercentage", width: 100, cssClass: "NumberCell inactivecell", headerCssClass: "NumberCell", editor: Slick.Editors.Float },
       { id: "MarginAmount", name: "Margin", field: "MarginAmount", width: 100, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter },
       { id: "DiscountPercentage", name: "Discount (%)", field: "DiscountPercentage", width: 100, cssClass: "NumberCell inactivecell", headerCssClass: "NumberCell", editor: Slick.Editors.Float },
       { id: "DiscountAmount", name: "Discount", field: "DiscountAmount", width: 100, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter },
       { id: "TotalCost", name: "Total Cost", field: "TotalCost", width: 100, cssClass: "NumberCell TotalCell", headerCssClass: "NumberCell", formatter: CommaFormatter },
       { id: "TotalDiscount", name: "Total Discount", field: "TotalDiscount", width: 100, cssClass: "NumberCell",headerCssClass: "NumberCell", formatter: CommaFormatter },
       { id: "NetTotal", name: "Net Total", field: "NetTotal", width: 100, cssClass: "NumberCell NetTotalCell", headerCssClass: "NumberCell", formatter: CommaFormatter },
       { id: "Naration", name: "Naration", field: "Naration", sortable: true, width: 200, editor: Slick.Editors.Text },
       { id: "deletelink", name: "", field: "Link", sortable: false, width: 1, formatter: deleteLinkFormatter }
];

var direction = false;


function AddNewLine(id) {
    var d = gridData[id] = {};
    d["id"] = id + 1;
    d["LineID"] = id + 1;
    d['WarehouseID'] = defaultWarehouseID;
    d['Warehouse'] = defaultWarehouse;
    d["ItemCode"] = null;
    d["ItemName"] = null;
    d["Quantity"] = 0;
    d["BonusQuantity"] = 0;
    d["ItemCost"] = 0;
    d["ItemDiscountPercentage"] = 0;
    d["ItemDiscountAmount"] = 0;
    d["MarginPercentage"] = 0;
    d["MarginAmount"] = 0;
    d["DiscountPercentage"] = 0;
    d["DiscountAmount"] = 0;
    d["TotalCost"] = 0;
    d["TotalDiscount"] = 0;
    d["NetTotal"] = 0;
    d["Naration"] = '';
    d["TrackingTypeID"] = 0;
}

////function AddUpdateLine(id) {
////    var d = gridData[id] = {};
////    d["id"] = id;
////    d["LineID"] = id + 1;
////    d['WarehouseID'] = defaultWarehouseID;
////    d['Warehouse'] = defaultWarehouse;
////    d["ItemCode"] = null;
////    d["ItemName"] = null;
////    d["Quantity"] = 0;
////    d["BonusQuantity"] = 0;
////    d["ItemCost"] = 0;
////    d["ItemDiscountPercentage"] = 0;
////    d["ItemDiscountAmount"] = 0;
////    d["MarginPercentage"] = 0;
////    d["MarginAmount"] = 0;
////    d["DiscountPercentage"] = 0;
////    d["DiscountAmount"] = 0;
////    d["TotalCost"] = 0;
////    d["TotalDiscount"] = 0;
////    d["NetTotal"] = 0;
////    d["Naration"] = '';
////    d["TrackingTypeID"] = 0;
////}


function PopulateData(dataTable) {
    
    for (var i = 0; i < dataTable.length; i++)
    {
        var d = (gridData[i] = {});
        d["id"] = dataTable[i].id;
        d["LineID"] = dataTable[i].LineID;
        d['WarehouseID'] = dataTable[i].WarehouseID;
        d['Warehouse'] = dataTable[i].Warehouse;
        d["ItemID"] = dataTable[i].ItemID;
        d["ItemCode"] = dataTable[i].ItemCode;
        d["ItemName"] = dataTable[i].ItemName;
        d["Quantity"] = dataTable[i].Quantity;
        d["BonusQuantity"] = dataTable[i].BonusQuantity;
        d["ItemCost"] = dataTable[i].ItemCost;
        d["ItemDiscountPercentage"] = dataTable[i].ItemDiscountPercentage;
        d["ItemDiscountAmount"] = dataTable[i].ItemDiscountAmount;
        d["MarginPercentage"] = dataTable[i].MarginPercentage;
        d["MarginAmount"] = dataTable[i].MarginAmount;
        d["DiscountPercentage"] = dataTable[i].DiscountPercentage;
        d["DiscountAmount"] = dataTable[i].DiscountAmount;
        d["TotalCost"] = dataTable[i].TotalCost;
        d["TotalDiscount"] = dataTable[i].TotalDiscount;
        d["NetTotal"] = dataTable[i].NetTotal;
        d["Naration"] = dataTable[i].Naration;
        d["TrackingTypeID"] = dataTable[i].TrackingTypeID;
        AddNewLine(i + 1);
    }
    if (dataTable.length == 0) {
        AddNewLine(1);
    }
}

function GetWarehouses() {
    
    var branchid = branchID;
    var warehouseList=[];

    var host = localStorage.getItem("host");
    $.get(host + "/Home/GetWarehouse").done(function (responce) {
        for (var i = 0; i < responce.length; i++) {
            _itemArray = {};
            _itemArray.name = responce[i].Warehouse;
            _itemArray.value = responce[i].WarehouseID;
            warehouseList.push(_itemArray);
        }
        if (responce.length == 1) {
            defaultWarehouseID = warehouseList[0].value;
            defaultWarehouse = warehouseList[0].name;
        } else {
            defaultWarehouseID = 0;
            defaultWarehouse = '';
        }
        gridColumns[Browser.Warehouse].items = warehouseList;
    });
}

function AddLineItem() {
    
    if (gridDataView.getItems()[gridDataView.getItems().length - 1]['ItemCode'] != null) {
        var rowId = parseInt(gridDataView.getItems()[gridDataView.getItems().length - 1]['id']) + 1;
        var lineID = parseInt(gridDataView.getItems()[gridDataView.getItems().length - 1]['LineID']) + 1;
        var lineItem = {
            "id": rowId,"LineID" : lineID, "WarehouseID": defaultWarehouseID, "Warehouse": defaultWarehouse, "ItemCode": null, "ItemName": "", "Quantity": 0, "BonusQuantity": 0, "ItemCost": 0, "ItemDiscountPercentage": 0,
            "ItemDiscountAmount": 0, "MarginPercentage": 0, "MarginAmount": 0, "DiscountPercentage": 0, "DiscountAmount": 0, "TotalCost": 0, "TotalDiscount": 0, "NetTotal": 0, "Naration": ''
        };
        gridDataView.addItem(lineItem);
        gridDataView.updateItem(lineItem.id, lineItem);
    }
}

function GetItems(rowID, warehouseID) {
    setTimeout(function () {
        if (warehouseID == null) {
            var rowItem = gridDataView.getItemById(rowID)["WarehouseID"];
            warehouseID = gridDataView.getItemById(rowID)["WarehouseID"];
        }

        var conditionalField = {};
        conditionalField.ItemID = gridData[rowID]["ItemID"];
        conditionalField.ItemCode = gridData[rowID]["ItemCode"];
        var host = localStorage.getItem("host");

        $.get(host + "/Home/GetItems", JSON.stringify(conditionalField)).done(function (responce) {
            gridData[rowID]["WarehouseID"] = warehouseID;
            gridData[rowID]["ItemID"] = responce[0]["ItemID"];
            gridData[rowID]["ItemCode"] = responce[0]["ItemCode"];
            gridData[rowID]["ItemName"] = responce[0]["ItemName"];
            gridData[rowID]["ItemCost"] = responce[0]["ItemCost"];
            gridData[rowID]["Quantity"] = 0;
            gridData[rowID]["BonusQuantity"] = 10;
            gridData[rowID]["SampleQuantity"] = 0;
            gridData[rowID]["ItemDiscountPercentage"] = 0;
            gridData[rowID]["ItemDiscountAmount"] = 0;
            gridData[rowID]["MarginPercentage"] = 0;
            gridData[rowID]["MarginAmount"] = 0;
            gridData[rowID]["DiscountPercentage"] = 0;
            gridData[rowID]["DiscountAmount"] = 0;
            gridData[rowID]["TotalCost"] = 0;
            gridData[rowID]["TotalDiscount"] = 0;
            gridData[rowID]["NetTotal"] = 0;
            gridData[rowID]["TrackingTypeID"] = responce[0]["TrackingTypeID"];
            lineItemGrid.invalidateRow(rowID);
            lineItemGrid.render();
        });
            
        AddLineItem();
        lineItemGrid.setActiveCell(rowID, 3);
    }, 0);
}


function CalculateLineDiscount(rowID) {
    
    if (gridData[rowID]["Quantity"] != '' && parseFloat(gridData[rowID]["Quantity"]) != 0 && gridData[rowID]["ItemCost"] != '' && parseFloat(gridData[rowID]["ItemCost"]) != 0) {
        gridData[rowID]["TotalCost"] = parseFloat(gridData[rowID]["Quantity"]) * parseFloat(gridData[rowID]["ItemCost"].toString().replace(/,/g, ""));
    }

    if (gridData[rowID]["ItemDiscountPercentage"] > 0) {
        gridData[rowID]["ItemDiscountAmount"] = (parseFloat(gridData[rowID]["ItemDiscountPercentage"]) * parseFloat(gridData[rowID]["TotalCost"])) / 100;
    }
    else {
        gridData[rowID]["ItemDiscountAmount"] = 0;
    }

    if (gridData[rowID]["MarginPercentage"] > 0) {
        gridData[rowID]["MarginAmount"] = (parseFloat(gridData[rowID]["MarginPercentage"]) * (parseFloat(gridData[rowID]["TotalCost"]) - parseFloat(gridData[rowID]["ItemDiscountAmount"]))) / 100;
    }
    else {
        gridData[rowID]["MarginAmount"] = 0;
    }

    if (gridData[rowID]["DiscountPercentage"] > 0) {
        gridData[rowID]["DiscountAmount"] = (parseFloat(gridData[rowID]["DiscountPercentage"]) * (parseFloat(gridData[rowID]["TotalCost"]) - parseFloat(gridData[rowID]["ItemDiscountAmount"]) - parseFloat(gridData[rowID]["MarginAmount"]))) / 100;

    }
    else {
        gridData[rowID]["DiscountAmount"] = 0;
    }

    gridData[rowID]["TotalDiscount"] = parseFloat(gridData[rowID]["ItemDiscountAmount"]) + parseFloat(gridData[rowID]["MarginAmount"]) + parseFloat(gridData[rowID]["DiscountAmount"]);
    gridData[rowID]["NetTotal"] = parseFloat(gridData[rowID]["TotalCost"]) - parseFloat(gridData[rowID]["TotalDiscount"])

    lineItemGrid.invalidateRow(rowID);
    lineItemGrid.render();
}

function CalculateLineTotal() {
    var sumQuantity = 0;
    var sumBonusQuantity = 0;
    var sumItemDiscountAmount = 0;
    var sumMarginAmount = 0;
    var sumDiscountAmount = 0;
    var sumTotalCost = 0;
    var sumTotalDiscount = 0;
    var sumNetTotal = 0;


    for (var j = 0; j < gridDataView.getItems().length; j++) {
        sumQuantity += parseFloat(gridDataView.getItems()[j]['Quantity'].toString().replace(/,/g, ""));
        sumBonusQuantity += parseFloat(gridDataView.getItems()[j]['BonusQuantity'].toString().replace(/,/g, ""));
        sumItemDiscountAmount += parseFloat(gridDataView.getItems()[j]['ItemDiscountAmount'].toString().replace(/,/g, ""));
        sumMarginAmount += parseFloat(gridDataView.getItems()[j]['MarginAmount'].toString().replace(/,/g, ""));
        sumDiscountAmount += parseFloat(gridDataView.getItems()[j]['DiscountAmount'].toString().replace(/,/g, ""));
        sumTotalCost += parseFloat(gridDataView.getItems()[j]['TotalCost'].toString().replace(/,/g, ""));
        sumTotalDiscount += parseFloat(gridDataView.getItems()[j]['TotalDiscount'].toString().replace(/,/g, ""));
        sumNetTotal += parseFloat(gridDataView.getItems()[j]['NetTotal'].toString().replace(/,/g, ""));
    }

    $('<span class="floatleft">Total:</span>').appendTo($(lineItemGrid.getHeaderRowColumn("ItemName")).empty());
    $('<label id="QuantityLbl" class="NumberTotal">' + sumQuantity.toFixed(2) + '</label>').appendTo($(lineItemGrid.getHeaderRowColumn("Quantity")).empty());
    $('<label id="BonusQuantityLbl" class="NumberTotal">' + sumBonusQuantity.toFixed(2) + '</label>').appendTo($(lineItemGrid.getHeaderRowColumn("BonusQuantity")).empty());
    $('<label id="ItemDiscountAmountLbl" class="NumberTotal">' + sumItemDiscountAmount.toFixed(2) + '</label>').appendTo($(lineItemGrid.getHeaderRowColumn("ItemDiscountAmount")).empty());
    $('<label id="MarginAmountLbl" class="NumberTotal">' + sumMarginAmount.toFixed(2) + '</label>').appendTo($(lineItemGrid.getHeaderRowColumn("MarginAmount")).empty());
    $('<label id="DiscountAmountLbl" class="NumberTotal">' + sumDiscountAmount.toFixed(2) + '</label>').appendTo($(lineItemGrid.getHeaderRowColumn("DiscountAmount")).empty());
    $('<label id="TotalCostLbl" class="NumberTotal">' + sumTotalCost.toFixed(2) + '</label>').appendTo($(lineItemGrid.getHeaderRowColumn("TotalCost")).empty());
    $('<label id="TotalDiscountLbl" class="NumberTotal">' + sumTotalDiscount.toFixed(2) + '</label>').appendTo($(lineItemGrid.getHeaderRowColumn("TotalDiscount")).empty());
    $('<label id="NetTotalLbl" class="NumberTotal">' + sumNetTotal.toFixed(2) + '</label>').appendTo($(lineItemGrid.getHeaderRowColumn("NetTotal")).empty());

}

function BindPurchaseGrid() {
    gridDataView = new Slick.Data.DataView({ inlineFilters: true });
    lineItemGrid = new Slick.Grid("#TransactionGrid", gridDataView, gridColumns, gridOption);
    lineItemGrid.setSelectionModel(new Slick.RowSelectionModel());
    lineItemGrid.render();
    
    lineItemGrid.onCellChange.subscribe(function (e, args) {
        CalculateLineDiscount(args.row);
        CalculateLineTotal();
        if (args.cell == Browser.ItemCode) {
            if ($.trim(gridData[args.row]["ItemCode"]) == '' || gridData[args.row]["ItemCode"] == null) {
                lineItemGrid.invalidateRow(args.row);
                gridData[args.row]["ItemID"] = 0;
                gridData[args.row]["ItemCode"] = '';
                gridData[args.row]["ItemName"] = '';
                gridData[args.row]["ItemCost"] = 0;
                gridData[args.row]["Quantity"] = 0;
                gridData[args.row]["SampleQuantity"] = 0;
                gridData[args.row]["ItemDiscountPercentage"] = 0;
                gridData[args.row]["ItemDiscountAmount"] = 0;
                gridData[args.row]["MarginPercentage"] = 0;
                gridData[args.row]["MarginAmount"] = 0;
                gridData[args.row]["DiscountPercentage"] = 0;
                gridData[args.row]["DiscountAmount"] = 0;
                gridData[args.row]["TotalCost"] = 0;
                gridData[args.row]["TotalDiscount"] = 0;
                gridData[args.row]["NetTotal"] = 0;
                gridData[args.row]["TrackingTypeID"] = 0;
                lineItemGrid.render();
            }
            else
                GetItems(args.row);
        }

    });

    lineItemGrid.onBeforeEditCell.subscribe(function (e, args) {
        if (args.cell == Browser.Quantity && gridData[args.row].TrackingTypeID == "12") {
            LoadBatchItem(args.row, parseInt(gridData[args.row]["ItemID"]), parseInt(gridData[args.row]["LineID"]))
        }
    });

    gridDataView.onRowCountChanged.subscribe(function (e, args) {
        lineItemGrid.updateRowCount();
        lineItemGrid.invalidate();
        lineItemGrid.render();
    });
    gridDataView.onRowsChanged.subscribe(function (e, args) {
        lineItemGrid.invalidateRows(args.rows);
        lineItemGrid.invalidate();
        lineItemGrid.render();
    });

    gridDataView.beginUpdate();
    gridDataView.setItems(gridData);
    gridDataView.endUpdate();
}


function DeleteLineItem(rowID) {

    var rowItem = gridDataView.getItemById(rowID);
    var lineID = rowItem['LineID'];

    gridDataView.beginUpdate();
    gridDataView.deleteItem(rowID);

    $.each(ledgerJson, function (i, el) {
        if (this.LineID == lineID) {
            ledgerJson.splice(i, 1);
        }
    });

    $.each(itemJson, function (i, el) {
        if (this.LineID == lineID) {
            itemJson.splice(i, 1);
        }
    });
    for (var i= rowID; i < gridDataView.getItems().length; i++) {
        if (gridDataView.getItems()[i]['id'] != undefined) 
            gridDataView.getItems()[i]['id'] = parseInt(gridDataView.getItems()[i]['id']) - 1;

        if (itemJson[i] != undefined)
            itemJson[i]["id"] = parseInt(itemJson[i]["id"]) - 1;
    }

    gridDataView.endUpdate();
    if (gridDataView.getItems().length == 0) {
        AddNewLine(0);
    }
    CalculateLineTotal();
}


function SetBatchQuantity(obj) {
    var rowID = $("#RowIDHdn").val();
    lineItemGrid.invalidateRow(rowID);
    gridData[rowID]['Quantity'] = parseFloat($('#BatchQuantityLbl').text());
    gridData[rowID]['BonusQuantity'] = parseFloat($('#BatchBonusQuantityLbl').text());
    gridData[rowID]['ItemCost'] = parseFloat($('#BatchPurchasePriceLbl').text());
    
    lineItemGrid.render();
    CalculateLineDiscount(rowID);
    CalculateLineTotal();
    $('#LookupDiv').dialog('close');
}

function LoadBatchItem(rowID, itemID, lineID) {
    if (itemID > 0) {
        $("#LookupDiv").dialog({
            autoOpen: false,
            width: 1000,
            height: 600,
            modal: true,
            title: "Item Batches"
        });

        var parameter = {};
        parameter.rowID = rowID;
        parameter.itemID = itemID;
        parameter.lineID = lineID;

        var host = localStorage.getItem("host");

        $.ajax({
            type: "POST",
            url: host + "/Home/CreateBatchLookup",
            data: JSON.stringify(parameter),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (response) {
                $('#LookupDiv').html(response);
                $('#LookupDiv').dialog('open');
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
}

function LoadItemHelp(rowID) {
    var rowItem = gridDataView.getItemById(rowID);
    var warehouseID = rowItem['WarehouseID'];
    if (warehouseID > 0) {
        $("#LookupDiv").dialog({
            autoOpen: false,
            width: 900,
            height: 500,
            modal: true,
            title: "Search Items"
        });

        var parameter = {};
        parameter.rowID = rowID;
        parameter.warehouseID = warehouseID;

        var host = localStorage.getItem("host");

        $.ajax({
            type: "POST",
            url: host + "/Home/ItemLookup",
            data: JSON.stringify(parameter),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (response) {
                $('#LookupDiv').html(response);
                $('#LookupDiv').dialog('open');
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
}


$(document).ready(function () {
    $('#PurchaseDate').datepicker({ dateFormat: applicationDateFormat });
    $('#DueDate').datepicker({ dateFormat: applicationDateFormat });

    GetWarehouses();
    itemJson = JSON.parse(transactionItemJson.replace(/&quot;/g, '"'));
    ledgerJson = JSON.parse(transactionLedgerJson.replace(/&quot;/g, '"'));
    
    PopulateData(itemJson);
    BindPurchaseGrid(gridColumns, gridData);
    CalculateLineTotal();
});

