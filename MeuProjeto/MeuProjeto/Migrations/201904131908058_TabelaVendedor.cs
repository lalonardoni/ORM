namespace MeuProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaVendedor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendedor",
                c => new
                    {
                        VendedorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.VendedorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendedor");
        }
    }
}
