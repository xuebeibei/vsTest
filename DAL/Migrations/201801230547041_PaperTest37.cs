namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest37 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InspectDetails", "InspectID", "dbo.Inspects");
            DropForeignKey("dbo.InspectDetails", "InspectItemID", "dbo.InspectItems");
            DropForeignKey("dbo.Inspects", "WriteUserID", "dbo.Users");
            DropIndex("dbo.Inspects", new[] { "WriteUserID" });
            DropIndex("dbo.InspectDetails", new[] { "InspectItemID" });
            DropIndex("dbo.InspectDetails", new[] { "InspectID" });
            DropTable("dbo.Inspects");
            DropTable("dbo.InspectDetails");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Inspects",
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
            
            CreateIndex("dbo.InspectDetails", "InspectID");
            CreateIndex("dbo.InspectDetails", "InspectItemID");
            CreateIndex("dbo.Inspects", "WriteUserID");
            AddForeignKey("dbo.Inspects", "WriteUserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.InspectDetails", "InspectItemID", "dbo.InspectItems", "ID", cascadeDelete: true);
            AddForeignKey("dbo.InspectDetails", "InspectID", "dbo.Inspects", "ID", cascadeDelete: true);
        }
    }
}
