using Shop.Application.ViewModels;
using Shop.Database;
using Shop.Domain.Models;
using System.Threading.Tasks;

namespace Shop.Application.Products
{
   public class CreateProduct
   {
      private ApplicationDbContext _context;

      public CreateProduct(ApplicationDbContext dbContext)
      {
         _context = dbContext;
      }
      public async Task Do(ProductViewModel vm)
      {
         _context.Products.Add(new Product
         {
            Name = vm.Name,
            Description = vm.Description, 
            Price = vm.Price
         });

         await _context.SaveChangesAsync();
      }
   }
}
