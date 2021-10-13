using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Sets;
using Lern.Core.ProjectAggregate.Set.Dtos;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Sets
{
    public class GetSetRequestHandler : IRequestHandler<GetSetMediatorModel, SetDto>
    {
        private readonly ISetRepository _setRepository;
        
        public GetSetRequestHandler(ISetRepository setRepository)
        {
            _setRepository = setRepository;
        }
        
        public async Task<SetDto> Handle(GetSetMediatorModel request, CancellationToken cancellationToken)
        {
            var set = await _setRepository.GetSetById(request.SetId);

            return new SetDto
            {
                Title = set.Title,
                Language = set.Language,
                Tags = set.Tags,
                UserId = set.User.Id,
                Items = set.Items,
                CreatedAt = set.CreatedAt
            };
        }
    }
}