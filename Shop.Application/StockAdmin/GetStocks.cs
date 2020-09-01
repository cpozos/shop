using Shop.Application.ViewModels;
using Shop.Database;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.StockAdmin
{
   public class GetStocks
   {
      private ApplicationDbContext _context;

      public GetStocks(ApplicationDbContext context)
      {
         _context = context;
      }

      public IEnumerable<StockViewModel> Do(int productId)
      {
         var stocks = _context.Stocks
            .Where(s => s.ProductId == productId)
            .Select(s => new StockViewModel
            {
               Id = s.Id,
               Description = s.Description,
               Quantity = s.Quantity
            })
            .ToList();

         return stocks;
      }
   }
}
