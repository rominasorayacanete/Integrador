namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransformadores : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clientes", "Transformador_Id", c => c.Int());
            CreateIndex("dbo.Clientes", "Transformador_Id");
            AddForeignKey("dbo.Clientes", "Transformador_Id", "dbo.Transformadors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "Transformador_Id", "dbo.Transformadors");
            DropIndex("dbo.Clientes", new[] { "Transformador_Id" });
            DropColumn("dbo.Clientes", "Transformador_Id");
            DropTable("dbo.Transformadors");
        }
    }
}
