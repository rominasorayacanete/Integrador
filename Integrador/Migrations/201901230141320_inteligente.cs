namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inteligente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dispositivoes", "Encendido", c => c.Boolean());
            AddColumn("dbo.Dispositivoes", "ModoAhorroDeEnergia", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dispositivoes", "ModoAhorroDeEnergia");
            DropColumn("dbo.Dispositivoes", "Encendido");
        }
    }
}
