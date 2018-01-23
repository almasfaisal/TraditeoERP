
var lookupData = [];
var ItemsLookUpdataView;

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

function BindItemGrid(columns, data) {
    gridDataView = new Slick.Data.DataView({ inlineFilters: true });
    itemGrid = new Slick.Grid("#ItemGrid", gridDataView, columns, gridOptions);
    itemGrid.setSelectionModel(new Slick.RowSelectionModel());
    itemGrid.render();

    gridDataView.onRowCountChanged.subscribe(function (e, args) {
        itemGrid.updateRowCount();
        itemGrid.invalidate();
        itemGrid.render();
    });
    gridDataView.onRowsChanged.subscribe(function (e, args) {
        itemGrid.invalidateRows(args.rows);
        itemGrid.invalidate();
        itemGrid.render();
    });

    gridDataView.beginUpdate();
    gridDataView.setItems(data);
    gridDataView.endUpdate();
}

//function ShowItemLookup(warehouseID, rowID) {
//    var host = localStorage.getItem("host");
//    $.get(host + "/Home/GetItems").done(function (responce) {
//        lookupData = responce;
//        alert(lookupData[3].ItemCode);
//        alert(lookupData[3].ItemName);
//    });
//}

$(document).ready(function () {
    var host = localStorage.getItem("host");
    $.get(host + "/Home/GetItems").done(function (responce) {
        lookupData = responce;
        BindItemGrid(lookupColumns, lookupData);
    });

});

