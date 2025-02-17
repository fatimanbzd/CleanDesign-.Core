
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Models.DTOs.AuthDto;
using Ecommerce.Application.Models.DTOs.UserDto;
using Ecommerce.Application.Models.Responses;
using Ecommerce.Domain.Entities;
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
            var user = _authService.LogIn(loginModel.email, loginModel.password);
            if (user == null)
            {

                return BadRequest(ApiResponse.Error("User not found!"));
            }
            return await Task.FromResult<IActionResult>(Ok(ApiResponse.Success( new LoginResponse
                {
                    FirstName = user.Result.FirstName,
                    LastName = user.Result.LastName,
                    Phone = user.Result.Phone,
                    Token = user.Result.Token
                }
           )));
        }

        [HttpPost]
        [Route("register")]
        public async Task Register(UserDto userDto)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string saltBase64 = Convert.ToBase64String(salt);

            User user = new User(
                userDto.Email,
                password: userDto.Password,
                saltBase64,
                userDto.FirstName,
                userDto.LastName,
                userDto.Phone,
                EnumUserType.Customer

            );

            await _authService.Register(userDto);

        }
    }
}
