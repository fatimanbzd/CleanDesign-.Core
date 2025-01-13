using Ecommerce.API.DTOs.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> logIn(LoginDto loginModel)
        {
            return null;
        }
    }
}
