using Ecommerce.Application.Models.DTOs.UserDto;
using Ecommerce.Domain.Entities;

namespace Ecommerce.API.IServices
{
    public interface IUserService
    {

        Task Register(UserDto userDto);
        Task<IEnumerable<User>> GetAll();
    }
}
