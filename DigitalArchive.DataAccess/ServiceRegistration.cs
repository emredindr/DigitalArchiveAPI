using DigitalArchive.DataAccess.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalArchive.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDbConnectionServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer("server=.;database=DigitalArchiveDb; Trusted_Connection=True;"));
        }
    }
}