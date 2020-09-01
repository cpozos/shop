using Shop.Application.ViewModels;
using Shop.Database;
using Shop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
   public class UpdateStock
   {
      private ApplicationDbContext _context;

      public UpdateStock(ApplicationDbContext context)
      {
         _context = context;
      }

      public async Task<Response> Do(Request request)
      {
         if (!(request?.Stock?.Count > 0))
            return null;

         // Mapping
         var stocks = new List<Stock>();
         foreach (var stock in request.Stock)
         {
            stocks.Add(new Stock
            {
               Id = stock.Id,
               Description = stock.Description,
               Quantity = stock.Quantity,
               ProductId = stock.ProductId
            });
         }

         _context.Stocks.UpdateRange(stocks);
         await _context.SaveChangesAsync();

         return new Response
         {
            Stock = request.Stock
         };
      }


      public class Request
      {
         public ICollection<StockViewModel> Stock { get; set; }
      }

      public class Response
      {
         public IEnumerable<StockViewModel> Stock { get; set; }
      }
   }
}
