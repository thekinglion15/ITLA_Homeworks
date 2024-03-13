using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contracts;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            var roles = this.roleService.GetRoles();

            return Ok(roles);
        }

        [HttpPost("GetRolesByDates")]
        public IActionResult GetRolesByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.roleService.GetRolesByDates(startDate, endDate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetRolesCount")]
        public IActionResult GetRolesCount()
        {
            var result = this.roleService.GetRolesCount();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
