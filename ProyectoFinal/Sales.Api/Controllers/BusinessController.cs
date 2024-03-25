using Microsoft.AspNetCore.Mvc;
using Sales.Api.Extentions;
using Sales.Api.Models.Business;
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
        public async Task<IActionResult> GetBusinesses()
        {
            var businesses = await this.businessService.GetBusinesses();

            return Ok(businesses);
        }

        [HttpPost("GetBusinessByName")]
        public async Task<IActionResult> GetBusinesses([FromBody] SearchBusinessModel searchBusiness)
        {
            var result = await this.businessService.GetBusinessByName(searchBusiness.Name);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] BusinessCreateModel createModel)
        {
            var business = createModel.ConvertFromBusinessCreateToBusinessDto();

            var result = await this.businessService.AddBusiness(business);
            
            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateBusinessModel updateBusiness)
        {
            return Ok();
        }
    }
}
