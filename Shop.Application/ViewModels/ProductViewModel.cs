using System.Collections.Generic;

namespace Shop.Application.ViewModels
{
   public class ProductViewModel
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public decimal Price { get; set; }
      public IEnumerable<StockViewModel> Stocks { get; set; }
   }
}
