namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdispositivoentity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dispositivoes", "NombreGenerico", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Dispositivoes", "Marca", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dispositivoes", "Marca", c => c.String(maxLength: 15));
            AlterColumn("dbo.Dispositivoes", "NombreGenerico", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
