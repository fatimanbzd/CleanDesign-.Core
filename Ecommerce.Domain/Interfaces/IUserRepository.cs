using Ecommerce.Domain.Aggrigates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface IUserRepository: IGenericRepository<User>, IDisposable
    {
        Task<User> GetByEmailAsync(string email);
    }
}
