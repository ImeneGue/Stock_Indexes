using Microsoft.AspNetCore.SignalR;


namespace yyyy.Hubs

{
    public class StockHub : Hub
    {

        public async Task NewStock1()
        {
            await Clients.All.SendAsync("AddStock1");
        }


        public async Task SendMessage(int stockId, string nomStock, string indexShortCut, decimal prixActuel, decimal prixInitial)
        {
            await Clients.All.SendAsync("ReceiveMessage", stockId, nomStock, indexShortCut, prixActuel, prixInitial);
        }

        public async Task NewStock(string NomStock, string IndexShortCut, decimal PrixActuel, decimal PrixInitial)
        {
            await Clients.All.SendAsync("AddStock", NomStock, IndexShortCut, PrixActuel, PrixInitial);
        }

    }
}
