using Shop.Database;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
   public class DeleteProduct
   {
      private ApplicationDbContext _context;

      public DeleteProduct(ApplicationDbContext dbContext)
      {
         _context = dbContext;
      }
      public async Task<bool> Do(int id)
      {
         var product = await _context.Products.FindAsync(id);
         _context.Products.Remove(product);
         await _context.SaveChangesAsync();
         return true;
      }
   }
}
