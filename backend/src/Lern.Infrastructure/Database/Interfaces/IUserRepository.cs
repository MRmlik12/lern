using System;
using System.Threading.Tasks;
using Lern.Core.ProjectAggregate.User;
using Vulder.SharedKernel.Interface;

namespace Lern.Infrastructure.Database.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);
        Task<int> CountUsersByUsername(string username);
        Task Update(User user);
        Task Delete(User user);
    }
}