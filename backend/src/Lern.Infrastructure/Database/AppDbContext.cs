using System.Reflection;
using Lern.Core.ProjectAggregate.Set;
using Lern.Core.ProjectAggregate.User;
using Microsoft.EntityFrameworkCore;

namespace Lern.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        
        public DbSet<User> Users { get; set; }
        public DbSet<Set> Sets { get; set; }

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}