namespace Visma.MarketPlace.Users.Data
{
    using System.Collections.Generic;
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
        public void AddRange(List<User> users)
        {
            _context.User.AddRange(users);
        }


        public void Update(User user)
        {
            _context.User.Update(user);
        }
        public void UpdateRange(List<User> users)
        {
            _context.User.UpdateRange(users);
        }


        public void Delete(User user)
        {
            _context.User.Remove(user);
        }
        public void DeleteRange(List<User> users)
        {
            _context.User.RemoveRange(users);
        }
    }
}
