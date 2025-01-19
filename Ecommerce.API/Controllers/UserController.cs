using Ecommerce.API.DTOs.UserDto;
using Ecommerce.API.IServices;
using Ecommerce.API.services;
using Ecommerce.Domain;
using Ecommerce.Domain.Aggrigates;
using Microsoft.AspNetCore.Identity;
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
                await _userService.AddUser(user);

                return Ok(true);
            }
            return BadRequest(false);
        }
  
    }
}
