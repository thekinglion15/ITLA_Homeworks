using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contracts;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        [HttpGet("GetConfigurations")]
        public IActionResult GetConfigurations()
        {
            var configurations = this.configurationService.GetConfigurations();

            return Ok(configurations);
        }

        [HttpPost("GetConfigurationsByDates")]
        public IActionResult GetConfigurationsByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.configurationService.GetConfigurationsByDates(startDate, endDate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetConfigurationsCount")]
        public IActionResult GetConfigurationsCount()
        {
            var result = this.configurationService.GetConfigurationsCount();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
