using Ecommerce.Application.Core.Services;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Models.DTOs.AuthDto;
using Ecommerce.Application.Models.DTOs.UserDto;
using Ecommerce.Application.Models.Responses;
using Ecommerce.Domain.Core.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Specifications;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
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
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string saltBase64 = Convert.ToBase64String(salt); // Convert to string for storage

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: userDto.Password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
            ));

            User user = new User(
                userDto.Email,
                hashedPassword,
                saltBase64,
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

            var userSpec = AuthSpecifications.GetUserByEmailSpec(email);
            var user = await _unitOfWork.Repository<User>().FirstOrDefaultAsync(userSpec);
            if (user == null)
            {
                _loggerService.LogInfo("User not found");

                throw new EntityNotFoundException();
            }

            byte[] salt = Convert.FromBase64String(user.Salt);
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
            ));

            var validateUserSpec = AuthSpecifications.GetUserByEmailAndPasswordSpec(email, hashedPassword);
            var validUser = await _unitOfWork.Repository<User>().FirstOrDefaultAsync(validateUserSpec);
            if (validUser == null)
            {
                _loggerService.LogInfo("User not found");

                throw new EntityNotFoundException();
            }

            if (hashedPassword != validUser.Password) return null;

            return new LoginResponse()
            {
                               FirstName = user.FirstName,
                LastName = user.LastName,
                Phone=user.Phone,
                Token = GenerateJwtToken(user)
            };
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(ClaimTypes.Role, user.UserType.ToString())
        };


            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(2),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
