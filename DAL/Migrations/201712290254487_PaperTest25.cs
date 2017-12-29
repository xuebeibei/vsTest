namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest25 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterialBills",
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
                "dbo.MaterialBillDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MaterialItemID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Illustration = c.String(),
                        MaterialBillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MaterialBills", t => t.MaterialBillID, cascadeDelete: true)
                .ForeignKey("dbo.MaterialItems", t => t.MaterialItemID, cascadeDelete: true)
                .Index(t => t.MaterialItemID)
                .Index(t => t.MaterialBillID);
            
            CreateTable(
                "dbo.OtherServices",
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
                "dbo.OtherServiceDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OtherServiceItemID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Illustration = c.String(),
                        OtherServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OtherServices", t => t.OtherServiceID, cascadeDelete: true)
                .ForeignKey("dbo.OtherServiceItems", t => t.OtherServiceItemID, cascadeDelete: true)
                .Index(t => t.OtherServiceItemID)
                .Index(t => t.OtherServiceID);
            
            CreateTable(
                "dbo.OtherServiceItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                        Price = c.Double(nullable: false),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OtherServices", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.OtherServiceDetails", "OtherServiceItemID", "dbo.OtherServiceItems");
            DropForeignKey("dbo.OtherServiceDetails", "OtherServiceID", "dbo.OtherServices");
            DropForeignKey("dbo.MaterialBills", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.MaterialBillDetails", "MaterialItemID", "dbo.MaterialItems");
            DropForeignKey("dbo.MaterialBillDetails", "MaterialBillID", "dbo.MaterialBills");
            DropIndex("dbo.OtherServiceDetails", new[] { "OtherServiceID" });
            DropIndex("dbo.OtherServiceDetails", new[] { "OtherServiceItemID" });
            DropIndex("dbo.OtherServices", new[] { "WriteUserID" });
            DropIndex("dbo.MaterialBillDetails", new[] { "MaterialBillID" });
            DropIndex("dbo.MaterialBillDetails", new[] { "MaterialItemID" });
            DropIndex("dbo.MaterialBills", new[] { "WriteUserID" });
            DropTable("dbo.OtherServiceItems");
            DropTable("dbo.OtherServiceDetails");
            DropTable("dbo.OtherServices");
            DropTable("dbo.MaterialBillDetails");
            DropTable("dbo.MaterialBills");
        }
    }
}
