using DigitalArchive.Business.Abstract;
using DigitalArchive.Business.Concreate;
using DigitalArchive.Core.Authorization;
using DigitalArchive.Core.Logging.FileLog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DigitalArchive.Business
{
    public static class ServiceRegistrationBusiness
    {
        public static void AddDependencyResolver(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILoggerProvider, FileLoggerProvider>();
            //serviceCollection.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            //serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //serviceCollection.AddScoped<IUserAppService, UserAppService>();
            serviceCollection.AddScoped<IUserManager, UserManager>();
        }
    }
}
