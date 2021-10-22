using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lern.Core.ProjectAggregate.Set;
using Lern.Infrastructure.Database.Filters;
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
        {
            await Sets.AddAsync(set);
        }

        public async Task<Set> GetSetById(Guid id)
        {
            return await Sets.Where(e => e.Id == id).Include(e => e.User).FirstAsync();
        }

        public async Task<List<Set>> GetSetListByUserId(Guid userId, PaginationFilter paginationFilter)
        {
            return await Sets.OrderBy(e => e.CreatedAt)
                .Where(e => e.User.Id == userId)
                .Include(e => e.User)
                .Take(paginationFilter.PageNumber * paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<Set> GetSetByIdAndUserId(Guid id, Guid userId)
        {
            return await Sets.OrderBy(e => e.Id).Where(e => e.Id == id).Where(e => e.User.Id == userId).FirstAsync();
        }

        public async Task<int> GetUserSetCount(Guid userId)
        {
            return await Sets.CountAsync(e => e.User.Id == userId);
        }
        
        public async Task<List<Set>> GetSetsAddedByLatest(DateTime date)
            => await Sets.Where(e => e.CreatedAt <= date)
                .OrderByDescending(e => e.CreatedAt)
                .Take(10)
                .Include(e => e.User)
                .ToListAsync();

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