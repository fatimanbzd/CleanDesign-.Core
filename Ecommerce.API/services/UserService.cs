using Ecommerce.API.DTOs.UserDto;
using Ecommerce.API.IServices;
using Ecommerce.Domain.Aggrigates;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.API.services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddUser(UserDto userDto)
        {
            User user = new User(
                userDto.Email,
                userDto.Password,
                userDto.FirstName,
                userDto.LastName,
                userDto.Phone,
                EnumUserType.Customer

            );

            await _unitOfWork.GenericRepository<User>().AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
    
        }

        public async Task<IEnumerable<User>> GetAll()
            => await _unitOfWork.GenericRepository<User>().GetAllAsync();
    }
}
