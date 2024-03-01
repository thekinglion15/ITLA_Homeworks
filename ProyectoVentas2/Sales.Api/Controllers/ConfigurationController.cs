using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;
using Sales.Domain.Entities;
using Sales.Api.Models.Configuration;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationDb configurationDb;

        public ConfigurationController(IConfigurationDb configurationDb)
        {
            this.configurationDb = configurationDb;
        }

        [HttpGet("GetConfiguration")]
        public IActionResult GetConfigurations()
        {
            var configuration = this.configurationDb.GetAll();

            return Ok(configuration);
        }

        [HttpPost("Save")]
        public IActionResult Save(ConfigurationCreateModel createModel)
        {
            var result = this.configurationDb.Save(new Configuration()
            {
                ModifyDate = createModel.ModifyDate,
                IdCreationUser = createModel.IdCreationUser,
                Resource = createModel.Resource,
                Property = createModel.Property,
                Value = createModel.Value
            });

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(ConfigurationCreateModel updateConfiguration)
        {
            var result = this.configurationDb.Save(new Configuration()
            {
                ModifyDate = updateConfiguration.ModifyDate,
                IdCreationUser = updateConfiguration.IdCreationUser,
                Resource = updateConfiguration.Resource,
                Property = updateConfiguration.Property,
                Value = updateConfiguration.Value
            });

            return Ok(result);
        }
    }
}
