namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InspectItems", "BodyRegionID", "dbo.BodyRegions");
            DropIndex("dbo.InspectItems", new[] { "BodyRegionID" });
            DropColumn("dbo.InspectItems", "BodyRegionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InspectItems", "BodyRegionID", c => c.Int(nullable: false));
            CreateIndex("dbo.InspectItems", "BodyRegionID");
            AddForeignKey("dbo.InspectItems", "BodyRegionID", "dbo.BodyRegions", "ID", cascadeDelete: true);
        }
    }
}
