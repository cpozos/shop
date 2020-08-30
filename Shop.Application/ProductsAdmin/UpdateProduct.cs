using Shop.Application.ViewModels;
using Shop.Database;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
   public class UpdateProduct
   {
      private ApplicationDbContext _context;

      public UpdateProduct(ApplicationDbContext dbContext)
      {
         _context = dbContext;
      }
      public async Task<ProductViewModel> Do(ProductViewModel vm)
      {
         await _context.SaveChangesAsync();
         return new ProductViewModel();
      }
   }
}
