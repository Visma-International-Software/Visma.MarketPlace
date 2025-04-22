namespace Visma.MarketPlace.Users.Data
{
    using System.Linq;
    using Visma.MarketPlace.Users.Entities;
    public interface IUserData
    {
        IQueryable<User> Get();

        User Add(User user);
    }
}