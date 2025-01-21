using Ecommerce.Domain.Aggrigates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Core.Repositories
{
    public interface IUserRepository : IBaseRepository<User>, IDisposable
    {
        Task<User> GetByEmailAsync(string email);
    }
}
