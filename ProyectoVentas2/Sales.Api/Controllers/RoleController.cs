using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;
using Sales.Domain.Entities;
using Sales.Api.Models.Role;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleDb roleDb;

        public RoleController(IRoleDb roleDb)
        {
            this.roleDb = roleDb;
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            var roles = this.roleDb.GetAll();

            return Ok(roles);
        }

        [HttpPost("Save")]
        public IActionResult Save(RoleCreateModel createModel)
        {
            var result = this.roleDb.Save(new Role()
            {
                ModifyDate = createModel.ModifyDate,
                IdCreationUser = createModel.IdCreationUser
            });

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(RoleCreateModel updateRole)
        {
            var result = this.roleDb.Save(new Role()
            {
                ModifyDate = updateRole.ModifyDate,
                IdCreationUser = updateRole.IdCreationUser
            });

            return Ok(result);
        }
    }
}
