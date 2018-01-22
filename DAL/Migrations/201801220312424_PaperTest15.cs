namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrePays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        No = c.String(),
                        PrePayTime = c.DateTime(),
                        PrePayMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayerName = c.String(),
                        PayWayEnum = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.PatientID)
                .Index(t => t.UserID);
            
            AddColumn("dbo.Inpatients", "BaoXianEnum", c => c.Int(nullable: false));
            DropColumn("dbo.Inpatients", "PayTypeEnum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inpatients", "PayTypeEnum", c => c.Int(nullable: false));
            DropForeignKey("dbo.PrePays", "UserID", "dbo.Users");
            DropForeignKey("dbo.PrePays", "PatientID", "dbo.Patients");
            DropIndex("dbo.PrePays", new[] { "UserID" });
            DropIndex("dbo.PrePays", new[] { "PatientID" });
            DropColumn("dbo.Inpatients", "BaoXianEnum");
            DropTable("dbo.PrePays");
        }
    }
}
