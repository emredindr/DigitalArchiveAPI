using DigitalArchive.DataAccess.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DigitalArchive.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(ServiceRegistration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
