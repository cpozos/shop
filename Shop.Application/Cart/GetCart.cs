using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shop.Database;
using Shop.Domain.Models;
using System.Linq;

namespace Shop.Application.Cart
{
   public class GetCart
   {
      private ISession _session;
      private ApplicationDbContext _context;

      public GetCart(ISession session, ApplicationDbContext context)
      {
         _session = session;
         _context = context;
      }

      public class Response
      {
         public string Name { get; set; }
         public string Price { get; set; }
         public int StockId { get; set; }
         public int Quantity { get; set; }
      }

      public Response Do()
      {
         var stringObject = _session.GetString("cart");
         var cartProduct =  JsonConvert.DeserializeObject<CartProduct>(stringObject);

         var response = _context.Stocks
            .Include(s=>s.Product)
            .Where(s => s.Id == cartProduct.StockId)
            .Select(s => new Response
            {
               Name = s.Product.Name,
               Price = s.Product.Price.ToString(),
               StockId = s.Id,
               Quantity = cartProduct.Quantity
            })
            .FirstOrDefault();

         return response;
      }
   }
}
