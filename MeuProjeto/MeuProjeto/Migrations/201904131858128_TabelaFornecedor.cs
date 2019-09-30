namespace MeuProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaFornecedor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        ChaveFornecedor = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cnpj = c.String(),
                    })
                .PrimaryKey(t => t.ChaveFornecedor);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fornecedor");
        }
    }
}
