namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest29 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "tpt.MaterialDoctorAdvice",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ReCheckName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("tpt.DoctorAdviceBase", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "tpt.MaterialDoctorAdviceDetail",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        MaterialDoctorAdviceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("tpt.DoctorAdviceDetailBase", t => t.ID)
                .ForeignKey("dbo.MaterialItems", t => t.MaterialID, cascadeDelete: true)
                .ForeignKey("tpt.MaterialDoctorAdvice", t => t.MaterialDoctorAdviceID)
                .Index(t => t.ID)
                .Index(t => t.MaterialID)
                .Index(t => t.MaterialDoctorAdviceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("tpt.MaterialDoctorAdviceDetail", "MaterialDoctorAdviceID", "tpt.MaterialDoctorAdvice");
            DropForeignKey("tpt.MaterialDoctorAdviceDetail", "MaterialID", "dbo.MaterialItems");
            DropForeignKey("tpt.MaterialDoctorAdviceDetail", "ID", "tpt.DoctorAdviceDetailBase");
            DropForeignKey("tpt.MaterialDoctorAdvice", "ID", "tpt.DoctorAdviceBase");
            DropIndex("tpt.MaterialDoctorAdviceDetail", new[] { "MaterialDoctorAdviceID" });
            DropIndex("tpt.MaterialDoctorAdviceDetail", new[] { "MaterialID" });
            DropIndex("tpt.MaterialDoctorAdviceDetail", new[] { "ID" });
            DropIndex("tpt.MaterialDoctorAdvice", new[] { "ID" });
            DropTable("tpt.MaterialDoctorAdviceDetail");
            DropTable("tpt.MaterialDoctorAdvice");
        }
    }
}
