using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;
using Sales.Domain.Entities;
using Sales.Api.Models.User;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDb userDb;

        public UserController(IUserDb userDb)
        {
            this.userDb = userDb;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = this.userDb.GetAll();

            return Ok(users);
        }

        [HttpPost("Save")]
        public IActionResult Save(UserCreateModel createModel)
        {
            var result = this.userDb.Save(new User()
            {
                ModifyDate = createModel.ModifyDate,
                IdCreationUser = createModel.IdCreationUser,
                Key = createModel.Key
            });

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(UserCreateModel updateUser)
        {
            var result = this.userDb.Save(new User()
            {
                ModifyDate = updateUser.ModifyDate,
                IdCreationUser = updateUser.IdCreationUser,
                Key = updateUser.Key
            });

            return Ok(result);
        }
    }
}
