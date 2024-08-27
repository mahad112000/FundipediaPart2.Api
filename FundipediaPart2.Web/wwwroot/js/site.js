
$("#btnOrderProcess").on('click', processOrder
);

function processOrder() {
    var order = {
        IsLargeOrder: $("#IsLargeOrder").is(':checked'),
        IsNewCustomer: $("#IsNewCustomer").is(':checked'),
        IsRushOrder: $("#IsRushOrder").is(':checked'), Type: $("#drpType").val()
    };
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(order)
    };
    fetch('https://localhost:44302/api/Order', requestOptions)
        .then(function (response) {
            if (response.status !== 200) {
                console.log(
                    'Looks like there was a problem. Status Code: ' + response.status
                );
                return response.text();
            }
            response.json().then(function (data) {
                console.log(data);
                $("#orderStatus").text(data);
            });
        })
        .catch(function (err) {
            console.log('Fetch Error :-S', err);
        });
    return false;
}

