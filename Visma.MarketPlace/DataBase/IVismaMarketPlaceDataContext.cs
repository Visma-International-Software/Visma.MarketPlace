namespace Visma.MarketPlace.Database
{

    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Visma.MarketPlace.Users.Entities;

    public interface IVismaMarketPlaceDataContext
    {
        DbSet<User> User { get; }
    }
}