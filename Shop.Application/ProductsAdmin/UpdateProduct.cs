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
         var product = _context.Products.Find(vm.Id);

         if (product == null)
            return null;
         
         product.Name = vm.Name;
         product.Description = vm.Description;
         product.Price = vm.Price;

         await _context.SaveChangesAsync();
         return new ProductViewModel
         {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
         };
      }
   }
}
