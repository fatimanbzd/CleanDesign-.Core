using Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface IUserRepository: IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
