namespace MVCDEMO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventorymig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntityInventory",
                c => new
                    {
                        EntityId = c.Int(nullable: false),
                        EntityName = c.String(maxLength: 50),
                        EmissionYear = c.Int(),
                    })
                .PrimaryKey(t => t.EntityId);
            
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        FacilityID = c.Int(nullable: false),
                        EntityID = c.Int(),
                        FacilityName = c.String(nullable: false, maxLength: 50),
                        EmissionYear = c.Int(),
                    })
                .PrimaryKey(t => t.FacilityID)
                .ForeignKey("dbo.EntityInventory", t => t.EntityID)
                .Index(t => t.EntityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facilities", "EntityID", "dbo.EntityInventory");
            DropIndex("dbo.Facilities", new[] { "EntityID" });
            DropTable("dbo.Facilities");
            DropTable("dbo.EntityInventory");
        }
    }
}
