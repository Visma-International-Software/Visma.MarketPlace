namespace Visma.MarketPlace.Web.Bootstrapping
{
    using Autofac;
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;
    using Visma.MarketPlace.Bootstrapping.DependencyInjection.Autofac;

    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder RegisterConfigurationRoot(this ContainerBuilder container)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            container.RegisterInstance(configuration).As<IConfiguration>().SingleInstance();
            container.RegisterInstance(configuration).As<IConfigurationRoot>().SingleInstance();

            return container;
        }

        public static ContainerBuilder RegisterClaims(this ContainerBuilder container)
        {
            container
                .Register(c => CreateClaimsIdentityFactory(c.Resolve<IHttpContextAccessor>()))
                .As<Func<ClaimsIdentity>>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(new DependencyAttributePropertySelector());

            return container;
        }

        //public static ContainerBuilder RegisterDbContextFactory(this ContainerBuilder container)
        //{
        //    container
        //        .Register((IComponentContext context) =>
        //        {
        //            var dbContextOptions = context.Resolve<DbContextOptions<MarketPlaceDbContext>>();
        //            return new DbContextFactory(dbContextOptions);
        //        })
        //        .As<IFactory>()
        //        .InstancePerLifetimeScope()
        //        .PropertiesAutowired(new DependencyAttributePropertySelector());

        //    return container;
        //}

        public static ContainerBuilder RegisterControllers(this ContainerBuilder container)
        {
            container
                .RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => typeof(Microsoft.AspNetCore.Mvc.ControllerBase).IsAssignableFrom(t))
                .InstancePerLifetimeScope()
                .PropertiesAutowired(new DependencyAttributePropertySelector())
                .OnActivated(e => e.Context.InjectUnsetProperties(e.Instance));

            return container;
        }

        private static Func<ClaimsIdentity> CreateClaimsIdentityFactory(IHttpContextAccessor httpContextAccessor)
        {
            return () => httpContextAccessor?.HttpContext?.User?.Identity as ClaimsIdentity;
        }
    }
}
