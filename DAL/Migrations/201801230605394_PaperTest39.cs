namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest39 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TherapyDetails", "TherapyID", "dbo.Therapies");
            DropForeignKey("dbo.TherapyDetails", "TherapyItemID", "dbo.TherapyItems");
            DropForeignKey("dbo.Therapies", "WriteUserID", "dbo.Users");
            DropIndex("dbo.Therapies", new[] { "WriteUserID" });
            DropIndex("dbo.TherapyDetails", new[] { "TherapyItemID" });
            DropIndex("dbo.TherapyDetails", new[] { "TherapyID" });
            DropTable("dbo.Therapies");
            DropTable("dbo.TherapyDetails");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Therapies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        RegistrationID = c.Int(nullable: false),
                        InpatientID = c.Int(nullable: false),
                        SumOfMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WriteTime = c.DateTime(),
                        WriteUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.TherapyDetails", "TherapyID");
            CreateIndex("dbo.TherapyDetails", "TherapyItemID");
            CreateIndex("dbo.Therapies", "WriteUserID");
            AddForeignKey("dbo.Therapies", "WriteUserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TherapyDetails", "TherapyItemID", "dbo.TherapyItems", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TherapyDetails", "TherapyID", "dbo.Therapies", "ID", cascadeDelete: true);
        }
    }
}
