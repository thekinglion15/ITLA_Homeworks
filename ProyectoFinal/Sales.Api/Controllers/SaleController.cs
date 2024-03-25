using Microsoft.AspNetCore.Mvc;
using Sales.Api.Extentions;
using Sales.Api.Models.Sale;
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
        public async Task<IActionResult> GetSales()
        {
            var sales = await this.saleService.GetSales();

            return Ok(sales);
        }

        [HttpPost("GetSaleBySaleNumber")]
        public async Task<IActionResult> GetSales([FromBody] SearchSaleModel searchSale)
        {
            var result = await this.saleService.GetSaleBySaleNumber(searchSale.SaleNumber);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] SaleCreateModel createModel)
        {
            var sale = createModel.ConvertFromSaleCreateToSaleDto();

            var result = await this.saleService.AddSale(sale);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateSaleModel updateSale)
        {
            return Ok();
        }
    }
}