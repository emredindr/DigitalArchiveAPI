using DigitalArchive.DataAccess.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalArchive.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDbConnectionServices(this IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(option => option.UseNpgsql("User ID=postgres;Password=archive4277.;Host=localhost;Port=5432;Database=ArchiveDb;"));
            services.AddDbContext<AppDbContext>(option => option.UseNpgsql("Host=amazon.cqpwmitrilij.us-east-2.rds.amazonaws.com;Port=5432;Username=emredindr;Password=L055LTImBe49zpwV; Database=archive;"));
        }
    }
}