
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Models.DTOs.AuthDto;
using Ecommerce.Application.Models.DTOs.UserDto;
using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

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

        [HttpPost]
        [Route("register")]
        public async Task Register(UserDto userDto)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            User user = new User(
                userDto.Email,
                Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: userDto.Password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)),
                userDto.FirstName,
                userDto.LastName,
                userDto.Phone,
                EnumUserType.Customer

            );

            await _authService.Register(userDto);

        }
    }
}
