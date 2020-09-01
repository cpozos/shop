using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Products;
using Shop.Application.ViewModels;
using Shop.Database;

namespace Shop.UI.Pages
{
   public class ProductModel : PageModel
   {
      private ApplicationDbContext _context;

      public ProductViewModel Product { get; set; }

      [BindProperty]
      public Test ProductTest { get; set; }

      public ProductModel(ApplicationDbContext context)
      {
         _context = context;  
      }

      public IActionResult OnGet(string name)
      {
         Product = new GetProduct(_context).Do(name.Replace("-"," "));

         if (Product is null)
            return RedirectToPage("Index");
         else
            return Page();
      }

      public IActionResult OnPost()
      {
         var currentId = HttpContext.Session.GetString("id");

         HttpContext.Session.SetString("id", ProductTest.Id);

         return RedirectToPage("Index");
      }


      public class Test
      {
         public string Id { get; set; }
      }
   }
}
