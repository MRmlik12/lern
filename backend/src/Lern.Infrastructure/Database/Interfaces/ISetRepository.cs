using System;
using System.Threading.Tasks;
using Lern.Core.ProjectAggregate.Set;

namespace Lern.Infrastructure.Database.Interfaces
{
    public interface ISetRepository
    {
        Task Create(Set set);
        Task<Set> GetSetById(Guid id, Guid userId);
        Task Update(Set set);
        Task Delete(Set set);
    }
}