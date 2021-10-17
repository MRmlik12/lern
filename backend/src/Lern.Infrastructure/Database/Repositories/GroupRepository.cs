using System;
using System.Linq;
using System.Threading.Tasks;
using Lern.Core.ProjectAggregate.Group;
using Lern.Infrastructure.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lern.Infrastructure.Database.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private DbSet<Group> Groups { get; }

        public GroupRepository(AppDbContext context)
        {
            Groups = context.Groups;
        }

        public async Task Create(Group group)
        {
            await Groups.AddAsync(group);
        }

        public async Task<Group> GetGroupById(Guid ownerId, Guid groupId)
            => await Groups.Where(e => e.Id == groupId && e.User.Id == ownerId)
                .Include(e => e.User)
                .FirstAsync();

        public Task Delete(Group group)
        {
            Groups.Remove(group);

            return Task.CompletedTask;
        }
    }
}