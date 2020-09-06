using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shop.Database;
using Shop.Domain.Models;
using System.Collections.Generic;
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

      public IEnumerable<Response> Do()
      {
         var stringObject = _session.GetString("cart");

         if(string.IsNullOrWhiteSpace(stringObject))
         {
            return new List<Response>();
         }

         var cartList =  JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);

         var response = _context.Stocks
            .Include(s=>s.Product).AsEnumerable()
            .Where(s => cartList.Any( cart => cart.StockId == s.Id))
            .Select(s => new Response
            {
               Name = s.Product.Name,
               Price = s.Product.Price.ToString(),
               StockId = s.Id,
               Quantity = cartList.FirstOrDefault(cart=>cart.StockId == s.Id).Quantity
            })
            .ToList();

         return response;
      }
   }
}
