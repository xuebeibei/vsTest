namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssayItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                        Price = c.Double(nullable: false),
                        SpecimenID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Specimen", t => t.SpecimenID, cascadeDelete: true)
                .Index(t => t.SpecimenID);
            
            CreateTable(
                "dbo.Specimen",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BodyRegions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                        InspectItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InspectItems", t => t.InspectItemID, cascadeDelete: true)
                .Index(t => t.InspectItemID);
            
            CreateTable(
                "dbo.InspectItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MaterialItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                        StockPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TherapyItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BodyRegions", "InspectItemID", "dbo.InspectItems");
            DropForeignKey("dbo.AssayItems", "SpecimenID", "dbo.Specimen");
            DropIndex("dbo.BodyRegions", new[] { "InspectItemID" });
            DropIndex("dbo.AssayItems", new[] { "SpecimenID" });
            DropTable("dbo.TherapyItems");
            DropTable("dbo.MaterialItems");
            DropTable("dbo.InspectItems");
            DropTable("dbo.BodyRegions");
            DropTable("dbo.Specimen");
            DropTable("dbo.AssayItems");
        }
    }
}
