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

      public async Task<bool> Do(int stockId)
      {
         var stock = _context.Stocks.Find(stockId);

         if (stock is null)
            return false;
         
         _context.Stocks.Remove(stock);
         await _context.SaveChangesAsync();

         return true;
      }
   }
}
