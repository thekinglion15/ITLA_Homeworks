using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;
using Sales.Domain.Entities;
using Sales.Api.Models.Sale;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleDb saleDb;

        public SaleController(ISaleDb saleDb)
        {
            this.saleDb = saleDb;
        }

        [HttpGet("GetSales")]
        public IActionResult GetSales()
        {
            var sales = this.saleDb.GetAll();

            return Ok(sales);
        }

        [HttpPost("Save")]
        public IActionResult Save(SaleCreateModel createModel)
        {
            var result = this.saleDb.Save(new Sale()
            {
                ModifyDate = createModel.ModifyDate,
                IdCreationUser = createModel.IdCreationUser,
                SaleNumber = createModel.SaleNumber,
                IdTypeDocSale = createModel.IdTypeDocSale,
                IdUser = createModel.IdUser,
                ClientDoc = createModel.ClientDoc,
                NameClient = createModel.ClientDoc,
                Subtotal = createModel.Subtotal,
                TaxTotal = createModel.TaxTotal
            });

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(SaleCreateModel updateSale)
        {
            var result = this.saleDb.Save(new Sale()
            {
                ModifyDate = updateSale.ModifyDate,
                IdCreationUser = updateSale.IdCreationUser,
                SaleNumber = updateSale.SaleNumber,
                IdTypeDocSale = updateSale.IdTypeDocSale,
                IdUser = updateSale.IdUser,
                ClientDoc = updateSale.ClientDoc,
                NameClient = updateSale.ClientDoc,
                Subtotal = updateSale.Subtotal,
                TaxTotal = updateSale.TaxTotal
            });

            return Ok(result);
        }
    }
}
