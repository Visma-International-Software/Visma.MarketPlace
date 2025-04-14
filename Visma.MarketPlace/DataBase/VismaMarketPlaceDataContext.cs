namespace Visma.MarketPlace.Database
{
    using Microsoft.EntityFrameworkCore;
    using Visma.MarketPlace.Users.Entities;

    public class VismaMarketPlaceDataContext(DbContextOptions<VismaMarketPlaceDataContext> options) : DbContext(options)// , IVismaMarketPlaceDataContext
    {

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUser(modelBuilder);
        }

        private static void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasIndex(e => e.Id);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .HasMaxLength(30);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(e => e.DirectManagerId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.HiringLegalUnitId)
                
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.IsITResponsible)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedAt)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.UpdatedAt)
                .IsRequired();
        }
    }
}
