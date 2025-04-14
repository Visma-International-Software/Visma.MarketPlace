namespace Visma.MarketPlace.Users.Querries
{
    using Visma.MarketPlace.Users.Entities;
    using System.Linq;

    public interface IGetAllUsers
    {
        IQueryable<User> Execute();
    }
}