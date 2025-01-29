using Ecommerce.API.IServices;
using Ecommerce.Application.Models.DTOs.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<bool>> Add(UserDto user)
        {
            if (ModelState.IsValid)
            {
                await _userService.Register(user);

                return Ok(true);
            }
            return BadRequest(false);
        }

    }
}
