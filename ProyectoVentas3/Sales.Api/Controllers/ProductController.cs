using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contracts;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            var products = this.productService.GetProducts();

            return Ok(products);
        }

        [HttpPost("GetProductsByDates")]
        public IActionResult GetProductsByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.productService.GetProductsByDates(startDate, endDate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetProductsCount")]
        public IActionResult GetProductsCount()
        {
            var result = this.productService.GetProductsCount();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
