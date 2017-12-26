namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Therapies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        RegistrationID = c.Int(nullable: false),
                        InpatientID = c.Int(nullable: false),
                        SumOfMoney = c.Double(nullable: false),
                        WriteTime = c.DateTime(nullable: false),
                        WriteUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.WriteUserID, cascadeDelete: true)
                .Index(t => t.WriteUserID);
            
            CreateTable(
                "dbo.TherapyDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TherapyItemID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Illustration = c.String(),
                        TherapyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Therapies", t => t.TherapyID, cascadeDelete: true)
                .ForeignKey("dbo.TherapyItems", t => t.TherapyItemID, cascadeDelete: true)
                .Index(t => t.TherapyItemID)
                .Index(t => t.TherapyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Therapies", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.TherapyDetails", "TherapyItemID", "dbo.TherapyItems");
            DropForeignKey("dbo.TherapyDetails", "TherapyID", "dbo.Therapies");
            DropIndex("dbo.TherapyDetails", new[] { "TherapyID" });
            DropIndex("dbo.TherapyDetails", new[] { "TherapyItemID" });
            DropIndex("dbo.Therapies", new[] { "WriteUserID" });
            DropTable("dbo.TherapyDetails");
            DropTable("dbo.Therapies");
        }
    }
}
