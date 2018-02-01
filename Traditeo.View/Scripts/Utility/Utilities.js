var Document = {
    PurchaseSuggestion: 60001,
    PurchaseRequests: 60002,
    QuotationRequest: 60003,
    PurchaseOrder: 60004,
    Purchases: 60005,
    PurchaseReturn: 60006
};

function MessageBox(message) {
    alert(message);
}

var applicationDateFormat = '';

function OnRowDblClick(s, e) {
    debugger;
    s.GetRowValues(e.visibleIndex, 'UniqueID', function (value) {
        //var NestId = $(this).data('id');
        //var url = "/Artists/Details?NestId=" + NestId;
        window.location.href = "../Purchase/Edit?id=" + value;

    });
}