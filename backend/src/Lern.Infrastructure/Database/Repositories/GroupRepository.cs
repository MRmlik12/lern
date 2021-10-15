using System.Threading.Tasks;
using Lern.Core.ProjectAggregate.Group;
using Lern.Infrastructure.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lern.Infrastructure.Database.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private DbSet<Group> Groups { get; set; }

        public GroupRepository(AppDbContext context)
        {
            Groups = context.Groups;
        }

        public async Task Create(Group group)
            => await Groups.AddAsync(group);
    }
}