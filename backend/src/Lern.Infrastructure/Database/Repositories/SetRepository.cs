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
    }
}