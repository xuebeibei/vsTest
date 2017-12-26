namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssayDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssayItemID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Illustration = c.String(),
                        AssayID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Assays", t => t.AssayID, cascadeDelete: true)
                .ForeignKey("dbo.AssayItems", t => t.AssayItemID, cascadeDelete: true)
                .Index(t => t.AssayItemID)
                .Index(t => t.AssayID);
            
            CreateTable(
                "dbo.Assays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        InpatientID = c.Int(nullable: false),
                        SumOfMoney = c.Double(nullable: false),
                        WriteTime = c.DateTime(nullable: false),
                        WriteUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.WriteUserID, cascadeDelete: true)
                .Index(t => t.WriteUserID);
            
            CreateTable(
                "dbo.Inspects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        InpatientID = c.Int(nullable: false),
                        SumOfMoney = c.Double(nullable: false),
                        WriteTime = c.DateTime(nullable: false),
                        WriteUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.WriteUserID, cascadeDelete: true)
                .Index(t => t.WriteUserID);
            
            CreateTable(
                "dbo.InspectDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InspectItemID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Illustration = c.String(),
                        InspectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inspects", t => t.InspectID, cascadeDelete: true)
                .ForeignKey("dbo.InspectItems", t => t.InspectItemID, cascadeDelete: true)
                .Index(t => t.InspectItemID)
                .Index(t => t.InspectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssayDetails", "AssayItemID", "dbo.AssayItems");
            DropForeignKey("dbo.Inspects", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.InspectDetails", "InspectItemID", "dbo.InspectItems");
            DropForeignKey("dbo.InspectDetails", "InspectID", "dbo.Inspects");
            DropForeignKey("dbo.Assays", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.AssayDetails", "AssayID", "dbo.Assays");
            DropIndex("dbo.InspectDetails", new[] { "InspectID" });
            DropIndex("dbo.InspectDetails", new[] { "InspectItemID" });
            DropIndex("dbo.Inspects", new[] { "WriteUserID" });
            DropIndex("dbo.Assays", new[] { "WriteUserID" });
            DropIndex("dbo.AssayDetails", new[] { "AssayID" });
            DropIndex("dbo.AssayDetails", new[] { "AssayItemID" });
            DropTable("dbo.InspectDetails");
            DropTable("dbo.Inspects");
            DropTable("dbo.Assays");
            DropTable("dbo.AssayDetails");
        }
    }
}
