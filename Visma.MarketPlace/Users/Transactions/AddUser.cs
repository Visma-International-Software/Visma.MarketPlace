namespace Visma.MarketPlace.Users.Transactions
{
    using System.Linq;
    using Visma.MarketPlace.Bootstrapping.DependencyInjection.Autofac;
    using Visma.MarketPlace.Database;
    using Visma.MarketPlace.Users.Data;
    using Visma.MarketPlace.Users.Entities;

    public class AddUser(VismaMarketPlaceDataContext context) : IAddUser
    {
        //private readonly VismaMarketPlaceDataContext _context = context;
        //[Dependency]
        //private IVismaMarketPlaceDataContext Context { get; set; }

        [Dependency]
        public required IUserData UserData { private get; init; }

        public User Execute(User user)
        {
            // Logic to get all users
            UserData.Add(user);

            return user;
        }
    }
}
