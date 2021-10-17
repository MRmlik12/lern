using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Groups;
using Lern.Core.ProjectAggregate.Group;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Groups
{
    public class CreateGroupRequestHandler : IRequestHandler<CreateGroupMediatorModel, string>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;

        public CreateGroupRequestHandler(IGroupRepository groupRepository, IUserRepository userRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(CreateGroupMediatorModel request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);
            var group = new Group
            {
                Name = request.Name,
                User = user,
                MembersId = new List<Guid> { request.UserId }
            }.GenerateId().CreateTimestamp().GenerateCode();

            await _groupRepository.Create(group);

            return group.Code;
        }
    }
}