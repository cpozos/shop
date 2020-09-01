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

      public async Task<IEnumerable<StockViewModel>> Do(ICollection<StockViewModel> request)
      {
         if (!(request?.Count > 0))
            return null;

         // Mapping
         var stocks = new List<Stock>();
         foreach (var stock in request)
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

         return request;
      }
   }
}
