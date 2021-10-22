using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Users.Groups;
using Lern.Core.ProjectAggregate.User.Dtos;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Users.Groups
{
    public class
        GetUserGroupCollectionRequestHandler : IRequestHandler<GetUserGroupCollectionMediatorModel, List<UserGroupDto>>
    {
        private readonly IGroupRepository _groupRepository;

        public GetUserGroupCollectionRequestHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<List<UserGroupDto>> Handle(GetUserGroupCollectionMediatorModel request,
            CancellationToken cancellationToken)
        {
            var groups = await _groupRepository.GetGroupsCollectionWhereUserIsIn(request.UserId);

            return groups.Select(x => new UserGroupDto
            {
                Id = x.Id,
                Name = x.Name,
                OwnerUsername = x.User.Username,
                UserCount = x.MembersId.Count
            }).ToList();
        }
    }
}