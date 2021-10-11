using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Users.Settings;
using Lern.Core.ProjectAggregate.User.Exceptions;
using Lern.Core.Utils;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Users.Settings
{
    public class ChangePasswordRequestHandler : IRequestHandler<ChangePasswordMediatorModel>
    {
        private readonly IUserRepository _userRepository;
        
        public ChangePasswordRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<Unit> Handle(ChangePasswordMediatorModel request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);
            if (!PasswordUtility.VerifyPassword(request.OldPassword, user.Password))
                throw new InvalidUserPasswordException();

            await _userRepository.Update(user);
            
            return Unit.Value;
        }
    }
}