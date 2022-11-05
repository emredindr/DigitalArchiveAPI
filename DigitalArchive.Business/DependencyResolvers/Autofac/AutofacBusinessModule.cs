using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using DigitalArchive.Core.MailSender;
using DigitalArchive.Core.MailSender.Configuration;
using DigitalArchive.Core.Repositories;
using DigitalArchive.Core.Utilities.Interceptors;
using DigitalArchive.Core.Utilities.Security.JWT;
using DigitalArchive.Core.Utilities.Security.JWT.Configuration;
using DigitalArchive.DataAccess.EntityFrameworkCore.Repositories;
using System.Reflection;
using Module = Autofac.Module;

namespace DigitalArchive.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Generic Repo
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).InstancePerDependency();
            builder.RegisterType<JwtAuthenticationManager>().As<IJwtAuthenticationManager>().SingleInstance();
            builder.RegisterType<MailSender>().As<IMailSender>().SingleInstance();
            builder.RegisterType<MailConfiguration>().As<IMailConfiguration>().SingleInstance();
            builder.RegisterType<JwtConfiguration>().As<IJwtConfiguration>().SingleInstance();



            //Aspect Oriented Programming
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions { Selector = new AspectInterceptorSelector() })
                .InstancePerLifetimeScope();

        }
    }
}