namespace MeuProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionamentoFornecedorProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "FornecedorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produto", "FornecedorId");
            AddForeignKey("dbo.Produto", "FornecedorId", "dbo.Fornecedor", "ChaveFornecedor", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "FornecedorId", "dbo.Fornecedor");
            DropIndex("dbo.Produto", new[] { "FornecedorId" });
            DropColumn("dbo.Produto", "FornecedorId");
        }
    }
}
