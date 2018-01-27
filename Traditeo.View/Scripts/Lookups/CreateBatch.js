
var batchData = [];
var itemBatchData = [];

var BatchBrowser = {
    BatchNumber: 0,
    SerialNumber: 1,
    ExpiryDate: 2,
    PurchasePrice: 3,
    SalesPrice: 4
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
    { id: "ExpiryDate", name: "Expiry Date", field: "ExpiryDate", width: 100 },
    { id: "Quantity", name: "Quantity", field: "Quantity", width: 70, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter },
    { id: "BonusQuantity", name: "Bonus Quantity", field: "BonusQuantity", width: 70, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter },
    { id: "PurchasePrice", name: "Purchase Price", field: "PurchasePrice", width: 70, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter },
    { id: "SalesPrice", name: "Sales Price", field: "SalesPrice", width: 70, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter }
];

var itemBatchColumns = [
    { id: "Sno", name: "S.No.", field: "Sno", sortable: true, width: 50 },
    { id: "BatchNumber", name: "Batch Number", field: "BatchNumber", width: 80 },
    { id: "SerialNumber", name: "Serial Number", field: "SerialNumber", width: 80 },
    { id: "ExpiryDate", name: "Expiry Date", field: "ExpiryDate", width: 80 },
    { id: "PurchasePrice", name: "Purchase Price", field: "PurchasePrice", width: 80, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter },
    { id: "SalesPrice", name: "Sales Price", field: "SalesPrice", width: 80, cssClass: "NumberCell", headerCssClass: "NumberCell", formatter: CommaFormatter }
];

function BindBatchGrid() {
    batchDataView = new Slick.Data.DataView({ inlineFilters: true });
    batchGrid = new Slick.Grid("#BatchGrid", batchDataView, batchColumns, batchGridOptions);
    batchGrid.setSelectionModel(new Slick.RowSelectionModel());
    batchGrid.render();

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
        $('#ExpiryDateDtp').val(itemBatchDataView.getItems()[args.row]['ExpiryDate']);
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
        id: 10251,
            BatchNumber: $.trim($('#BatchNumberTxt').val()),
            SerialNumber: $('#SerailNumberTxt').val(),
            ExpiryDate: $('#ExpiryDateDtp').val(),
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

    debugger;   
    ledgerJson.push(batchItem);

    batchData = ledgerJson.filter(function (ledger) {
        return ledger.ItemID === parseInt($("#ItemIDHdn").val());
    });
    BindBatchGrid();
}

$(document).ready(function () {
    batchData = ledgerJson.filter(function (ledger) {
        return ledger.ItemID === parseInt($("#ItemIDHdn").val());
    });
    
    var conditionalField = {};
    conditionalField.ItemID = $("#ItemIDHdn").val();
    
    var host = localStorage.getItem("host");
    $.get(host + "/Home/GetBatches", JSON.stringify(conditionalField)).done(function (responce) {
        BindBatchGrid();
        itemBatchData = responce;
        BindItemBatchGrid();
        
    });
});

