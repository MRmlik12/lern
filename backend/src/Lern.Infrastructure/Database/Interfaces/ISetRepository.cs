using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lern.Core.ProjectAggregate.Set;
using Lern.Infrastructure.Database.Filters;

namespace Lern.Infrastructure.Database.Interfaces
{
    public interface ISetRepository
    {
        Task Create(Set set);
        Task<Set> GetSetById(Guid id);
        Task<List<Set>> GetSetListByUserId(Guid userId, PaginationFilter paginationFilter);
        Task<Set> GetSetByIdAndUserId(Guid id, Guid userId);
        Task<int> GetUserSetCount(Guid userId);
        Task<List<Set>> GetSetsAddedByLatest(DateTime date);
        Task Update(Set set);
        Task Delete(Set set);
    }
}