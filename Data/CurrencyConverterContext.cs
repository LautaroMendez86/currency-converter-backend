using CurrencyConverter.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.Data
{
    public class CurrencyConverterContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public CurrencyConverterContext(DbContextOptions<CurrencyConverterContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Subscription subcription = new()
            {
                Id = 1,
                Name = "Suscripción Free",
                Price = 0,
                TotalAvailableConversions = 10
            };

            Subscription subscriptionTrial = new()
            {
                Id = 2,
                Name = "Suscripción Trial",
                Price = 5,
                TotalAvailableConversions = 100
            };

            Subscription subscriptionPro = new()
            {
                Id = 3,
                Name = "Suscripción Pro",
                Price = 10,
                TotalAvailableConversions = 9999999
            };

            modelBuilder.Entity<Subscription>()
                .HasData(subcription, subscriptionTrial, subscriptionPro);

            modelBuilder.Entity<Subscription>()
                .HasMany(subscription => subscription.Users)
                .WithOne(user => user.Subscription);

            base.OnModelCreating(modelBuilder);
        }
    }
}
