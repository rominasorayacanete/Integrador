namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDispositivos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dispositivoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreGenerico = c.String(nullable: false, maxLength: 15),
                        ConsumoPorHora = c.Int(nullable: false),
                        Consumo = c.Int(nullable: false),
                        UsoMensualMax = c.Int(nullable: false),
                        UsoMensualMin = c.Int(nullable: false),
                        Inteligente = c.Boolean(nullable: false),
                        Marca = c.String(maxLength: 15),
                        UsoEstimado = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Actuadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Accion = c.String(nullable: false, maxLength: 255),
                        Dispositivo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dispositivoes", t => t.Dispositivo_Id)
                .Index(t => t.Dispositivo_Id);
            
            CreateTable(
                "dbo.Reglas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReglaCumplida = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Operacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 255),
                        Fecha = c.DateTime(nullable: false),
                        Dispositivo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dispositivoes", t => t.Dispositivo_Id)
                .Index(t => t.Dispositivo_Id);
            
            CreateTable(
                "dbo.ReglaActuadors",
                c => new
                    {
                        Regla_Id = c.Int(nullable: false),
                        Actuador_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Regla_Id, t.Actuador_Id })
                .ForeignKey("dbo.Reglas", t => t.Regla_Id, cascadeDelete: true)
                .ForeignKey("dbo.Actuadors", t => t.Actuador_Id, cascadeDelete: true)
                .Index(t => t.Regla_Id)
                .Index(t => t.Actuador_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dispositivoes", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Operacions", "Dispositivo_Id", "dbo.Dispositivoes");
            DropForeignKey("dbo.ReglaActuadors", "Actuador_Id", "dbo.Actuadors");
            DropForeignKey("dbo.ReglaActuadors", "Regla_Id", "dbo.Reglas");
            DropForeignKey("dbo.Actuadors", "Dispositivo_Id", "dbo.Dispositivoes");
            DropIndex("dbo.ReglaActuadors", new[] { "Actuador_Id" });
            DropIndex("dbo.ReglaActuadors", new[] { "Regla_Id" });
            DropIndex("dbo.Operacions", new[] { "Dispositivo_Id" });
            DropIndex("dbo.Actuadors", new[] { "Dispositivo_Id" });
            DropIndex("dbo.Dispositivoes", new[] { "Cliente_Id" });
            DropTable("dbo.ReglaActuadors");
            DropTable("dbo.Operacions");
            DropTable("dbo.Reglas");
            DropTable("dbo.Actuadors");
            DropTable("dbo.Dispositivoes");
        }
    }
}
