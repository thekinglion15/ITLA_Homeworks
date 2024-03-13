using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contracts;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [HttpGet("GetSales")]
        public IActionResult GetSales()
        {
            var sales = this.saleService.GetSales();

            return Ok(sales);
        }

        [HttpPost("GetSalesByDates")]
        public IActionResult GetSalesByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.saleService.GetSalesByDates(startDate, endDate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetSalesCount")]
        public IActionResult GetSalesCount()
        {
            var result = this.saleService.GetSalesCount();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}