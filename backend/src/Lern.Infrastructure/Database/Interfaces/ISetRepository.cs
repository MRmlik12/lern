using System.Threading.Tasks;
using Lern.Core.ProjectAggregate.Set;

namespace Lern.Infrastructure.Database.Interfaces
{
    public interface ISetRepository
    {
        Task Create(Set set);
    }
}