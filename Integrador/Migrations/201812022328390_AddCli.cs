namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCli : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuarios", "numeroDocumento");
            DropColumn("dbo.Usuarios", "puntos");
            DropColumn("dbo.Usuarios", "telefono");
            DropColumn("dbo.Usuarios", "tipoDocumento");
            DropColumn("dbo.Usuarios", "Latitud");
            DropColumn("dbo.Usuarios", "Longitud");
            DropColumn("dbo.Usuarios", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Usuarios", "Longitud", c => c.Double());
            AddColumn("dbo.Usuarios", "Latitud", c => c.Double());
            AddColumn("dbo.Usuarios", "tipoDocumento", c => c.String());
            AddColumn("dbo.Usuarios", "telefono", c => c.Int());
            AddColumn("dbo.Usuarios", "puntos", c => c.Int());
            AddColumn("dbo.Usuarios", "numeroDocumento", c => c.Int());
        }
    }
}
