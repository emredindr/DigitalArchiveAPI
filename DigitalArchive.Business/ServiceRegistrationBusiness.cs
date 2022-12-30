using DigitalArchive.Core.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalArchive.Business
{
    public static class ServiceRegistrationBusiness
    {
        public static void AddDependencyResolver(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddSingleton<ILoggerProvider, FileLoggerProvider>();
            //serviceCollection.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            //serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //serviceCollection.AddScoped<IUserAppService, UserAppService>();
            serviceCollection.AddScoped<IUserManager, UserManager>();
        }
    }
}
