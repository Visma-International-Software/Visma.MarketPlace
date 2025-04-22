namespace Visma.MarketPlace.Users.Transactions
{
    using Visma.MarketPlace.Users.Entities;
    using System.Linq;

    public interface IAddUser
    {
        User Execute(User user);
    }
}