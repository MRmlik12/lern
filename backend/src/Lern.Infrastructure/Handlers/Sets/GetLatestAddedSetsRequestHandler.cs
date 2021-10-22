using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Sets;
using Lern.Core.ProjectAggregate.Set.Dtos;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Sets
{
    public class GetLatestAddedSetsRequestHandler : IRequestHandler<GetLatestAddedSetsMediatorModel, List<SetCardItemsDto>>
    {
        private readonly ISetRepository _setRepository;
        
        public GetLatestAddedSetsRequestHandler(ISetRepository setRepository)
        {
            _setRepository = setRepository;
        }
        
        public async Task<List<SetCardItemsDto>> Handle(GetLatestAddedSetsMediatorModel request, CancellationToken cancellationToken)
        {
            var sets = await _setRepository.GetSetsAddedByLatest(request.Now);

            return sets.Select(x => new SetCardItemsDto
            {
                Id = x.Id,
                Title = x.Title,
                Language = x.Language,
                Tags = x.Tags,
                UserId = x.User.Id,
                Username = x.User.Username
            }).ToList();
        }
    }
}