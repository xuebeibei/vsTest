namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest18 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BodyRegions", "InspectItemID", "dbo.InspectItems");
            DropIndex("dbo.BodyRegions", new[] { "InspectItemID" });
            AddColumn("dbo.InspectItems", "BodyRegionID", c => c.Int(nullable: false));
            CreateIndex("dbo.InspectItems", "BodyRegionID");
            AddForeignKey("dbo.InspectItems", "BodyRegionID", "dbo.BodyRegions", "ID", cascadeDelete: true);
            DropColumn("dbo.BodyRegions", "InspectItemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BodyRegions", "InspectItemID", c => c.Int(nullable: false));
            DropForeignKey("dbo.InspectItems", "BodyRegionID", "dbo.BodyRegions");
            DropIndex("dbo.InspectItems", new[] { "BodyRegionID" });
            DropColumn("dbo.InspectItems", "BodyRegionID");
            CreateIndex("dbo.BodyRegions", "InspectItemID");
            AddForeignKey("dbo.BodyRegions", "InspectItemID", "dbo.InspectItems", "ID", cascadeDelete: true);
        }
    }
}
