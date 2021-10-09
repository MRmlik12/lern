using System.Threading.Tasks;

namespace Lern.Infrastructure.Database.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}