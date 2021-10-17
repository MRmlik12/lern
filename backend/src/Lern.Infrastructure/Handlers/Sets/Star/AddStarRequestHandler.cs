using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Sets;
using Lern.Core.Models.Sets.Stars;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Sets.Star
{
    public class AddStarRequestHandler : IRequestHandler<AddStarMediatorModel, Unit>
    {
        private readonly ISetRepository _setRepository;
        private readonly IUserRepository _userRepository;

        public AddStarRequestHandler(ISetRepository setRepository, IUserRepository userRepository)
        {
            _setRepository = setRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AddStarMediatorModel request, CancellationToken cancellationToken)
        {
            var set = await _setRepository.GetSetById(request.SetId);
            var user = await _userRepository.GetUserById(request.UserId);

            set.Stars.Add(user);
            await _setRepository.Update(set);

            return Unit.Value;
        }
    }
}