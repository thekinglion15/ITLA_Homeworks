using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contracts;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailController : ControllerBase
    {
        private readonly ISaleDetailService saleDetailService;

        public SaleDetailController(ISaleDetailService saleDetailService)
        {
            this.saleDetailService = saleDetailService;
        }

        [HttpGet("GetSaleDetails")]
        public IActionResult GetSaleDetails()
        {
            var saleDetails = this.saleDetailService.GetSaleDetails();

            return Ok(saleDetails);
        }

        [HttpPost("GetSaleDetailsByDates")]
        public IActionResult GetSaleDetailsByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.saleDetailService.GetSaleDetailsByDates(startDate, endDate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetSaleDetailsCount")]
        public IActionResult GetSaleDetailsCount()
        {
            var result = this.saleDetailService.GetSaleDetailsCount();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}