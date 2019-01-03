namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostClass : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Operacions", "Usuario_Id", c => c.Int());
            CreateIndex("dbo.Operacions", "Usuario_Id");
            AddForeignKey("dbo.Operacions", "Usuario_Id", "dbo.Usuarios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operacions", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Operacions", new[] { "Usuario_Id" });
            DropColumn("dbo.Operacions", "Usuario_Id");
            DropTable("dbo.TemplateDispositivoes");
        }
    }
}
