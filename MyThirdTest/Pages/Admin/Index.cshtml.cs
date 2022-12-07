using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyThirdTest.Data;
using MyThirdTest.Models;

namespace MyThirdTest.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly MyThirdTest.Data.ApplicationDbContext _context;

        public IndexModel(MyThirdTest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? ProductName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Name { get; set; }

        public async Task OnGetAsync()
        {
            var products = from m in _context.Products select m;


            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.ProductName.Contains(SearchString));
            }

             Product = await products.ToListAsync();
        }
    }
}
//Product = await _context.Products.ToListAsync();