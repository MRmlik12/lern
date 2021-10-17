using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lern.Core.Models.Users.Sets;
using Lern.Core.ProjectAggregate.Set;
using Lern.Core.ProjectAggregate.Set.Dtos;
using Lern.Infrastructure.Database.Filters;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Users.Sets
{
    public class
        UserSetCollectionRequestHandler : IRequestHandler<UserSetCollectionMediatorModel, List<SetCardItemsDto>>
    {
        private readonly ISetRepository _setRepository;
        private readonly IMapper _mapper;

        public UserSetCollectionRequestHandler(ISetRepository setRepository, IMapper mapper)
        {
            _setRepository = setRepository;
            _mapper = mapper;
        }

        public async Task<List<SetCardItemsDto>> Handle(UserSetCollectionMediatorModel request,
            CancellationToken cancellationToken)
        {
            var sets = await _setRepository.GetSetListByUserId(request.UserId, new PaginationFilter(request.Page));

            var setCardItems = sets.Select(x => new SetCardItemsDto
            {
                Id = x.Id,
                Title = x.Title,
                Language = x.Language,
                Tags = x.Tags,
                UserId = x.User.Id,
                Username = x.User.Username
            }).ToList();

            return setCardItems;
        }
    }
}