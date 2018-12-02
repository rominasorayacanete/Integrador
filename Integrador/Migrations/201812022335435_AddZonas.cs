namespace Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddZonas : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Transformadors", "ZonaGeografica_Id", c => c.Int());
            CreateIndex("dbo.Transformadors", "ZonaGeografica_Id");
            AddForeignKey("dbo.Transformadors", "ZonaGeografica_Id", "dbo.ZonaGeograficas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transformadors", "ZonaGeografica_Id", "dbo.ZonaGeograficas");
            DropIndex("dbo.Transformadors", new[] { "ZonaGeografica_Id" });
            DropColumn("dbo.Transformadors", "ZonaGeografica_Id");
            DropTable("dbo.ZonaGeograficas");
        }
    }
}
