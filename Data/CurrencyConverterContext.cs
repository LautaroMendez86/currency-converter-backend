using currency_converter_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Data
{
    public class CurrencyConverterContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public CurrencyConverterContext(DbContextOptions<CurrencyConverterContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
