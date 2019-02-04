namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dispositivoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ConsumoPorHora = c.Single(nullable: false),
                        Encendido = c.Boolean(nullable: false),
                        ModoAhorro = c.Boolean(),
                        UsoEstimado = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Cliente_Id = c.Int(),
                        Adaptador_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Cliente_Id)
                .ForeignKey("dbo.Dispositivoes", t => t.Adaptador_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Adaptador_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        FechaAltaSistema = c.DateTime(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        TipoDocumento = c.String(),
                        NroDocumento = c.Int(),
                        Puntos = c.Int(),
                        Telefono = c.Int(),
                        Latitud = c.Single(),
                        Longitud = c.Single(),
                        IdSistema = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Categoria_Id = c.Int(),
                        Domicilio_Id = c.Int(),
                        Transformador_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .ForeignKey("dbo.Domicilios", t => t.Domicilio_Id)
                .ForeignKey("dbo.Transformadors", t => t.Transformador_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Domicilio_Id)
                .Index(t => t.Transformador_Id);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsumoMinimo = c.Single(nullable: false),
                        ConsumoMaximo = c.Single(nullable: false),
                        CargoFijo = c.Single(nullable: false),
                        CargoVariable = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Domicilios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Calle = c.String(),
                        Altura = c.Int(nullable: false),
                        Piso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transformadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 15),
                        Activo = c.Boolean(nullable: false),
                        EnergiaSuministrada = c.Double(nullable: false),
                        Latitud = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                        ZonaGeografica_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ZonaGeograficas", t => t.ZonaGeografica_Id)
                .Index(t => t.ZonaGeografica_Id);
            
            CreateTable(
                "dbo.Operacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Descripcion = c.String(maxLength: 100),
                        Fecha = c.DateTime(nullable: false),
                        Dispositivo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dispositivoes", t => t.Dispositivo_Id)
                .Index(t => t.Dispositivo_Id);
            
            CreateTable(
                "dbo.TemplateDispositivoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Inteligente = c.Boolean(nullable: false),
                        BajoConsumo = c.Boolean(nullable: false),
                        Consumo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ZonaGeograficas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Radio = c.Int(nullable: false),
                        NombreZona = c.String(nullable: false, maxLength: 15),
                        Latitud = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transformadors", "ZonaGeografica_Id", "dbo.ZonaGeograficas");
            DropForeignKey("dbo.Operacions", "Dispositivo_Id", "dbo.Dispositivoes");
            DropForeignKey("dbo.Dispositivoes", "Adaptador_Id", "dbo.Dispositivoes");
            DropForeignKey("dbo.Dispositivoes", "Cliente_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "Transformador_Id", "dbo.Transformadors");
            DropForeignKey("dbo.Usuarios", "Domicilio_Id", "dbo.Domicilios");
            DropForeignKey("dbo.Usuarios", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.Operacions", new[] { "Dispositivo_Id" });
            DropIndex("dbo.Transformadors", new[] { "ZonaGeografica_Id" });
            DropIndex("dbo.Usuarios", new[] { "Transformador_Id" });
            DropIndex("dbo.Usuarios", new[] { "Domicilio_Id" });
            DropIndex("dbo.Usuarios", new[] { "Categoria_Id" });
            DropIndex("dbo.Dispositivoes", new[] { "Adaptador_Id" });
            DropIndex("dbo.Dispositivoes", new[] { "Cliente_Id" });
            DropTable("dbo.ZonaGeograficas");
            DropTable("dbo.TemplateDispositivoes");
            DropTable("dbo.Operacions");
            DropTable("dbo.Transformadors");
            DropTable("dbo.Domicilios");
            DropTable("dbo.Categorias");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Dispositivoes");
        }
    }
}
