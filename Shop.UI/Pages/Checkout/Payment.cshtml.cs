using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Cart;

namespace Shop.UI.Pages.Checkout
{
    public class PaymentModel : PageModel
    {
      public IActionResult OnGet()
      {
         var info = new GetCustomerInformation(HttpContext.Session).Do();

         if (info == null)
         {
            return RedirectToPage("/Checkout/CustomerInformation");
         }

         return Page();
      }
      
    }
}
