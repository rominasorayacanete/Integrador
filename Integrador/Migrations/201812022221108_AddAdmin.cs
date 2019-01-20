namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdmin : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Administradors", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Administradors", new[] { "Usuario_Id" });
            DropTable("dbo.Administradors");
        }
    }
}
