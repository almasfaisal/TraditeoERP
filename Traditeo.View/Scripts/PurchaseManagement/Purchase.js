Browser = {
    Sno: 0,
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
    DeleteLink:18
}

var defaultWarehouseID = 0;
var defaultWarehouse = '';
var _warehouseArray;
var Purchasecolumns = [];
var Purchasedata = [];

var CommaFormatter = function (row, cell, value, columnDef, dataContext) {
    return parseFloat(value, 10).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1,").toString();
}
var deletelinkFormatter = function (row, cell, value, columnDef, dataContext) {
    return "<div class='removeicon_wrap'><a href='javascript:' onclick='DeletePurchaseGridRow(" + dataContext.id + ");'  gridrowid='" + row + "' class='icon-remove-sign silkgridrowdelete' tabindex='0'></a></div>";
};

var linkFormatter = function (row, cell, value, columnDef, dataContext) {
    return "<a  href='javascript:' onclick='LoadItemHelp(" + dataContext.id + ");'  controltobindid='" + dataContext.id + "' title='Search Items' class='fa fa-external-link frameworkItemLookup' tabindex='0'></a>";
};

var purchasegridoptions = {
    editable: true,
    showHeaderRow: true,
    enableCellNavigation: true,
    asyncEditorLoading: true,
    topPanelHeight: 25,
    headerRowHeight: 25,
    rtl: direction
};

Purchasecolumns = [
       { id: "Sno", name: "#", field: "Sno", sortable: true, width: 2 },
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
       { id: "deletelink", name: "", field: "link", sortable: false, width: 1, formatter: deletelinkFormatter }
];

var direction = false;


function AddNewLine(id) {
    Purchasedata = [];
    var d = (Purchasedata[0] = {});
    d["id"] = id;
    d["Sno"] = id + 1;
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
}

function AddUpdateLine(id) {
    var d = Purchasedata[id] = {};
    d["id"] = id;
    d["Sno"] = id + 1;
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
}


function PopulateData(dataTable) {
    
    for (var i = 0; i < dataTable.length; i++)
    {
        var d = (Purchasedata[i] = {});
        d["id"] = i;
        d["Sno"] = i + 1;
        d['WarehouseID'] = dataTable[i].WarehouseID;
        d['Warehouse'] = dataTable[i].Warehouse;
        d["ItemId"] = dataTable[i].ItemID;
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
        AddUpdateLine(i + 1);
    }
}

function GetWarehouses() {
    
    var branchid = branchID;

    //var host = $(location).attr('protocol') + "\\\\" + $(location).attr('host');
    var host = localStorage.getItem("host");
    $.get(host + "/Home/GetWarehouse").done(function (responce) {
        
        _warehouseArray = [];
        for (var i = 0; i < responce.length; i++) {
            _itemArray = {};
            _itemArray.name = responce[i].Warehouse;
            _itemArray.value = responce[i].WarehouseID;
            _warehouseArray.push(_itemArray);
        }
        if (responce.length == 1) {
            defaultWarehouseID = _warehouseArray[0].value;
            defaultWarehouse = _warehouseArray[0].name;
        } else {
            defaultWarehouseID = 0;
            defaultWarehouse = '';
        }
        Purchasecolumns[Browser.Warehouse].items = _warehouseArray;
    });
}

