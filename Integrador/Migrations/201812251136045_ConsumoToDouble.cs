namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsumoToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TemplateDispositivoes", "Consumo", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TemplateDispositivoes", "Consumo", c => c.Single(nullable: false));
        }
    }
}
