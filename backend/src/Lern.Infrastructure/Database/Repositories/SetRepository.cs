using System;
using System.Linq;
using System.Threading.Tasks;
using Lern.Core.ProjectAggregate.Set;
using Lern.Infrastructure.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lern.Infrastructure.Database.Repositories
{
    public class SetRepository : ISetRepository
    {
        private DbSet<Set> Sets { get; }

        public SetRepository(AppDbContext context)
        {
            Sets = context.Sets;
        }

        public async Task Create(Set set)
            => await Sets.AddAsync(set);

        public async Task<Set> GetSetById(Guid id)
            => await Sets.Where(e => e.Id == id).Include(e => e.User).FirstAsync();

        public async Task<Set> GetSetByIdAndUserId(Guid id, Guid userId)
            => await Sets.OrderBy(e => e.Id).Where(e => e.Id == id).Where(e => e.User.Id == userId).FirstAsync();

        public Task Update(Set set)
        {
            Sets.Update(set);
            
            return Task.CompletedTask;
        }

        public Task Delete(Set set)
        {
            Sets.Remove(set);
            
            return Task.CompletedTask;
        }
    }
}