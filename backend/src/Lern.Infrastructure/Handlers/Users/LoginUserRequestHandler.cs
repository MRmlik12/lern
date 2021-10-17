using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Users;
using Lern.Core.ProjectAggregate.User.Dtos;
using Lern.Core.ProjectAggregate.User.Exceptions;
using Lern.Core.Utils;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Users
{
    public class LoginUserRequestHandler : IRequestHandler<LoginUserModel, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public LoginUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(LoginUserModel request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);

            if (PasswordUtility.VerifyPassword(request.Password, user.Password))
                return new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role
                };

            throw new InvalidUserPasswordException();
        }
    }
}