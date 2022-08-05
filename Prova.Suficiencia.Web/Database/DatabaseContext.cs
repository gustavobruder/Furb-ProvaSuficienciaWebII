using Microsoft.EntityFrameworkCore;
using Prova.Suficiencia.Web.Entities;

namespace Prova.Suficiencia.Web.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }
    }
}