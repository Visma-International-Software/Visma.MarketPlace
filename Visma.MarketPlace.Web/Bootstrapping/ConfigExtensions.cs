namespace Visma.MarketPlace.Web.Bootstrapping
{
    using Microsoft.EntityFrameworkCore;
    using Visma.MarketPlace.Bootstrapping.DependencyInjection.Autofac;
    using Visma.MarketPlace.Database;

    internal static class ConfigExtensions
    {
        internal static void Setup(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Visma.MarketPlace.ConnectionString");
            builder.Services.AddDbContext<VismaMarketPlaceDataContext>(options =>
                options.UseSqlServer(connectionString));

            builder.ConfigureContainer();

            builder.Services.AddControllers(mvcOptions =>
            {
                mvcOptions.Filters.Add<ControllersDependencyFilter>();
            });
        }
    }
}
