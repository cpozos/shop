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
         if (!(request?.Stocks?.Count > 0))
            return null;

         // Mapping
         var stocks = new List<Stock>();
         foreach (var stock in request.Stocks)
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
            Stocks = request.Stocks
         };
      }


      public class Request
      {
         public ICollection<StockViewModel> Stocks { get; set; }
      }

      public class Response
      {
         public IEnumerable<StockViewModel> Stocks { get; set; }
      }
   }
}
