namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest38 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "tpt.TherapyDoctorAdvice",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("tpt.DoctorAdviceBase", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "tpt.TherapyDoctorAdviceDetail",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        TherapyID = c.Int(nullable: false),
                        TherapyDoctorAdviceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("tpt.DoctorAdviceDetailBase", t => t.ID)
                .ForeignKey("dbo.TherapyItems", t => t.TherapyID, cascadeDelete: true)
                .ForeignKey("tpt.TherapyDoctorAdvice", t => t.TherapyDoctorAdviceID)
                .Index(t => t.ID)
                .Index(t => t.TherapyID)
                .Index(t => t.TherapyDoctorAdviceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("tpt.TherapyDoctorAdviceDetail", "TherapyDoctorAdviceID", "tpt.TherapyDoctorAdvice");
            DropForeignKey("tpt.TherapyDoctorAdviceDetail", "TherapyID", "dbo.TherapyItems");
            DropForeignKey("tpt.TherapyDoctorAdviceDetail", "ID", "tpt.DoctorAdviceDetailBase");
            DropForeignKey("tpt.TherapyDoctorAdvice", "ID", "tpt.DoctorAdviceBase");
            DropIndex("tpt.TherapyDoctorAdviceDetail", new[] { "TherapyDoctorAdviceID" });
            DropIndex("tpt.TherapyDoctorAdviceDetail", new[] { "TherapyID" });
            DropIndex("tpt.TherapyDoctorAdviceDetail", new[] { "ID" });
            DropIndex("tpt.TherapyDoctorAdvice", new[] { "ID" });
            DropTable("tpt.TherapyDoctorAdviceDetail");
            DropTable("tpt.TherapyDoctorAdvice");
        }
    }
}
