using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Cart;
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
      public AddToCart.Request CartViewModel { get; set; }

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
         new AddToCart(HttpContext.Session).Do(CartViewModel);

         return RedirectToPage("Cart");
      }


      public class Test
      {
         public string Id { get; set; }
      }
   }
}
