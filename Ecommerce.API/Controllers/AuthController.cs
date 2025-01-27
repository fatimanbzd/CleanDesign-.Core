
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Models.DTOs.AuthDto;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> logIn(LoginDto loginModel)
        {
            var user = _authService.LogIn(loginModel.userName, loginModel.password);
            if (user == null)
            {

            }
            return await Task.FromResult<IActionResult>(Ok());
        }
    }
}
