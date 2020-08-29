using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Application.Products
{
   public class CreateProduct
   {
      private ApplicationDbContext _context;

      public CreateProduct(ApplicationDbContext dbContext)
      {
         _context = dbContext;
      }
      public void Do(string name, string description)
      {
         _context.Products.Add(new Product
         {
            Name = name,
            Description = description
         });
      }
   }
}
