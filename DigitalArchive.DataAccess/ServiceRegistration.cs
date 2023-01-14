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
            services.AddDbContext<AppDbContext>(option => option.UseNpgsql("Server=archivedb.postgres.database.azure.com; Port=5432; Database=ArchiveDb; UserId=emredindr@archivedb; Password=5m#C!502rR5Nn%6tgj8o;"));
        }
        //static public string ConnectionString
        //{
        //    get
        //    {
        //        ConfigurationManager configurationManager = new();
        //        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DigitalArchive.API"));
        //        configurationManager.AddJsonFile("appsettings.json");
        //        return configurationManager.GetConnectionString("PostgreSQL");
        //    }
        //}
    }
}