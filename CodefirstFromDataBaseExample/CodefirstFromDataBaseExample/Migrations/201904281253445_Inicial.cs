namespace CodefirstFromDataBaseExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CLIENTE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NOME = c.String(maxLength: 50),
                        CPF = c.String(maxLength: 50),
                        DATANASCIMENTO = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VENDA",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CLIENTE = c.Int(),
                        PRODUTO = c.Int(),
                        DATAVENDA = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PRODUTO", t => t.PRODUTO)
                .ForeignKey("dbo.CLIENTE", t => t.CLIENTE)
                .Index(t => t.CLIENTE)
                .Index(t => t.PRODUTO);
            
            CreateTable(
                "dbo.PRODUTO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CODIGO = c.String(maxLength: 20),
                        DESCRICAO = c.String(maxLength: 50),
                        VALOR = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VENDA", "CLIENTE", "dbo.CLIENTE");
            DropForeignKey("dbo.VENDA", "PRODUTO", "dbo.PRODUTO");
            DropIndex("dbo.VENDA", new[] { "PRODUTO" });
            DropIndex("dbo.VENDA", new[] { "CLIENTE" });
            DropTable("dbo.PRODUTO");
            DropTable("dbo.VENDA");
            DropTable("dbo.CLIENTE");
        }
    }
}
