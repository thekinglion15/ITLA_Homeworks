using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contracts;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrelativeNumberController : ControllerBase
    {
        private readonly ICorrelativeNumberService correlativeNumberService;

        public CorrelativeNumberController(ICorrelativeNumberService correlativeNumberService)
        {
            this.correlativeNumberService = correlativeNumberService;
        }

        [HttpGet("GetCorrelativeNumbers")]
        public IActionResult GetCorrelativeNumbers()
        {
            var correlativeNumbers = this.correlativeNumberService.GetCorrelativeNumbers();

            return Ok(correlativeNumbers);
        }

        [HttpPost("GetCorrelativeNumberByDates")]
        public IActionResult GetCorrelativeNumbersByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.correlativeNumberService.GetCorrelativeNumbersByDates(startDate, endDate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetCorrelativeNumbersCount")]
        public IActionResult GetCorrelativeNumbersCount()
        {
            var result = this.correlativeNumberService.GetCorrelativeNumbersCount();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
