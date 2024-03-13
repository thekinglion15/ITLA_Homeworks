using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contracts;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            var categories = this.categoryService.GetCategories();

            return Ok(categories);
        }

        [HttpPost("GetCategoriesByDates")]
        public IActionResult GetCategoriesByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.categoryService.GetCategoriesByDates(startDate, endDate);
            
            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetCategoriesCount")]
        public IActionResult GetCategoriesCount()
        {
            var result = this.categoryService.GetCategoriesCount();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
