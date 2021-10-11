using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Users.Settings;
using Lern.Core.ProjectAggregate.User;
using Lern.Core.ProjectAggregate.User.Exceptions;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Users.Settings
{
    public class ChangeUsernameRequestHandler : IRequestHandler<ChangeUsernameMediatorModel>
    {
        private readonly IUserRepository _userRepository;
        
        public ChangeUsernameRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<Unit> Handle(ChangeUsernameMediatorModel request, CancellationToken cancellationToken)
        {
            if (IsUserCountGreaterOrEqualsOne(await _userRepository.CountUsersByUsername(request.NewUsername)))
                throw new UsernameIsExistsException();
            
            var user = await _userRepository.GetUserById(request.Id);
            user.Username = request.NewUsername;
            await _userRepository.Update(user);
            
            return Unit.Value;
        }

        private bool IsUserCountGreaterOrEqualsOne(int userCount)
            => userCount >= 1;
    }
}