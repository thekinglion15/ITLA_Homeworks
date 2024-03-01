using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;
using Sales.Domain.Entities;
using Sales.Api.Models.CorrelativeNumber;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrelativeNumberController : ControllerBase
    {
        private readonly ICorrelativeNumberDb correlativeNumberDb;

        public CorrelativeNumberController(ICorrelativeNumberDb correlativeNumberDb)
        {
            this.correlativeNumberDb = correlativeNumberDb;
        }

        [HttpGet("GetCorrelativeNumber")]
        public IActionResult GetCorrelativeNumbers()
        {
            var correlativeNumber = this.correlativeNumberDb.GetAll();

            return Ok(correlativeNumber);
        }

        [HttpPost("Save")]
        public IActionResult Save(CorrelativeNumberCreateModel createModel)
        {
            var result = this.correlativeNumberDb.Save(new CorrelativeNumber()
            {
                ModifyDate = createModel.ModifyDate,
                IdCreationUser = createModel.IdCreationUser,
                LastNumber = createModel.LastNumber,
                DigitsQuantity = createModel.DigitsQuantity,
                Management = createModel.Management
            });

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(CorrelativeNumberCreateModel updateCorrelativeNumber)
        {
            var result = this.correlativeNumberDb.Save(new CorrelativeNumber()
            {
                ModifyDate = updateCorrelativeNumber.ModifyDate,
                IdCreationUser = updateCorrelativeNumber.IdCreationUser,
                LastNumber = updateCorrelativeNumber.LastNumber,
                DigitsQuantity = updateCorrelativeNumber.DigitsQuantity,
                Management = updateCorrelativeNumber.Management
            });

            return Ok(result);
        }
    }
}
