namespace Visma.MarketPlace.Users.Querries
{
    using System.Linq;
    using Visma.MarketPlace.Bootstrapping.DependencyInjection.Autofac;
    using Visma.MarketPlace.Database;
    using Visma.MarketPlace.Users.Data;
    using Visma.MarketPlace.Users.Entities;

    public class GetAllUsers(VismaMarketPlaceDataContext context) : IGetAllUsers
    {
        //private readonly VismaMarketPlaceDataContext _context = context;
        //[Dependency]
        //private IVismaMarketPlaceDataContext Context { get; set; }

        [Dependency]
        public required IUserData UserData { private get; init; }

        public IQueryable<User> Execute()
        {
            // Logic to get all users
            IQueryable<User> users = UserData.Get().Where(x => 1 == 1);

            return users;
        }
    }
}
