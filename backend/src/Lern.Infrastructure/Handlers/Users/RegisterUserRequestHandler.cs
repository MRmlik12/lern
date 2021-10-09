using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Users;
using Lern.Core.ProjectAggregate.User;
using Lern.Core.ProjectAggregate.User.Dtos;
using Lern.Core.Utils;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Users
{
    public class RegisterUserRequestHandler : IRequestHandler<RegisterUserModel, UserDto>
    {
        private readonly IUserRepository _userRepository;
        
        public RegisterUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<UserDto> Handle(RegisterUserModel request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = PasswordUtility.GetEncryptedPassword(request.Password),
                Email = request.Email,
                Role = Role.User
            }.GenerateId().CreateTimestamp();

            await _userRepository.Create(user);
            
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}