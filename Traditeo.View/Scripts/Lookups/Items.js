
var lookupData = [];

var ItemBrowser = {
    ItemCode: 0,
    ItemName: 1,
    ItemAlias: 2,
    BarCode: 3,
    SalePrice: 4,
    PurchasePrice: 5
}

var gridOptions = {
    editable: true,
    showHeaderRow: true,
    enableCellNavigation: true,
    asyncEditorLoading: true,
    forceFitColumns: true,
    topPanelHeight: 25,
    headerRowHeight: 25
};

var lookupColumns = [
    { id: "ItemCode", name: "Item Code", field: "ItemCode", width: 100 },
    { id: "ItemName", name: "Item Name", field: "ItemName", width: 75 },
    { id: "ItemAlias", name: "Item Alias", field: "ItemAlias", width: 75 },
    { id: "BarCode", name: "Bar Code", field: "BarCode", width: 100 },
    { id: "SalePrice", name: "Sale Price", field: "SalePrice", width: 75 },
    { id: "PurchasePrice", name: "Purchase Price", field: "PurchasePrice", width: 100 }
];

function BindItemGrid() {
    itemDataView = new Slick.Data.DataView({ inlineFilters: true });
    itemGrid = new Slick.Grid("#ItemGrid", itemDataView, lookupColumns, gridOptions);
    itemGrid.setSelectionModel(new Slick.RowSelectionModel());
    itemGrid.render();

    itemDataView.onRowCountChanged.subscribe(function (e, args) {
        itemGrid.updateRowCount();
        itemGrid.invalidate();
        itemGrid.render();
    });
    itemDataView.onRowsChanged.subscribe(function (e, args) {
        itemGrid.invalidateRows(args.rows);
        itemGrid.invalidate();
        itemGrid.render();
    });

    itemGrid.onClick.subscribe(function (e, args) {
        GetSelectionItems(args);
    });

    itemDataView.beginUpdate();
    itemDataView.setItems(lookupData);
    itemDataView.endUpdate();
}

function GetSelectionItems(args) {
    var rowID = $("#RowIDHdn").val();
    var warehouseID =$("#WarehouseIDHdn").val();
    lineItemGrid.invalidateRow(rowID);
    gridData[rowID]['ItemID'] = itemDataView.getItems()[args.row]['ItemID'];
    gridData[rowID]['ItemCode'] = itemDataView.getItems()[args.row]['ItemCode'];
    gridData[rowID]['ItemName'] = itemDataView.getItems()[args.row]['ItemName'];
    GetItems(rowID,warehouseID);
    lineItemGrid.render();
    //lineItemGrid.focus();
    $('#LookupDiv').dialog('close');
}

function SearchItems()
{
    var conditionalField = {};
    conditionalField.ItemCode = $("#ItemCodeTxt").val();
    conditionalField.ItemName = $("#ItemNameTxt").val();
    conditionalField.ItemAlias = $("#ItemAliasTxt").val();

    var host = localStorage.getItem("host");

    $.get(host + "/Home/GetItems", JSON.stringify(conditionalField)).done(function (responce) {
        lookupData = responce;
        BindItemGrid(lookupColumns, lookupData);
    });
}

$(document).ready(function () {
    var host = localStorage.getItem("host");
    $.get(host + "/Home/GetItems").done(function (responce) {
        lookupData = responce;
        BindItemGrid(lookupColumns, lookupData);
    });

});

