
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7148/stockHub").build();

//Disable the send button until connection is established.
document.getElementById("btdelete").disabled = true;

connection.start().then(function () {
    document.getElementById("btdelete").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

const uri = "/api/stocks";
document.getElementById("btdelete").addEventListener("click", function (event) {
    
    var stockId = document.getElementById("stockId").value;
   // var nomStock = document.getElementById("nomStock").value;
   // var indexShortCut = document.getElementById("indexShortCut").value;
  //  var prixActuel = document.getElementById("prixActuel").value;
   // var prixInitial = document.getElementById("prixInitial").value;

    const stock =
    {
        stockId: stockId,
      /*  nomStock: nomStock, indexShortCut: indexShortCut, prixInitial: prixInitial, prixActuel: prixActuel,*/
    };




    var uri2 = uri + "/" + stockId;
    fetch(uri2, {
        method: 'DELETE',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
    })
        .then(response => response.json())
        .then(() => {
            connection.invoke("NewStock1").catch(function (err) {
                return console.error(err.toString());
            });
            alert('stock supprimé !')
        })
        .catch(error => alert('Stock invalide ! Remplir tous les champs !'));

    event.preventDefault();
});