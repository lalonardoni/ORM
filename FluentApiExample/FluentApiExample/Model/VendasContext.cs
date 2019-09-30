using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiExample.Model
{
    public class VendasContext : DbContext
    {
        public VendasContext() : base("name=VendasConnectionString")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<VendaItem> VendaItens { get; set; }
        public DbSet<Venda> Vendas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("venda");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Produto>()
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Produto>().ToTable("ProdutosAVenda", "estoque");

            modelBuilder.Entity<VendaItem>()
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<VendaItem>().ToTable("ItensDaVenda");

            modelBuilder.Entity<Venda>()
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Venda>().ToTable("VendasRealizadas");

            modelBuilder.Entity<Venda>()
                .HasRequired<Cliente>(v => v.Cliente).WithMany(c => c.ComprasRealizadas)
                .HasForeignKey(v => v.ClienteId);

            modelBuilder.Entity<VendaItem>()
                .HasRequired<Produto>(i => i.Produto).WithMany(p => p.VendaItens)
                .HasForeignKey(i => i.ProdutoId);

            modelBuilder.Entity<VendaItem>()
                .HasRequired<Venda>(i => i.Venda).WithMany(v => v.ItensDaVenda)
                .HasForeignKey(i => i.VendaId);
        }

    }
}
