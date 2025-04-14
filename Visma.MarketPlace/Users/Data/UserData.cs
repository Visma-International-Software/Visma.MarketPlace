namespace Visma.MarketPlace.Users.Data
{
    using System.Linq;
    using Visma.MarketPlace.Database;
    using Visma.MarketPlace.Users.Entities;
    public class UserData(VismaMarketPlaceDataContext context) : IUserData
    {
        private readonly VismaMarketPlaceDataContext _context = context;

        public IQueryable<User> Get() 
        { 
            return _context.User.AsQueryable<User>(); 
        }

        public void Add(User user)
        {
             _context.User.Add(user); 
        }

        public void Update(User user)
        {
            _context.User.Update(user);
        }

        public void Delete(User user)
        {
            _context.User.Remove(user);
        }
    }
}
