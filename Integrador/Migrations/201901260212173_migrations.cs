namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSistema = c.String(nullable: false, maxLength: 15),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 15),
                        Email = c.String(),
                        FechaAltaSistema = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 25),
                        Apellido = c.String(nullable: false, maxLength: 25),
                        TipoDoc = c.String(nullable: false, maxLength: 15),
                        NroDoc = c.Int(nullable: false),
                        Domicilio = c.String(maxLength: 30),
                        Puntos = c.Int(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Longitud = c.Double(nullable: false),
                        Latitud = c.Double(nullable: false),
                        Categoria_Id = c.Int(),
                        Transformador_Id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .ForeignKey("dbo.Transformadors", t => t.Transformador_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Transformador_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Dispositivoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreGenerico = c.String(nullable: false, maxLength: 50),
                        Consumo = c.Int(nullable: false),
                        UsoMensualMax = c.Int(nullable: false),
                        UsoMensualMin = c.Int(nullable: false),
                        UsoEstimado = c.Int(),
                        Encendido = c.Boolean(),
                        ModoAhorroDeEnergia = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        MarcaDispositivo_Id = c.Double(),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MarcaDispositivoes", t => t.MarcaDispositivo_Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.MarcaDispositivo_Id)
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
                "dbo.MarcaDispositivoes",
                c => new
                    {
                        Id = c.Double(nullable: false),
                        Consumo = c.Double(nullable: false),
                        UsoMensualMax = c.Int(nullable: false),
                        UsoMensualMin = c.Int(nullable: false),
                        EquipoConcreto = c.String(),
                        Intensidad = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.Transformadors", "ZonaGeografica_Id", "dbo.ZonaGeograficas");
            DropForeignKey("dbo.Clientes", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Clientes", "Transformador_Id", "dbo.Transformadors");
            DropForeignKey("dbo.Dispositivoes", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Operacions", "Dispositivo_Id", "dbo.Dispositivoes");
            DropForeignKey("dbo.Dispositivoes", "MarcaDispositivo_Id", "dbo.MarcaDispositivoes");
            DropForeignKey("dbo.ReglaActuadors", "Actuador_Id", "dbo.Actuadors");
            DropForeignKey("dbo.ReglaActuadors", "Regla_Id", "dbo.Reglas");
            DropForeignKey("dbo.Actuadors", "Dispositivo_Id", "dbo.Dispositivoes");
            DropForeignKey("dbo.Clientes", "Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.Administradors", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.ReglaActuadors", new[] { "Actuador_Id" });
            DropIndex("dbo.ReglaActuadors", new[] { "Regla_Id" });
            DropIndex("dbo.Transformadors", new[] { "ZonaGeografica_Id" });
            DropIndex("dbo.Operacions", new[] { "Dispositivo_Id" });
            DropIndex("dbo.Actuadors", new[] { "Dispositivo_Id" });
            DropIndex("dbo.Dispositivoes", new[] { "Cliente_Id" });
            DropIndex("dbo.Dispositivoes", new[] { "MarcaDispositivo_Id" });
            DropIndex("dbo.Clientes", new[] { "Usuario_Id" });
            DropIndex("dbo.Clientes", new[] { "Transformador_Id" });
            DropIndex("dbo.Clientes", new[] { "Categoria_Id" });
            DropIndex("dbo.Administradors", new[] { "Usuario_Id" });
            DropTable("dbo.ReglaActuadors");
            DropTable("dbo.ZonaGeograficas");
            DropTable("dbo.TemplateDispositivoes");
            DropTable("dbo.Transformadors");
            DropTable("dbo.Operacions");
            DropTable("dbo.MarcaDispositivoes");
            DropTable("dbo.Reglas");
            DropTable("dbo.Actuadors");
            DropTable("dbo.Dispositivoes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Categorias");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Administradors");
        }
    }
}
