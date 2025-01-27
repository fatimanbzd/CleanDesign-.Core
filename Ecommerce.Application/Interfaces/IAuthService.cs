using Ecommerce.Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LogIn(string emil, string password);
    }
}
