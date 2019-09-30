using Microsoft.EntityFrameworkCore;

namespace VendasApp.Models
{
    public class VendasContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<VendaItem> VendaItens { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9H7QD14\SQLEXPRESS;Initial Catalog=VENDASAPP;Integrated Security=true");
        }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(x => x.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<Produto>()
                .Property(x => x.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<VendaItem>()
                .Property(x => x.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<Venda>()
                .Property(x => x.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<Venda>()
                .HasOne<Cliente>(v => v.Cliente).WithMany(c => c.ComprasRealizadas)
                .HasForeignKey(v => v.ClienteId);

            modelBuilder.Entity<VendaItem>()
                .HasOne<Produto>(i => i.Produto).WithMany(p => p.VendaItens)
                .HasForeignKey(i => i.ProdutoId);

            modelBuilder.Entity<VendaItem>()
                .HasOne<Venda>(i => i.Venda).WithMany(v => v.ItensDaVenda)
                .HasForeignKey(i => i.VendaId);
        }
    }
}