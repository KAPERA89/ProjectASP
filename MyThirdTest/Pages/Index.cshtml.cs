using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyThirdTest.Models;

namespace MyThirdTest.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    private readonly MyThirdTest.Data.ApplicationDbContext _context;

    public IndexModel(MyThirdTest.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Product> Product { get; set; } = default!;

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

    //public void OnGet()
    //{

    //}
}

