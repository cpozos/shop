using Shop.Application.ViewModels;
using Shop.Database;
using Shop.Domain.Models;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
   public class CreateProduct
   {
      private ApplicationDbContext _context;

      public CreateProduct(ApplicationDbContext dbContext)
      {
         _context = dbContext;
      }
      public async Task<ProductViewModel> Do(ProductViewModel vm)
      {
         var product = new Product
         {
            Name = vm.Name,
            Description = vm.Description,
            Price = vm.Price
         };

         _context.Products.Add(product);

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
