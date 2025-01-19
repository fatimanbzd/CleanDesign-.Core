using Ecommerce.API.DTOs.UserDto;
using Ecommerce.Domain.Aggrigates;

namespace Ecommerce.API.IServices
{
    public interface IUserService
    {

        Task AddUser(UserDto userDto);
        Task<IEnumerable<User>> GetAll();
    }
}
