using CurrencyConverter.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.Data
{
    public class CurrencyConverterContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public CurrencyConverterContext(DbContextOptions<CurrencyConverterContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>()
                .HasMany(subscription => subscription.Users)
                .WithOne(user => user.Subscription);

            base.OnModelCreating(modelBuilder);
        }
    }
}
