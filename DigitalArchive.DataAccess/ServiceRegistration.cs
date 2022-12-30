using DigitalArchive.DataAccess.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalArchive.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDbConnectionServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(option => option.UseNpgsql(ConnectionString));
        }
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DigitalArchive.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}