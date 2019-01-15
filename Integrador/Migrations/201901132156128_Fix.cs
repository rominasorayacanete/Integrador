namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Operacions", "Tipo_Id", "dbo.LogTypes");
            DropIndex("dbo.Operacions", new[] { "Tipo_Id" });
            DropColumn("dbo.Operacions", "Tipo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operacions", "Tipo_Id", c => c.Int());
            CreateIndex("dbo.Operacions", "Tipo_Id");
            AddForeignKey("dbo.Operacions", "Tipo_Id", "dbo.LogTypes", "Id");
        }
    }
}
