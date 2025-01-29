using Ecommerce.Application.Core.Services;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Models.DTOs.UserDto;
using Ecommerce.Application.Models.Responses;
using Ecommerce.Domain.Core.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Specifications;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Application.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;
        private IConfiguration _config;
        public AuthService(IUnitOfWork unitOfWork, ILoggerService loggerService, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
            _config = config;
        }

        public async Task Register(UserDto userDto)
        {
            User user = new User(
                userDto.Email,
                userDto.Password,
                userDto.FirstName,
                userDto.LastName,
                userDto.Phone,
                EnumUserType.Customer

            );

            await _unitOfWork.Repository<User>().AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

        }


        public async Task<LoginResponse> LogIn(string email, string password)
        {

            var validateUserSpec = AuthSpecifications.GetUserByEmailAndPasswordSpec(email, password);
            var user = await _unitOfWork.Repository<User>().FirstOrDefaultAsync(validateUserSpec);

            if (user == null)
            {
                _loggerService.LogInfo("User not found");

                throw new EntityNotFoundException();
            }

            return new LoginResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = GenerateJwtToken(email)
            };
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
