namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest30 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterialBillDetails", "MaterialBillID", "dbo.MaterialBills");
            DropForeignKey("dbo.MaterialBills", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.MaterialBillDetails", "MaterialItemID", "dbo.MaterialItems");
            DropIndex("dbo.MaterialBillDetails", new[] { "MaterialItemID" });
            DropIndex("dbo.MaterialBillDetails", new[] { "MaterialBillID" });
            DropIndex("dbo.MaterialBills", new[] { "WriteUserID" });
            DropTable("dbo.MaterialBillDetails");
            DropTable("dbo.MaterialBills");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MaterialBills",
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
                "dbo.MaterialBillDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MaterialItemID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Illustration = c.String(),
                        MaterialBillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.MaterialBills", "WriteUserID");
            CreateIndex("dbo.MaterialBillDetails", "MaterialBillID");
            CreateIndex("dbo.MaterialBillDetails", "MaterialItemID");
            AddForeignKey("dbo.MaterialBillDetails", "MaterialItemID", "dbo.MaterialItems", "ID", cascadeDelete: true);
            AddForeignKey("dbo.MaterialBills", "WriteUserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.MaterialBillDetails", "MaterialBillID", "dbo.MaterialBills", "ID", cascadeDelete: true);
        }
    }
}
