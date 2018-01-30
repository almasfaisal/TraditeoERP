/// <reference path="../Utility/Utilities.js" />

var batchData = [];
var itemBatchData = [];

var BatchBrowser = {
    BatchNumber: 0,
    SerialNumber: 1,
    ExpiryDate: 2,
    PurchasePrice: 3,
    SalePrice: 4
}

var batchGridOptions = {
    editable: true,
    showHeaderRow: true,
    enableCellNavigation: true,
    asyncEditorLoading: true,
    forceFitColumns: true,
    topPanelHeight: 25,
    headerRowHeight: 25
};

var batchColumns = [
    { id: "BatchNumber", name: "Batch Number", field: "BatchNumber", width: 60 },
    { id: "SerialNumber", name: "Serial Number", field: "SerialNumber", width: 60 },
    { id: "ExpiryDate", name: "Expiry Date", field: "DisplayExpiryDate", width: 100 },
    { id: "Quantity", name: "Quantity", field: "Quantity", width: 70, cssClass: "NumberCell", headerCssClass: "NumberCell", editor: Slick.Editors.Float, formatter: CommaFormatter },
    { id: "BonusQuantity", name: "Bonus Quantity", field: "BonusQuantity", width: 70, cssClass: "NumberCell", headerCssClass: "NumberCell", editor: Slick.Editors.Float, formatter: CommaFormatter },
    { id: "PurchasePrice", name: "Purchase Price", field: "PurchasePrice", width: 70, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter },
    { id: "SalePrice", name: "Sale Price", field: "SalePrice", width: 70, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter }
];

var itemBatchColumns = [
    { id: "Sno", name: "S.No.", field: "Sno", sortable: true, width: 25 },
    { id: "BatchNumber", name: "Batch Number", field: "BatchNumber", width: 80 },
    { id: "SerialNumber", name: "Serial Number", field: "SerialNumber", width: 80 },
    { id: "ExpiryDate", name: "Expiry Date", field: "DisplayExpiryDate", width: 80 },
    { id: "PurchasePrice", name: "Purchase Price", field: "PurchasePrice", width: 80, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter },
    { id: "SalePrice", name: "Sale Price", field: "SalePrice", width: 80, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter }
];

function CalculateTotal() {
    var Quantity = 0;
    var BonusQuantity = 0;
    var PurchasePrice = 0;
    var SalePrice = 0;

    for (var j = 0; j < batchDataView.getItems().length; j++) {
        Quantity += parseFloat(batchDataView.getItems()[j]['Quantity'].toString().replace(/,/g, ""));
        BonusQuantity += parseFloat(batchDataView.getItems()[j]['BonusQuantity'].toString().replace(/,/g, ""));
        PurchasePrice += parseFloat(batchDataView.getItems()[j]['PurchasePrice'].toString().replace(/,/g, "")) * Quantity;
        SalePrice += parseFloat(batchDataView.getItems()[j]['SalePrice'].toString().replace(/,/g, "")) * Quantity;
    }
    
    $('<span class="floatleft">Total:</span>').appendTo($(batchGrid.getHeaderRowColumn("ExpiryDate")).empty());
    $('<label id="BatchQuantityLbl" class="NumberTotal">' + Quantity + '</label>').appendTo($(batchGrid.getHeaderRowColumn("Quantity")).empty());
    $('<label id="BatchBonusQuantityLbl" class="NumberTotal">' + BonusQuantity + '</label>').appendTo($(batchGrid.getHeaderRowColumn("BonusQuantity")).empty());
    $('<label id="BatchPurchasePriceLbl" class="NumberTotal">' + (PurchasePrice / Quantity).toFixed(2) + '</label>').appendTo($(batchGrid.getHeaderRowColumn("PurchasePrice")).empty());
    $('<label id="BatchSalePriceLbl" class="NumberTotal">' + (SalePrice / Quantity).toFixed(2) + '</label>').appendTo($(batchGrid.getHeaderRowColumn("SalePrice")).empty());
}

