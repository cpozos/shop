using Microsoft.EntityFrameworkCore;
using Shop.Application.ViewModels;
using Shop.Database;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.StockAdmin
{
   public class GetStock
   {
      private ApplicationDbContext _context;

      public GetStock(ApplicationDbContext context)
      {
         _context = context;
      }

      public IEnumerable<ProductViewModel> Do()
      {
         var products = _context.Products
            .Include(p=>p.Stock)
            .Select(p => new ProductViewModel
            {
               Id = p.Id,
               Description = p.Description,
               Stock = p.Stock.Select(s=> new StockViewModel
               {
                  Id = s.Id,
                  Description = s.Description,
                  Quantity = s.Quantity
               })
            })
            .ToList();

         return products;
      }
   }
}
