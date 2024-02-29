using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;
using Sales.Domain.Entities;
using Sales.Api.Models.Business;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessDb businessDb;

        public BusinessController(IBusinessDb businessDb)
        {
            this.businessDb = businessDb;
        }

        [HttpGet("GetBusinesses")]
        public IActionResult GetBusinesses()
        {
            var businesses = this.businessDb.GetAll();

            return Ok(businesses);
        }

        [HttpPost("Save")]
        public IActionResult Save(BusinessCreateModel createModel)
        {
            var result = this.businessDb.Save(new Business()
            {
                DocNumber = createModel.DocNumber,
                Address = createModel.Address,
                TaxPercent = createModel.TaxPercent,
                CurrencySymbol = createModel.CurrencySymbol,
                ModifyDate = createModel.ModifyDate,
                IdCreationUser = createModel.IdCreationUser
            });

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(BusinessCreateModel updateBusiness)
        {
            var result = this.businessDb.Save(new Business()
            {
                DocNumber = updateBusiness.DocNumber,
                Address = updateBusiness.Address,
                TaxPercent = updateBusiness.TaxPercent,
                CurrencySymbol = updateBusiness.CurrencySymbol,
                ModifyDate = updateBusiness.ModifyDate,
                IdCreationUser = updateBusiness.IdCreationUser
            });

            return Ok(result);
        }
    }
}
