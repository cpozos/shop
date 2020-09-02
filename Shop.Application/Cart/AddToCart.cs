using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Domain.Models;

namespace Shop.Application.Cart
{
   public class AddToCart
   {
      private ISession _session;

      public AddToCart(ISession session)
      {
         _session = session;
      }

      public class Request
      {
         public int StockId { get; set; }
         public int Quantity { get; set; }
      }

      public void Do(Request request)
      {
         var cartProduct = new CartProduct
         {
            StockId = request.StockId,
            Quantity = request.Quantity
         };

         var stringObject = JsonConvert.SerializeObject(request);

         //TODO: appending the cart

         _session.SetString("cart", stringObject);
      }
   }
}
