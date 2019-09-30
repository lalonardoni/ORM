namespace MeuProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoDataNascimento : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "DataNascimento", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "DataNascimento", c => c.DateTime(nullable: false));
        }
    }
}
