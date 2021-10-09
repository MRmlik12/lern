using System;
using System.Threading.Tasks;
using Lern.Infrastructure.Database.Interfaces;
using Lern.Infrastructure.Database.Repositories;

namespace Lern.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        
        public IUserRepository Users { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
        }
        
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        
        public void Dispose()
            => _context?.Dispose();
    }
}