using System;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public async Task<Group> GetGroupByCode(string code)
        {
            return await Groups.Where(e => e.Code == code).FirstAsync();
        }

        public async Task<Group> GetGroupById(Guid id)
        {
            return await Groups.Where(e => e.Id == id)
                .Include(e => e.User)
                .FirstAsync();
        }

        public async Task<Group> GetGroupById(Guid ownerId, Guid groupId)
        {
            return await Groups.Where(e => e.Id == groupId && e.User.Id == ownerId)
                .Include(e => e.User)
                .FirstAsync();
        }

        public async Task<int> GetUserSetCount(Guid userId)
        {
            return await Groups.CountAsync(e => e.User.Id == userId);
        }

        public Task Update(Group group)
        {
            Groups.Update(group);

            return Task.CompletedTask;
        }

        public Task Delete(Group group)
        {
            Groups.Remove(group);

            return Task.CompletedTask;
        }
    }
}