function CalculateLineDiscount(rowid) {
    if (Purchasedata[rowid]["Quantity"] != '' && parseFloat(Purchasedata[rowid]["Quantity"]) != 0 && Purchasedata[rowid]["ItemCost"] != '' && parseFloat(Purchasedata[rowid]["ItemCost"]) != 0) {
        Purchasedata[rowid]["TotalCost"] = parseFloat(Purchasedata[rowid]["Quantity"]) * parseFloat(Purchasedata[rowid]["ItemCost"].toString().replace(/,/g, ""));
    }

    if (Purchasedata[rowid]["ItemDiscountPercentage"] > 0) {
        Purchasedata[rowid]["ItemDiscountAmount"] = (parseFloat(Purchasedata[rowid]["ItemDiscountPercentage"]) * parseFloat(Purchasedata[rowid]["TotalCost"])) / 100;
    }
    else {
        Purchasedata[rowid]["ItemDiscountAmount"] = 0;
    }

    if (Purchasedata[rowid]["MarginPercentage"] > 0) {
        Purchasedata[rowid]["MarginAmount"] = (parseFloat(Purchasedata[rowid]["MarginPercentage"]) * (parseFloat(Purchasedata[rowid]["TotalCost"]) - parseFloat(Purchasedata[rowid]["ItemDiscountAmount"]))) / 100;
    }
    else {
        Purchasedata[rowid]["MarginAmount"] = 0;
    }

    if (Purchasedata[rowid]["DiscountPercentage"] > 0) {
        Purchasedata[rowid]["DiscountAmount"] = (parseFloat(Purchasedata[rowid]["DiscountPercentage"]) * (parseFloat(Purchasedata[rowid]["TotalCost"]) - parseFloat(Purchasedata[rowid]["ItemDiscountAmount"]) - parseFloat(Purchasedata[rowid]["MarginAmount"]))) / 100;

    }
    else {
        Purchasedata[rowid]["DiscountAmount"] = 0;
    }

    Purchasedata[rowid]["TotalDiscount"] = parseFloat(Purchasedata[rowid]["ItemDiscountAmount"]) + parseFloat(Purchasedata[rowid]["MarginAmount"]) + parseFloat(Purchasedata[rowid]["DiscountAmount"]);
    Purchasedata[rowid]["NetTotal"] = parseFloat(Purchasedata[rowid]["TotalCost"]) - parseFloat(Purchasedata[rowid]["TotalDiscount"])

    purchasegrid.invalidateRow(rowid);
    purchasegrid.render();
}


function BindPurchaseGrid(_columns, _data) {
    purchasedataView = new Slick.Data.DataView({ inlineFilters: true });
    purchasegrid = new Slick.Grid("#TransactionGrid", purchasedataView, _columns, purchasegridoptions);
    purchasegrid.setSelectionModel(new Slick.RowSelectionModel());
    purchasegrid.render();
    
    purchasegrid.onCellChange.subscribe(function (e, args) {
        CalculateLineDiscount(args.row);

        //CalculateTotals();

        //if (args.cell == Browser.ItemCode) {
        //    if ($.trim(Purchasedata[args.row]["ItemCode"]) == '' || Purchasedata[args.row]["ItemCode"] == null) {
        //        purchasegrid.invalidateRow(args.row);

        //        Purchasedata[args.row]["itemid"] = 0;
        //        Purchasedata[args.row]["ItemCode"] = '';
        //        Purchasedata[args.row]["ItemName"] = '';
        //        Purchasedata[args.row]["UnitId"] = 0;
        //        Purchasedata[args.row]["UnitName"] = '';
        //        Purchasedata[args.row]["TrackingTypes"] = '';
        //        Purchasedata[args.row]["DimensionID"] = 0;
        //        Purchasedata[args.row]["Cost"] = 0;
        //        Purchasedata[args.row]["Factor"] = 1;

        //        Purchasedata[args.row]["BonusQuantity"] = 0;
        //        Purchasedata[args.row]["UpdateSalesPrice"] = 0;
        //        //Purchasedata[args.row]["SampleQuantity"] = 0;
        //        Purchasedata[args.row]["SalesPrice"] = 0;
        //        purchasegrid.render();
        //    }
        //    else
        //        GetItemDetails(args.row);
        //}
        //purchasegrid.invalidateRow(args.row);
        //purchasegrid.render();
    });

    purchasedataView.onRowCountChanged.subscribe(function (e, args) {
        purchasegrid.updateRowCount();
        purchasegrid.invalidate();
        purchasegrid.render();
    });
    purchasedataView.onRowsChanged.subscribe(function (e, args) {
        purchasegrid.invalidateRows(args.rows);
        purchasegrid.invalidate();
        purchasegrid.render();
    });
    purchasedataView.beginUpdate();
    purchasedataView.setItems(_data);
    purchasedataView.endUpdate();
}

function LoadItemHelp(rowID) {
    var rowItem = purchasedataView.getItemById(rowID);
    var warehouseID= rowItem['WarehouseID'];
    if (warehouseID > 0) {

        $("#LookupDiv").dialog({
            autoOpen: false,
            width: 900,
            height: 500,
            modal: true,
            title: "Search Items"
        });

        var host = localStorage.getItem("host");
        $.ajax({
            type: "POST",
            url: host + "/Home/ItemLookup",
            data: '{rowID: "' + rowID + '" }',
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

        //ShowItemLookup(warehouseID, rowID);
    }
}

$(document).ready(function () {
    GetWarehouses();
    var jsonobj = JSON.parse(transactionItemJson.replace(/&quot;/g, '"'));
    PopulateData(jsonobj);
    BindPurchaseGrid(Purchasecolumns, Purchasedata);
    //CalculateTotals();
});

