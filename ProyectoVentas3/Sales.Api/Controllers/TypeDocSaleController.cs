using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contracts;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeDocSaleController : ControllerBase
    {
        private readonly ITypeDocSaleService typeDocSaleService;

        public TypeDocSaleController(ITypeDocSaleService typeDocSaleService)
        {
            this.typeDocSaleService = typeDocSaleService;
        }

        [HttpGet("GetTypeDocSales")]
        public IActionResult GetTypeDocSales()
        {
            var typeDocSales = this.typeDocSaleService.GetTypeDocSales();

            return Ok(typeDocSales);
        }

        [HttpPost("GetTypeDocSalesByDates")]
        public IActionResult GetTypeDocSalesByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.typeDocSaleService.GetTypeDocSalesByDates(startDate, endDate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetTypeDocSalesCount")]
        public IActionResult GetTypeDocSalesCount()
        {
            var result = this.typeDocSaleService.GetTypeDocSalesCount();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
