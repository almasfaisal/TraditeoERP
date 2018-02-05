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
    s.GetRowValues(e.visibleIndex, 'UniqueID', function (value) {
        var area = $('#ViewGrid').attr('area');
        window.location.href = localStorage.getItem("host") + "/" + area + "/" + $('#ViewGrid').attr('controller') + "/Edit?id=" + value;
    });
}