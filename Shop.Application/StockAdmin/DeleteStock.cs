using Shop.Application.ViewModels;
using Shop.Database;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
   public class DeleteStock
   {
      private ApplicationDbContext _context;

      public DeleteStock(ApplicationDbContext context)
      {
         _context = context;
      }

      public async Task<StockViewModel> Do(StockViewModel request)
      {
         var stock = _context.Stocks.Find(request?.Id);

         if (stock is null)
            return null;

         _context.Stocks.Add(stock);
         await _context.SaveChangesAsync();

         return request;
      }
   }
}
