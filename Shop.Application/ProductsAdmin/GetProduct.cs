using Shop.Application.ViewModels;
using Shop.Database;

namespace Shop.Application.ProductsAdmin
{
   public class GetProduct
   {
      private ApplicationDbContext _context;

      public GetProduct(ApplicationDbContext dbContext)
      {
         _context = dbContext;
      }

      public ProductViewModel Do(int id)
      {
         var product = _context.Products.Find(id);

         if (product != null)
            return new ProductViewModel
            {
               Id = product.Id,
               Name = product.Name,
               Description = product.Description,
               Price = product.Price
            };
         else
            return null;
      }
   }
}
