using Microsoft.EntityFrameworkCore;
using Shop.Application.ViewModels;
using Shop.Database;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.Products
{
   public class GetProduct
   {
      private ApplicationDbContext _context;

      public GetProduct(ApplicationDbContext dbContext)
      {
         _context = dbContext;
      }

      public ProductViewModel Do(string name) =>
         _context.Products
            .Include(x=>x.Stock)
            .Where(x => x.Name == name)
            .Select(p => new ProductViewModel
            {
               Name = p.Name,
               Description = p.Description,
               Price = p.Price,
               Stock = p.Stock.Select(s=>new StockViewModel
               {
                  Id = s.Id,
                  Description = s.Description,
                  InStock = s.Quantity > 0
               })
            })
            .FirstOrDefault();
      
   }
}
