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
    public class DetailsModel : PageModel
    {
        private readonly yyyy.Data.StockDBContext _context;

        public DetailsModel(yyyy.Data.StockDBContext context)
        {
            _context = context;
        }

      public Stock Stock { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stocks == null)
            {
                return NotFound();
            }

            var stock = await _context.Stocks.FirstOrDefaultAsync(m => m.StockId == id);
            if (stock == null)
            {
                return NotFound();
            }
            else 
            {
                Stock = stock;
            }
            return Page();
        }
    }
}
