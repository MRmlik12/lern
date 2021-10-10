using System;
using System.Linq;
using System.Threading.Tasks;
using Lern.Core.ProjectAggregate.User;
using Lern.Infrastructure.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lern.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> Users;

        public UserRepository(AppDbContext context)
        {
            Users = context.Users;
        }

        public async Task<User> Create(User user)
        {
            await Users.AddAsync(user);
            return user;
        }

        public async Task<User> GetUserById(Guid id)
            => await Users.OrderBy(e => e.Id).Where(e => e.Id == id).FirstAsync();

        public Task Delete(User user)
        {
            Users.Remove(user);
            return Task.CompletedTask;
        }
    }
}