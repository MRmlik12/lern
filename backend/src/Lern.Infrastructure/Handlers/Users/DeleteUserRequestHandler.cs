using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Users;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Users
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserModel>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserModel request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);
            await _userRepository.Delete(user);

            return Unit.Value;
        }
    }
}