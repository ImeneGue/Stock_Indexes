using Microsoft.EntityFrameworkCore;
using yyyy.Models;

namespace yyyy.Data
{
    public class StockDBContext : DbContext
    {

        public StockDBContext(DbContextOptions<StockDBContext> options) : base(options)
        {

        }
        public DbSet<Stock> Stocks { get; set; }

    }
}
