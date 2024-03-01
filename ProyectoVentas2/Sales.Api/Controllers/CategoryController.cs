using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;
using Sales.Domain.Entities;
using Sales.Api.Models.Category;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryDb categoryDb;

        public CategoryController(ICategoryDb categoryDb)
        {
            this.categoryDb = categoryDb;
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            var categories = this.categoryDb.GetAll();

            return Ok(categories);
        }

        [HttpPost("Save")]
        public IActionResult Save(SaleCreateModel createModel)
        {
            var result = this.categoryDb.Save(new Category()
            {
                ModifyDate = createModel.ModifyDate,
                IdCreationUser = createModel.IdCreationUser
            });

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(SaleCreateModel updateCategory)
        {
            var result = this.categoryDb.Save(new Category()
            {
                ModifyDate = updateCategory.ModifyDate,
                IdCreationUser = updateCategory.IdCreationUser
            });

            return Ok(result);
        }
    }
}
