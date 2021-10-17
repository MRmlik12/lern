using System;
using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Groups.Users;
using Lern.Core.ProjectAggregate.Group;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Groups.Users
{
    public class UserLeaveRequestHandler : IRequestHandler<UserLeaveMediatorModel>
    {
        private readonly IGroupRepository _groupRepository;

        public UserLeaveRequestHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Unit> Handle(UserLeaveMediatorModel request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetGroupById(request.GroupId);
            group.MembersId.Remove(request.UserId);

            if (IsUserAdmin(group, request.UserId))
            {
                await _groupRepository.Delete(group);
                return Unit.Value;
            }

            await _groupRepository.Update(group);

            return Unit.Value;
        }

        private static bool IsUserAdmin(Group group, Guid userId)
        {
            return group.User.Id == userId;
        }
    }
}