
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7148/stockHub").build();

//Disable the send button until connection is established.
document.getElementById("btsave").disabled = true;

connection.start().then(function () {
    document.getElementById("btsave").disabled = false;
    //document.getElementById("editsubmit").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

//const uri = "/api/stocks";
const uri = "https://localhost:7148/api/stocks";

document.getElementById("btsave").addEventListener("click", function (event) {
   // var stockId = document.getElementById("stockId").value;
    var nomStock = document.getElementById("nomStock").value;
    var indexShortCut = document.getElementById("indexShortCut").value;
    var prixActuel = document.getElementById("prixActuel").value;
    var prixInitial = document.getElementById("prixInitial").value;

    const stock =
    {
     //   stockId: stockId,
        nomStock: nomStock, indexShortCut: indexShortCut, prixInitial: prixInitial, prixActuel: prixActuel,
    };

    //var uri2 = uri + "/" + stocks ;
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(stock)
    })
        .then(response => response.json())
        .then(() => {
            // message = message + " ( reprise )"
            connection.invoke("NewStock1").catch(function (err) {
                return console.error(err.toString());
            });
            alert('stock de l équipe envoyé et enregistré !')
        })
        .catch(error => alert('stock invalide ! Remplir tous les champs !'));

    event.preventDefault();
});