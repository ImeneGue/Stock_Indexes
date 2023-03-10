using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using yyyy.Data;
using yyyy.Models;

namespace yyyy.Pages.Stocks
{
    public class IndexModel : PageModel
    {
        private readonly yyyy.Data.StockDBContext _context;

        public IndexModel(yyyy.Data.StockDBContext context)
        {
            _context = context;
        }

        public IList<Stock> Stock { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stocks != null)
            {
                Stock = await _context.Stocks.ToListAsync();
            }
        }
    }
}
