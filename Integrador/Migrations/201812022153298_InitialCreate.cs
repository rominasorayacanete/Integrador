namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 15),
                        Email = c.String(),
                        FechaAltaSistema = c.DateTime(nullable: false),
                        numeroDocumento = c.Int(),
                        puntos = c.Int(),
                        telefono = c.Int(),
                        tipoDocumento = c.String(),
                        Latitud = c.Double(),
                        Longitud = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
