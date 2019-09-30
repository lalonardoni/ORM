namespace FluentApiExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TEste : DbMigration
    {
        public override void Up()
        {
            AlterColumn("venda.ItensDaVenda", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("venda.ItensDaVenda", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
