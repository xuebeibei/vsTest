namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest40 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OtherServiceDetails", "OtherServiceID", "dbo.OtherServices");
            DropForeignKey("dbo.OtherServiceDetails", "OtherServiceItemID", "dbo.OtherServiceItems");
            DropForeignKey("dbo.OtherServices", "WriteUserID", "dbo.Users");
            DropIndex("dbo.OtherServices", new[] { "WriteUserID" });
            DropIndex("dbo.OtherServiceDetails", new[] { "OtherServiceItemID" });
            DropIndex("dbo.OtherServiceDetails", new[] { "OtherServiceID" });
            CreateTable(
                "tpt.OtherServiceDoctorAdvice",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("tpt.DoctorAdviceBase", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "tpt.OtherServiceDoctorAdviceDetail",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        OtherServiceID = c.Int(nullable: false),
                        OtherServiceDoctorAdviceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("tpt.DoctorAdviceDetailBase", t => t.ID)
                .ForeignKey("dbo.OtherServiceItems", t => t.OtherServiceID, cascadeDelete: true)
                .ForeignKey("tpt.OtherServiceDoctorAdvice", t => t.OtherServiceDoctorAdviceID)
                .Index(t => t.ID)
                .Index(t => t.OtherServiceID)
                .Index(t => t.OtherServiceDoctorAdviceID);
            
            DropTable("dbo.OtherServices");
            DropTable("dbo.OtherServiceDetails");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OtherServices",
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
            
            DropForeignKey("tpt.OtherServiceDoctorAdviceDetail", "OtherServiceDoctorAdviceID", "tpt.OtherServiceDoctorAdvice");
            DropForeignKey("tpt.OtherServiceDoctorAdviceDetail", "OtherServiceID", "dbo.OtherServiceItems");
            DropForeignKey("tpt.OtherServiceDoctorAdviceDetail", "ID", "tpt.DoctorAdviceDetailBase");
            DropForeignKey("tpt.OtherServiceDoctorAdvice", "ID", "tpt.DoctorAdviceBase");
            DropIndex("tpt.OtherServiceDoctorAdviceDetail", new[] { "OtherServiceDoctorAdviceID" });
            DropIndex("tpt.OtherServiceDoctorAdviceDetail", new[] { "OtherServiceID" });
            DropIndex("tpt.OtherServiceDoctorAdviceDetail", new[] { "ID" });
            DropIndex("tpt.OtherServiceDoctorAdvice", new[] { "ID" });
            DropTable("tpt.OtherServiceDoctorAdviceDetail");
            DropTable("tpt.OtherServiceDoctorAdvice");
            CreateIndex("dbo.OtherServiceDetails", "OtherServiceID");
            CreateIndex("dbo.OtherServiceDetails", "OtherServiceItemID");
            CreateIndex("dbo.OtherServices", "WriteUserID");
            AddForeignKey("dbo.OtherServices", "WriteUserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OtherServiceDetails", "OtherServiceItemID", "dbo.OtherServiceItems", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OtherServiceDetails", "OtherServiceID", "dbo.OtherServices", "ID", cascadeDelete: true);
        }
    }
}
