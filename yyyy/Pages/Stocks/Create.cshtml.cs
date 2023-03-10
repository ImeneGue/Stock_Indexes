using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using yyyy.Data;
using yyyy.Models;

namespace yyyy.Pages.Stocks
{
    public class CreateModel : PageModel
    {
        private readonly yyyy.Data.StockDBContext _context;

        public CreateModel(yyyy.Data.StockDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Stock Stock { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stocks.Add(Stock);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
