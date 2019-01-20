namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "FechaAltaSistema", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "FechaAltaSistema", c => c.DateTime(nullable: false));
        }
    }
}
