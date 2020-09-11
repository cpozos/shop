using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Shop.UI.Controllers
{
   [Route("checkout/payment/success")]
   public class PaymentFullfillController : Controller
   {

      [HttpGet]
      public IActionResult Main()
      {
         return Ok();
      }

      [HttpPost]
      public async Task<IActionResult> Index()
      {
         var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

         //return Verify(json);

         return Ok();
      }

      /// Webhooks
      // You can find your endpoint's secret in your webhook settings
      const string secret = "whsec_...";
      public IActionResult Verify(string json)
      {
         try
         {
            var stripeEvent = EventUtility.ConstructEvent(
                json,
                Request.Headers["Stripe-Signature"],
                secret
            );

            return Ok();
         }
         catch (StripeException e)
         {
            return BadRequest();
         }
      }
   }
}
