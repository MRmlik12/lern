using System;
using System.Threading.Tasks;
using Lern.Core.ProjectAggregate.Group;

namespace Lern.Infrastructure.Database.Interfaces
{
    public interface IGroupRepository
    {
        Task Create(Group group);
        Task<Group> GetGroupByCode(string code);
        Task<Group> GetGroupById(Guid id);
        Task<Group> GetGroupById(Guid ownerId, Guid groupId);
        Task Update(Group group);
        Task Delete(Group group);
    }
}