using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var products = new[]
            {
                new { Id = 1, Name = "Product A", Price = 10.99 },
                new { Id = 2, Name = "Product B", Price = 19.99 },
                new { Id = 3, Name = "Product C", Price = 5.49 }
            };
            return Ok(products);
        }
    }
}
