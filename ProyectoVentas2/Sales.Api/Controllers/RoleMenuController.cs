using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;
using Sales.Domain.Entities;
using Sales.Api.Models.RoleMenu;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleMenuController : ControllerBase
    {
        private readonly IRoleMenuDb roleMenuDb;

        public RoleMenuController(IRoleMenuDb roleMenuDb)
        {
            this.roleMenuDb = roleMenuDb;
        }

        [HttpGet("GetRoleMenus")]
        public IActionResult GetRoleMenus()
        {
            var roleMenus = this.roleMenuDb.GetAll();

            return Ok(roleMenus);
        }

        [HttpPost("Save")]
        public IActionResult Save(RoleMenuCreateModel createModel)
        {
            var result = this.roleMenuDb.Save(new RoleMenu()
            {
                ModifyDate = createModel.ModifyDate,
                IdCreationUser = createModel.IdCreationUser,
                IdMenu = createModel.IdMenu
            });

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(RoleMenuCreateModel updateRoleMenu)
        {
            var result = this.roleMenuDb.Save(new RoleMenu()
            {
                ModifyDate = updateRoleMenu.ModifyDate,
                IdCreationUser = updateRoleMenu.IdCreationUser,
                IdMenu = updateRoleMenu.IdMenu
            });

            return Ok(result);
        }
    }
}
