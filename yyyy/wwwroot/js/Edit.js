"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7148/stockHub").build();

document.getElementById("Save").disabled = true;


connection.start().then(function () {
    document.getElementById("Save").disabled = false;
    //document.getElementById("editsubmit").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

const uri = "/api/stocks";

//const uri = "https://localhost:7148/api/stocks";

document.getElementById("Save").addEventListener("click", function (event) {
    var stockId = document.getElementById("stockId").value;
    var nomStock = document.getElementById("nomStock").value;
    var indexShortCut = document.getElementById("indexShortCut").value;
    var prixInitial = document.getElementById("prixInitial").value;
    var prixActuel = document.getElementById("prixActuel").value;

    const stock =
    {
        stockId: stockId, nomStock: nomStock, indexShortCut: indexShortCut, prixInitial: prixInitial, prixActuel: prixActuel

    }

    var uri2 = uri + "/" + stockId;

    fetch(uri2, {
        method: 'PUT',
        
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(stock)
    })
        .then(response => response.json())
        .then(() => {
            //prixActuel = prixActuel + " ( reprise )"
            connection.invoke("NewStock1").catch(function (err) {
                return console.error(err.toString());
            });
            alert('Stock enregistré !')
        })
        //.catch(error => alert('Stock invalide ! Remplir tous les champs !'));

    event.preventDefault();
});