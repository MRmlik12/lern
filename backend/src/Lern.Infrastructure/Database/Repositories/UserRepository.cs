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
    }
}