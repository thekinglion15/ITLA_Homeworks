using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;
using Sales.Domain.Entities;
using Sales.Api.Models.TypeDocSale;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeDocSaleController : ControllerBase
    {
        private readonly ITypeDocSaleDb typeDocSaleDb;

        public TypeDocSaleController(ITypeDocSaleDb typeDocSaleDb)
        {
            this.typeDocSaleDb = typeDocSaleDb;
        }

        [HttpGet("GetTypeDocSales")]
        public IActionResult GetTypeDocSales()
        {
            var typeDocSales = this.typeDocSaleDb.GetAll();

            return Ok(typeDocSales);
        }

        [HttpPost("Save")]
        public IActionResult Save(TypeDocSaleCreateModel createModel)
        {
            var result = this.typeDocSaleDb.Save(new TypeDocSale()
            {
                ModifyDate = createModel.ModifyDate,
                IdCreationUser = createModel.IdCreationUser
            });

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(TypeDocSaleCreateModel updateTypeDocSale)
        {
            var result = this.typeDocSaleDb.Save(new TypeDocSale()
            {
                ModifyDate = updateTypeDocSale.ModifyDate,
                IdCreationUser = updateTypeDocSale.IdCreationUser
            });

            return Ok(result);
        }
    }
}
