namespace CodefirstFromDataBaseExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TelefoneCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CLIENTE", "TELEFONE", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CLIENTE", "TELEFONE");
        }
    }
}
