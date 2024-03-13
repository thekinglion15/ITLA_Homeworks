using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contracts;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService businessService;

        public BusinessController(IBusinessService businessService)
        {
            this.businessService = businessService;
        }

        [HttpGet("GetBusinesses")]
        public IActionResult GetBusinesses()
        {
            var businesses = this.businessService.GetBusinesses();

            return Ok(businesses);
        }

        [HttpPost("GetBusinessesByDates")]
        public IActionResult GetBusinessesByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.businessService.GetBusinessesByDates(startDate, endDate);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetBusinessesCount")]
        public IActionResult GetBusinessesCount()
        {
            var result = this.businessService.GetBusinessesCount();
            
            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
