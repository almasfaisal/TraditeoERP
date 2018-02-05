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

function GetDateFormate(displayDate) {
    
    if (displayDate != "") {
        var splitchar = displayDate.charAt(2);

        var dateArray = displayDate.split(splitchar);
        var year = dateArray[2];
        var month = '';
        var day = '';

        if (applicationDateFormat.charAt(0) == 'd') {
            day = dateArray[0];
            month = parseInt(dateArray[1], 0) - 1;
        }
        else if (applicationDateFormat.charAt(0) == 'M') {
            day = dateArray[1];
            month = parseInt(dateArray[0], 0) - 1;
        }
        return new Date(year, month, day, 0, 0, 0, 0);
    }
    else
        return "";
}
