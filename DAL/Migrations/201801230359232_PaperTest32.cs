namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest32 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssayDetails", "AssayID", "dbo.Assays");
            DropForeignKey("dbo.Assays", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.AssayDetails", "AssayItemID", "dbo.AssayItems");
            DropIndex("dbo.AssayDetails", new[] { "AssayItemID" });
            DropIndex("dbo.AssayDetails", new[] { "AssayID" });
            DropIndex("dbo.Assays", new[] { "WriteUserID" });
            DropTable("dbo.AssayDetails");
            DropTable("dbo.Assays");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Assays",
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
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Assays", "WriteUserID");
            CreateIndex("dbo.AssayDetails", "AssayID");
            CreateIndex("dbo.AssayDetails", "AssayItemID");
            AddForeignKey("dbo.AssayDetails", "AssayItemID", "dbo.AssayItems", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Assays", "WriteUserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.AssayDetails", "AssayID", "dbo.Assays", "ID", cascadeDelete: true);
        }
    }
}
