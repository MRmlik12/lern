using System;
using System.Threading.Tasks;
using Lern.Core.ProjectAggregate.Group;

namespace Lern.Infrastructure.Database.Interfaces
{
    public interface IGroupRepository
    {
        Task Create(Group group);
        Task<Group> GetGroupById(Guid ownerId, Guid groupId);
        Task Delete(Group group);
    }
}