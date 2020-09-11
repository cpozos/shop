
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;

namespace Shop.UI.Controllers
{
   public class PaymentsController : Controller
   {
      public PaymentsController(IConfiguration configuration)
      {
         StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"].ToString();
      }

      [HttpPost("create-checkout-session")]
      public IActionResult CreateCheckoutSession()
      {
         var options = new SessionCreateOptions
         {
            PaymentMethodTypes = new List<string>
            {
               "card",
            },
            LineItems = new List<SessionLineItemOptions>
           {
             new SessionLineItemOptions
             {
               PriceData = new SessionLineItemPriceDataOptions
               {
                 UnitAmount = 2000,
                 Currency = "usd",
                 ProductData = new SessionLineItemPriceDataProductDataOptions
                 {
                   Name = "Producto 1",
                 },

               },
               Quantity = 1,
             },
           },
            Mode = "payment",
            SuccessUrl = "https://localhost:44302/checkout/payment/success",
            CancelUrl = "https://localhost:44302/checkout/payment/success",
         };

         var service = new SessionService();
         Session session = service.Create(options);

         return new JsonResult(new { id = session.Id });
      }

      [HttpGet("create-checkout-session")]
      public IActionResult CreateCheckoutSessionGet()
      {
         var options = new SessionCreateOptions
         {
            PaymentMethodTypes = new List<string>
            {
               "card",
            },
            LineItems = new List<SessionLineItemOptions>
           {
             new SessionLineItemOptions
             {
               PriceData = new SessionLineItemPriceDataOptions
               {
                 UnitAmount = 2000,
                 Currency = "usd",
                 ProductData = new SessionLineItemPriceDataProductDataOptions
                 {
                   Name = "Producto 1",
                 },

               },
               Quantity = 1,
             },
           },
            Mode = "payment",
            SuccessUrl = "https://localhost:44302/checkout/payment/success",
            CancelUrl = "https://localhost:44302/checkout/payment/success",
         };

         var service = new SessionService();
         Session session = service.Create(options);

         return new JsonResult(new { id = session.Id });
      }
   }
}
