namespace MeuProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrupoProduto",
                c => new
                    {
                        GrupoProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.GrupoProdutoId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Foto = c.Binary(),
                        PrecoProduto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Grupo_GrupoProdutoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrupoProduto", t => t.Grupo_GrupoProdutoId)
                .Index(t => t.Grupo_GrupoProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "Grupo_GrupoProdutoId", "dbo.GrupoProduto");
            DropIndex("dbo.Produto", new[] { "Grupo_GrupoProdutoId" });
            DropTable("dbo.Produto");
            DropTable("dbo.GrupoProduto");
        }
    }
}
