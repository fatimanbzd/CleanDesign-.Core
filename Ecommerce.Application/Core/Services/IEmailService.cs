using Ecommerce.Application.Core.Models;

namespace Ecommerce.Application.Core.Services
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
