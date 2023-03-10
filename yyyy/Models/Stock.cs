using Microsoft.EntityFrameworkCore;

namespace yyyy.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public string NomStock { get; set; }
        public string IndexShortCut { get; set; }
        [Precision(20, 6)]
        public decimal PrixActuel { get; set; }
        [Precision(20, 6)]
        public decimal PrixInitial { get; set; }
        [Precision(20, 6)]
        public decimal Changement
        {
            get
            {
                    return  PrixInitial - PrixActuel;
            }
        }

        public double PercentChangement
        {
            get
            {
                return (double)Math.Round(Changement / PrixInitial, 4);
            }
        }
    }
}
