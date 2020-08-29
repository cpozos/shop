using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products;
using Shop.Application.ProductsAdmin;
using Shop.Application.ViewModels;
using Shop.Database;

namespace Shop.UI.Controllers
{
   [Route("[controller]")]
   public class AdminController : Controller
   {
      private ApplicationDbContext _context;

      public AdminController(ApplicationDbContext context)
      {
         _context = context;
      }

      [HttpGet("products")]
      public IActionResult GetProducts() => Ok(new GetProducts(_context).Do());

      [HttpGet("products/{id}")]
      public IActionResult GetProduct(int id) => Ok(new GetProduct(_context).Do(id));
      
      [HttpPost("products")]
      public IActionResult CreateProduct(ProductViewModel vm) => Ok(new CreateProduct(_context).Do(vm));
      
      [HttpDelete("products/{id}")]
      public IActionResult DeleteProduct(int id) => Ok(new GetProducts(_context).Do());

      [HttpPut("products")]
      public IActionResult UpdateProduct(ProductViewModel vm) => Ok(new UpdateProduct(_context).Do(vm));
   }
}
