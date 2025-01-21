
using Ecommerce.Application.Models.DTOs.UserDto;
using Ecommerce.Domain.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("login")]
        public Task<IActionResult> logIn(LoginDto loginModel)
        {
            return Task.FromResult<IActionResult>(Ok());
        }
    }
}
