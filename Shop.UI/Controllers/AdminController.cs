using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductsAdmin;
using Shop.Application.ViewModels;
using Shop.Database;
using System.Threading.Tasks;

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
      public async Task<IActionResult> CreateProduct([FromBody] ProductViewModel vm)
      {
         var result = await new CreateProduct(_context).Do(vm);
         return Ok(result);
      }
      
      [HttpDelete("products/{id}")]
      public async Task<IActionResult> DeleteProduct(int id) => Ok(await new DeleteProduct(_context).Do(id));

      [HttpPut("products")]
      public async Task<IActionResult> UpdateProduct([FromBody] ProductViewModel vm) => Ok(await new UpdateProduct(_context).Do(vm));
   }
}
