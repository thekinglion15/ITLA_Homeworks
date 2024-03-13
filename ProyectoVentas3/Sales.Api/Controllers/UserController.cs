using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contracts;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = this.userService.GetUsers();

            return Ok(users);
        }

        [HttpPost("GetUsersByDates")]
        public IActionResult GetUsersByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.userService.GetUsersByDates(startDate, endDate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetUsersCount")]
        public IActionResult GetBusinessesCount()
        {
            var result = this.userService.GetUsersCount();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}   