using Microsoft.AspNetCore.Mvc;
using Sales.Api.Extentions;
using Sales.Api.Models.SaleDetail;
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
        public async Task<IActionResult> GetSaleDetails()
        {
            var saleDetails = await this.saleDetailService.GetSaleDetails();

            return Ok(saleDetails);
        }

        [HttpPost("GetSaleDetailBySale")]
        public async Task<IActionResult> GetSaleDetails([FromBody] SearchSaleDetailModel searchDetailSale)
        {
            var result = await this.saleDetailService.GetSaleDetailBySale(searchDetailSale.IdSale);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] SaleDetailCreateModel createModel)
        {
            var saleDetail = createModel.ConvertFromSaleDetailCreateToSaleDetailDto();

            var result = await this.saleDetailService.AddSaleDetail(saleDetail);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateSaleDetailModel updateSale)
        {
            return Ok();
        }
    }
}