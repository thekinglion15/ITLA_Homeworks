using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contracts;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        [HttpGet("GetMenus")]
        public IActionResult GetMenus()
        {
            var menus = this.menuService.GetMenus();

            return Ok(menus);
        }

        [HttpPost("GetMenusByDates")]
        public IActionResult GetMenusByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.menuService.GetMenusByDates(startDate, endDate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetMenusCount")]
        public IActionResult GetMenusCount()
        {
            var result = this.menuService.GetMenusCount();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
