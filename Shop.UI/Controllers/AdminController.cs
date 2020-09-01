using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductsAdmin;
using Shop.Application.StockAdmin;
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






      [HttpGet("stocks")]
      public IActionResult GetStocks() => Ok(new GetStock(_context).Do());

      [HttpPost("stocks")]
      public async Task<IActionResult> CreateStock([FromBody] StockViewModel vm)
      {
         var result = await new CreateStock(_context).Do(vm);
         return Ok(result);
      }

      [HttpDelete("stocks/{id}")]
      public async Task<IActionResult> DeleteStock(int id) => Ok(await new DeleteStock(_context).Do(id));

      [HttpPut("stocks")]
      public async Task<IActionResult> UpdateStock([FromBody] UpdateStock.Request request)
      {
         return Ok(await new UpdateStock(_context).Do(request));
      }
   }
}
