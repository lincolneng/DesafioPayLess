using Microsoft.EntityFrameworkCore;
using PayLess.Data.Mappings;
using PayLess.Models;

namespace PayLess.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<EstoqueLoja> EstoqueLojas { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new LojaMap());
            modelBuilder.ApplyConfiguration(new EstoqueLojaMap());
        }

    }
}
