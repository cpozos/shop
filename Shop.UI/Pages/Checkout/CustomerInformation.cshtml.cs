using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Database;
using Shop.Application.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Shop.UI.Pages.Checkout
{
   public class CustomerInformationModel : PageModel
   {
      [BindProperty]
      public AddCustomerInformation.Request CustomerInformation { get; set; }

      public IActionResult OnGet()
      {
         var info = new GetCustomerInformation(HttpContext.Session).Do();

         if(info == null)
         {
            return Page();
         }
         else
         {
            return RedirectToPage("/checkout/Payment");
         }
      }

      public IActionResult OnPost()
      {
         if (!ModelState.IsValid)
         {
            return Page();
         }

         new AddCustomerInformation(HttpContext.Session).Do(CustomerInformation);

         return RedirectToPage("/checkout/Payment");
      }
   }
}
