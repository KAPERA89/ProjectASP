using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyThirdTest.Data;
using MyThirdTest.Models;

namespace MyThirdTest.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly MyThirdTest.Data.ApplicationDbContext _context;

        public CreateModel(MyThirdTest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var filename = new FileStream(Path.Combine(@"wwwroot/","images",ImageName),FileMode.Create);
                file[0].CopyTo(filename);
                Product.ProductImg = ImageName;
            }
            else if(Product.ProductImg == null && Product.ProductID == null)
            {
                Product.ProductImg = "Default.jpg";
            }
            else
            {
                Product.ProductImg = Product.ProductImg;
            }

          if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                return Page();
            }


            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