function BindBatchGrid() {
    batchDataView = new Slick.Data.DataView({ inlineFilters: true });
    batchGrid = new Slick.Grid("#BatchGrid", batchDataView, batchColumns, batchGridOptions);
    batchGrid.setSelectionModel(new Slick.RowSelectionModel());
    batchGrid.render();

    batchGrid.onCellChange.subscribe(function (e, args) {
        CalculateTotal();
    });

    batchDataView.onRowCountChanged.subscribe(function (e, args) {
        batchGrid.updateRowCount();
        batchGrid.invalidate();
        batchGrid.render();
    });
    batchDataView.onRowsChanged.subscribe(function (e, args) {
        batchGrid.invalidateRows(args.rows);
        batchGrid.invalidate();
        batchGrid.render();
    });

    batchDataView.beginUpdate();
    batchDataView.setItems(batchData);
    batchDataView.endUpdate();
}

function BindItemBatchGrid() {
    itemBatchDataView = new Slick.Data.DataView({ inlineFilters: true });
    itemBatchGrid = new Slick.Grid("#ItemBatchGrid", itemBatchDataView, itemBatchColumns, batchGridOptions);
    itemBatchGrid.setSelectionModel(new Slick.RowSelectionModel());
    itemBatchGrid.render();

    itemBatchDataView.onRowCountChanged.subscribe(function (e, args) {
        itemBatchGrid.updateRowCount();
        itemBatchGrid.invalidate();
        itemBatchGrid.render();
    });
    itemBatchDataView.onRowsChanged.subscribe(function (e, args) {
        itemBatchGrid.invalidateRows(args.rows);
        itemBatchGrid.invalidate();
        itemBatchGrid.render();
    });
    
    itemBatchGrid.onClick.subscribe(function (e, args) {
        $('#BatchNumberTxt').val(itemBatchDataView.getItems()[args.row]['BatchNumber']);
        $('#SerailNumberTxt').val(itemBatchDataView.getItems()[args.row]['SerialNumber']);
        $('#ExpiryDateDtp').val(itemBatchDataView.getItems()[args.row]['DisplayExpiryDate']);
        $('#QuantityTxt').val(0);
        $('#BonusQuantityTxt').val(0);
        $('#PurchasePriceTxt').val(itemBatchDataView.getItems()[args.row]['PurchasePrice']);
        $('#SalePriceTxt').val(itemBatchDataView.getItems()[args.row]['SalePrice']);
    });

    itemBatchDataView.beginUpdate();
    itemBatchDataView.setItems(itemBatchData);
    itemBatchDataView.endUpdate();
}

function AddBatchItems() {
    
    var batchItem = {
        id: ledgerJson.length + 1,
        LineID: parseInt($("#LineIDHdn").val()),
        BatchNumber: $.trim($('#BatchNumberTxt').val()),
        SerialNumber: $('#SerailNumberTxt').val(),
        ExpiryDate: new Date($('#ExpiryDateDtp').val()),
        DisplayExpiryDate: $('#ExpiryDateDtp').val(),
        Quantity: parseFloat($('#QuantityTxt').val()),
        BonusQuantity: parseFloat($('#BonusQuantityTxt').val()),
        PurchasePrice: parseFloat($('#PurchasePriceTxt').val()),
        SalePrice: parseFloat($('#SalePriceTxt').val()),
        DimensionItemID: null,
        InventoryTypeID: 6,
        ItemBatchID: null,
        ItemID: parseInt($("#ItemIDHdn").val()),
        ItemSerialID: null,
        ManufactureDate: null,
        ReferenceID: 0,
        SampleQuantity: 0,
        TransactionDate: null,
        TransactionLedgerID: 7544894,
        WarehouseID: 0,
        DocumentID: 168,
        BranchID: 0
    };
    ledgerJson.push(batchItem);

    batchData = ledgerJson.filter(function (ledger) {
        return ledger.LineID === parseInt($("#LineIDHdn").val());
    });
    BindBatchGrid();
    CalculateTotal();
}

$(document).ready(function () {

    batchData = ledgerJson.filter(function (ledger) {
        return ledger.LineID === parseInt($("#LineIDHdn").val());
    });
    
    var conditionalField = {};
    conditionalField.ItemID = $("#ItemIDHdn").val();
    conditionalField.Document = Document.Purchases;
    
    var host = localStorage.getItem("host");
    $.get(host + "/Home/GetBatches", JSON.stringify(conditionalField)).done(function (responce) {
        BindBatchGrid();
        CalculateTotal();
        itemBatchData = responce;
        BindItemBatchGrid();
    });
});

