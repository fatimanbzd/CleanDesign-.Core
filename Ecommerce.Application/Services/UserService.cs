using Ecommerce.API.IServices;
using Ecommerce.Application.Models.DTOs.UserDto;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Core.Repositories;
using Ecommerce.Application.Core.Services;

namespace Ecommerce.Application.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;
        public UserService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }


        public async Task<IEnumerable<User>> GetAll()
            => await _unitOfWork.Repository<User>().GetAllAsync();
    }
}
