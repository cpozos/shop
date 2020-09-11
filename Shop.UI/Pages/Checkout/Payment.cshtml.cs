using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Shop.Application.Cart;
using Stripe;
using Stripe.Checkout;
using System.Collections.Generic;

namespace Shop.UI.Pages.Checkout
{
    public class PaymentModel : PageModel
    {
      public string PublicKey { get; private set; }

      public PaymentModel(IConfiguration configuration)
      {
         PublicKey= configuration["Stripe:PublicKey"].ToString();
      }

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
