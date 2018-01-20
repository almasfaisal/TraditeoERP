Browser = {
    Sno: 0,
    Warehouse: 1,
    ItemCode: 2,
    ItemName: 3,
    Receiving: 4,
    BonusQuantity: 5,
    Naration: 6
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
    return "<a  href='javascript:' onclick='LoadItemsInPopup(" + dataContext.id + ");'  controltobindid='" + dataContext.id + "' title='Search Items' class='icon-external-link frameworkItemLookup' tabindex='0'></a>";
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
       { id: "ItemCode", name: "ItemCode", field: "ItemCode", sortable: true, width: 60, editor: Slick.Editors.Text },
       { id: "Link", name: "", field: "Link", sortable: false, width: 1, formatter: linkFormatter },
       { id: "ItemName", name: "ItemName", field: "ItemName", sortable: true, width: 100, editor: Slick.Editors.Auto },
       { id: "Quantity", name: "Quantity", field: "Quantity", width: 40, cssClass: "NumberCell QuantityCell", editor: Slick.Editors.Float },
       { id: "BonusQuantity", name: "BonusQuantity", field: "BonusQuantity", width: 50, cssClass: "NumberCell", headerCssClass: "NumberCell", editor: Slick.Editors.Float },
       { id: "TotalDiscount", name: "TotalDiscount", field: "TotalDiscount", sortable: true, cssClass: "NumberCell inactivecell GrandTotalCell", headerCssClass: "NumberCell", showTotals: true, width: 70, formatter: CommaFormatter },
       { id: "Naration", name: "Naration", field: "Naration", sortable: true, width: 60, editor: Slick.Editors.Text },
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
    d["TotalDiscount"] = 0;
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
    d["TotalDiscount"] = 0;
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
        d["TotalDiscount"] = dataTable[i].TotalDiscount;
                AddUpdateLine(i + 1);
    }
}

function GetWarehouses() {
    
    var branchid = branchID;

    var host = $(location).attr('protocol') + "\\\\" + $(location).attr('host');
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


function BindPurchaseGrid(_columns, _data) {
    purchasedataView = new Slick.Data.DataView({ inlineFilters: true });
    purchasegrid = new Slick.Grid("#TransactionGrid", purchasedataView, _columns, purchasegridoptions);
    //purchasegrid.setSelectionModel(new Slick.RowSelectionModel());
    purchasegrid.render();
    
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

$(document).ready(function () {
    GetWarehouses();
    var jsonobj = JSON.parse(transactionItemJson.replace(/&quot;/g, '"'));
    PopulateData(jsonobj);
    BindPurchaseGrid(Purchasecolumns, Purchasedata);
    //CalculateTotals();
});
