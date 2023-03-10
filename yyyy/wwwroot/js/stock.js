

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7148/stockHub").build();


connection.on("AddStock1", function () {

   getStocks();

});


connection.start().then(
    function () {
        // document.getElementById("btVoirStocks").disabled = false;
        getStocks();
    }).catch(function (err) {
        return console.error(err.toString());
    });

//const uri = "/api/stocks";
const uri = "https://localhost:7148/api/stocks";


function getStocks() {
    var temp = "";
    fetch(uri)

        .then(response => response.json())

        .then(data =>
           
            data.forEach(stock => {

                console.log(stock);
                temp += "<tr>";
                /*    temp += "<td>" + stock.stockId + "</td>";*/
                temp += "<td>" + stock.nomStock + "</td>";
                temp += "<td>" + stock.indexShortCut + "</td>";
                temp += "<td>" + stock.prixInitial + "</td>";
                temp += "<td>" + stock.prixActuel + "</td>";
                temp += "<td>" + stock.changement + "</td>";
                temp += "<td>" + stock.percentChangement + "</td></tr>";
                // temp += "<td>" + itemData.employee_salary + "</td>";

                document.getElementById('stock1').innerHTML = temp;


                //var li = document.createElement("li");
                //document.getElementById("stocks").appendChild(li);

                //li.textContent = `${stock.nomStock} or ${stock.indexShortCut} opened at ${stock.prixActuel} and now it is ${stock.prixInitial}`;
                //s. stock
            }));
    //document.getElementById('stocks').innerHTML = temp;
    // document.getElementById('stocks').append(temp); 
    console.log(temp);
    // .catch (error => alert("Erreur retournée par l'API !");
}
