using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ecommerce.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand(string FirstName, string LastName, string Email, string Phone, string Address) : ICommand(Guid);

}
