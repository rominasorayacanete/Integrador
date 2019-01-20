namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixlog : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Operacions", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Operacions", new[] { "Usuario_Id" });
            AddColumn("dbo.Operacions", "LogType_Id", c => c.Int());
            AddColumn("dbo.LogTypes", "Tipo", c => c.String(maxLength: 25));
            AlterColumn("dbo.Operacions", "Descripcion", c => c.String(maxLength: 100));
            CreateIndex("dbo.Operacions", "LogType_Id");
            AddForeignKey("dbo.Operacions", "LogType_Id", "dbo.LogTypes", "Id");
            DropColumn("dbo.Operacions", "Fecha");
            DropColumn("dbo.Operacions", "Usuario_Id");
            DropColumn("dbo.LogTypes", "Accion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LogTypes", "Accion", c => c.String());
            AddColumn("dbo.Operacions", "Usuario_Id", c => c.Int());
            AddColumn("dbo.Operacions", "Fecha", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Operacions", "LogType_Id", "dbo.LogTypes");
            DropIndex("dbo.Operacions", new[] { "LogType_Id" });
            AlterColumn("dbo.Operacions", "Descripcion", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.LogTypes", "Tipo");
            DropColumn("dbo.Operacions", "LogType_Id");
            CreateIndex("dbo.Operacions", "Usuario_Id");
            AddForeignKey("dbo.Operacions", "Usuario_Id", "dbo.Usuarios", "Id");
        }
    }
}
