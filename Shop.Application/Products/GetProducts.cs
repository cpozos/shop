using Shop.Application.ViewModels;
using Shop.Database;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.Products
{
   public class GetProducts
   {
      private ApplicationDbContext _context;

      public GetProducts(ApplicationDbContext dbContext)
      {
         _context = dbContext;
      }

      public IEnumerable<ProductViewModel> Do()
      {
         return _context.Products.ToList().Select(p => new ProductViewModel
         {
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
         });
      }
   }
}
