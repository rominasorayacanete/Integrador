namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientes : DbMigration
    {
        public override void Up()
        {
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
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Usuario_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Clientes", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.Clientes", new[] { "Usuario_Id" });
            DropIndex("dbo.Clientes", new[] { "Categoria_Id" });
            DropTable("dbo.Categorias");
            DropTable("dbo.Clientes");
        }
    }
}
