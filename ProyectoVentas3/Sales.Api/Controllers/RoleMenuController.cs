using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contracts;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleMenuController : ControllerBase
    {
        private readonly IRoleMenuService roleMenuService;

        public RoleMenuController(IRoleMenuService roleMenuService)
        {
            this.roleMenuService = roleMenuService;
        }

        [HttpGet("GetRoleMenus")]
        public IActionResult GetRoleMenus()
        {
            var roleMenus = this.roleMenuService.GetRoleMenus();

            return Ok(roleMenus);
        }

        [HttpPost("GetRoleMenusByDates")]
        public IActionResult GetRoleMenusByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.roleMenuService.GetRoleMenusByDates(startDate, endDate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetRoleMenusCount")]
        public IActionResult GetRoleMenusCount()
        {
            var result = this.roleMenuService.GetRoleMenusCount();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}