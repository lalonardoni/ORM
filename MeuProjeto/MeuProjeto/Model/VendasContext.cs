using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjeto.Model
{
    public class VendasContext : DbContext
    {
        public VendasContext():base("name=VendasDBConnectionString")
        {
            Database.SetInitializer<VendasContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<GrupoProduto> GrupoProdutos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Vendedor> Vendedores { get; set; }
    }
}
