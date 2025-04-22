namespace Visma.MarketPlace.Web.Bootstrapping
{
    using Autofac;
    using Visma.MarketPlace.Bootstrapping.DependencyInjection.Autofac;
    using Visma.MarketPlace.Database;
    using Visma.MarketPlace.Users.Data;
    using Visma.MarketPlace.Users.Querries;
    using Visma.MarketPlace.Users.Transactions;

    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterClaims();
            builder.RegisterControllers();
            builder.RegisterConfigurationRoot();

            builder.RegisterType<VismaMarketPlaceDataContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterScoped<IGetAllUsers, GetAllUsers>();
            builder.RegisterScoped<IAddUser, AddUser>();
            builder.RegisterScoped<IUserData, UserData>();            
        }
    }
}