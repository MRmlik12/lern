using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Groups.Users;
using Lern.Core.ProjectAggregate.Group;
using Lern.Core.ProjectAggregate.Group.Exceptions;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Groups.Users
{
    public class JoinUserRequestHandler : IRequestHandler<UserJoinMediatorModel, Unit>
    {
        private readonly IGroupRepository _groupRepository;

        public JoinUserRequestHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Unit> Handle(UserJoinMediatorModel request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetGroupByCode(request.Code);
            if (!IsUserInMembers(group, request.UserId))
                throw new UserIsInMembersException();

            group.MembersId.Add(request.UserId);
            await _groupRepository.Update(group);

            return Unit.Value;
        }

        private static bool IsUserInMembers(Group group, Guid userId)
        {
            return string.IsNullOrEmpty(group.MembersId.First(x => x == userId).ToString());
        }
    }
}