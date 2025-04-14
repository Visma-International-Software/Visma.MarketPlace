namespace Visma.MarketPlace.Web.Bootstrapping
{
    using Autofac.Extensions.DependencyInjection;
    using Autofac;
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder ConfigureContainer(this WebApplicationBuilder builder)
        {
            builder.Host
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacModule());
                });

            return builder;
        }
    }
}
