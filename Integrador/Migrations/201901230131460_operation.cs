namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class operation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Operacions", "LogType_Id", "dbo.LogTypes");
            DropIndex("dbo.Operacions", new[] { "LogType_Id" });
            AddColumn("dbo.Operacions", "Tipo", c => c.String());
            AddColumn("dbo.Operacions", "Fecha", c => c.DateTime(nullable: false));
            DropColumn("dbo.Operacions", "LogType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operacions", "LogType_Id", c => c.Int());
            DropColumn("dbo.Operacions", "Fecha");
            DropColumn("dbo.Operacions", "Tipo");
            CreateIndex("dbo.Operacions", "LogType_Id");
            AddForeignKey("dbo.Operacions", "LogType_Id", "dbo.LogTypes", "Id");
        }
    }
}
