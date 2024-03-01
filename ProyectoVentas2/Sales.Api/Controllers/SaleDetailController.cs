using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;
using Sales.Domain.Entities;
using Sales.Api.Models.SaleDetail;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailController : ControllerBase
    {
        private readonly ISaleDetailDb saleDetailDb;

        public SaleDetailController(ISaleDetailDb saleDetailDb)
        {
            this.saleDetailDb = saleDetailDb;
        }

        [HttpGet("GetSaleDetails")]
        public IActionResult GetSaleDetails()
        {
            var saleDetails = this.saleDetailDb.GetAll();

            return Ok(saleDetails);
        }

        [HttpPost("Save")]
        public IActionResult Save(SaleDetailCreateModel createModel)
        {
            var result = this.saleDetailDb.Save(new SaleDetail()
            {
                ModifyDate = createModel.ModifyDate,
                IdCreationUser = createModel.IdCreationUser,
                IdSale = createModel.IdSale,
                IdProduct = createModel.IdProduct,
                BrandProduct = createModel.BrandProduct,
                ProductCategory = createModel.ProductCategory,
                Quantity = createModel.Quantity
            });

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(SaleDetailCreateModel updateSaleDetail)
        {
            var result = this.saleDetailDb.Save(new SaleDetail()
            {
                ModifyDate = updateSaleDetail.ModifyDate,
                IdCreationUser = updateSaleDetail.IdCreationUser,
                IdSale = updateSaleDetail.IdSale,
                IdProduct = updateSaleDetail.IdProduct,
                BrandProduct = updateSaleDetail.BrandProduct,
                ProductCategory = updateSaleDetail.ProductCategory,
                Quantity = updateSaleDetail.Quantity
            });

            return Ok(result);
        }
    }
}
