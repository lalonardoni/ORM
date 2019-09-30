namespace CodefirstFromDataBaseExample
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VendaModel : DbContext
    {
        public VendaModel()
            : base("name=VendaModel")
        {
        }

        public virtual DbSet<CLIENTE> CLIENTE { get; set; }
        public virtual DbSet<PRODUTO> PRODUTO { get; set; }
        public virtual DbSet<VENDA> VENDA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CLIENTE>()
                .HasMany(e => e.VENDA)
                .WithOptional(e => e.CLIENTE1)
                .HasForeignKey(e => e.CLIENTE);

            modelBuilder.Entity<PRODUTO>()
                .Property(e => e.VALOR)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PRODUTO>()
                .HasMany(e => e.VENDA)
                .WithOptional(e => e.PRODUTO1)
                .HasForeignKey(e => e.PRODUTO);
        }
    }
}
