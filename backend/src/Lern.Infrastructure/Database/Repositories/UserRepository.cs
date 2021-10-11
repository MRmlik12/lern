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
        private DbSet<User> Users { get; }

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
        
        public async Task<User> GetUserByEmail(string email)
            => await Users.OrderBy(e => e.Email).Where(e => e.Email == email).FirstAsync();

        public async Task<int> CountUsersByUsername(string username)
            => await Users.OrderBy(e => e.Username).Where(e => e.Username == username).CountAsync();
        
        public Task Update(User user)
        {
            Users.Update(user);

            return Task.CompletedTask;
        }

        public Task Delete(User user)
        {
            Users.Remove(user);
            return Task.CompletedTask;
        }
    }
}