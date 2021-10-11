using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Sets;
using Lern.Core.ProjectAggregate.Set;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Sets
{
    public class CreateSetRequestHandler : IRequestHandler<CreateSetMediatorModel>
    {
        private readonly ISetRepository _setRepository;
        private readonly IUserRepository _userRepository;

        public CreateSetRequestHandler(ISetRepository setRepository, IUserRepository userRepository)
        {
            _setRepository = setRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreateSetMediatorModel request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);
            var set = new Set
            {
                Title = request.Title,
                Language = request.Language,
                Author = user,
                Tags = request.Tags,
                Items = request.Items
            }.GenerateId().CreateTimestamp();

            await _setRepository.Create(set);
            
            return Unit.Value;
        }
    }
}