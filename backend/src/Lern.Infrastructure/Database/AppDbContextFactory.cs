using System;
using Microsoft.EntityFrameworkCore.Design;

namespace Lern.Infrastructure.Database
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            return new AppDbContext(Environment.GetEnvironmentVariable("POSTGRES_STRING")
                                    ?? "Server=localhost;Database=lern;Uid=test;Pwd=123;");
        }
    }
}