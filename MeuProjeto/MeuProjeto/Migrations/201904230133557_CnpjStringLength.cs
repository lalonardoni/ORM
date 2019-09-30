namespace MeuProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CnpjStringLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fornecedor", "Cnpj", c => c.String(maxLength: 14));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fornecedor", "Cnpj", c => c.String());
        }
    }
}
