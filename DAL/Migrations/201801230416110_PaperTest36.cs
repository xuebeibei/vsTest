namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest36 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "tpt.InspectDoctorAdvice",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("tpt.DoctorAdviceBase", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "tpt.InspectDoctorAdviceDetail",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        InspectID = c.Int(nullable: false),
                        InspectDoctorAdviceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("tpt.DoctorAdviceDetailBase", t => t.ID)
                .ForeignKey("dbo.InspectItems", t => t.InspectID, cascadeDelete: true)
                .ForeignKey("tpt.InspectDoctorAdvice", t => t.InspectDoctorAdviceID)
                .Index(t => t.ID)
                .Index(t => t.InspectID)
                .Index(t => t.InspectDoctorAdviceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("tpt.InspectDoctorAdviceDetail", "InspectDoctorAdviceID", "tpt.InspectDoctorAdvice");
            DropForeignKey("tpt.InspectDoctorAdviceDetail", "InspectID", "dbo.InspectItems");
            DropForeignKey("tpt.InspectDoctorAdviceDetail", "ID", "tpt.DoctorAdviceDetailBase");
            DropForeignKey("tpt.InspectDoctorAdvice", "ID", "tpt.DoctorAdviceBase");
            DropIndex("tpt.InspectDoctorAdviceDetail", new[] { "InspectDoctorAdviceID" });
            DropIndex("tpt.InspectDoctorAdviceDetail", new[] { "InspectID" });
            DropIndex("tpt.InspectDoctorAdviceDetail", new[] { "ID" });
            DropIndex("tpt.InspectDoctorAdvice", new[] { "ID" });
            DropTable("tpt.InspectDoctorAdviceDetail");
            DropTable("tpt.InspectDoctorAdvice");
        }
    }
}
