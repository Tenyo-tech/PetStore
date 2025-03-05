using Microsoft.AspNetCore.Mvc;
using PetStore.Business.Services;
using PetStore.Data.Dtos;

namespace PetStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var user = await userService.CreateUser(createUserDto);

            if (user == null)
            {
                return NotFound(new { message = "User failed to create!" });
            }

            return Ok(user);
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await this.userService.GetUserById(userId);

            if (user != null)
            {
                return NotFound(new { message = "User do not exist!" });
            }

            return Ok(user);

        }

        [HttpGet("CheckUser")]
        public async Task<IActionResult> CheckUser(int userId)
        {
            var exist = await userService.Exists(userId);

            if (!exist)
            {
                return NotFound(new { message = "User do not exist!" });
            }
            return Ok(exist);

        }
    }
}
