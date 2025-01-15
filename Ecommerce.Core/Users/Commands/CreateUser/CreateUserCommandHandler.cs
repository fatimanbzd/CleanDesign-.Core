using Ecommerce.Domain.Aggregates;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Users.Commands.CreateUser
{
    internal sealed class CreateUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken) {
        var user= new User(Guid.NewGuid());
            _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return user.Id;
                
                }
    }
}
