using Shop.Database;
using System.Threading.Tasks;
using Shop.Application.ViewModels;
using Shop.Domain.Models;

namespace Shop.Application.StockAdmin
{
   public class CreateStock
   {
      private ApplicationDbContext _context;

      public CreateStock(ApplicationDbContext context)
      {
         _context = context;
      }

      public async Task<StockViewModel> Do(StockViewModel request)
      {
         if (request is null)
            return null;

         // Mapping
         var stock = new Stock
         {
            Description = request.Description,
            ProductId = request.ProductId,
            Quantity = request.Quantity
         };

         _context.Stocks.Add(stock);
         await _context.SaveChangesAsync();

         return request;
      }
   }
}
