using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Groups;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Groups
{
    public class DeleteGroupsRequestHandler : IRequestHandler<DeleteGroupMediatorModel, Unit>
    {
        private readonly IGroupRepository _groupRepository;
        
        public DeleteGroupsRequestHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        
        public async Task<Unit> Handle(DeleteGroupMediatorModel request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetGroupById(request.UserId, request.GroupId);
            await _groupRepository.Delete(group);
            
            return Unit.Value;
        }
    }
}