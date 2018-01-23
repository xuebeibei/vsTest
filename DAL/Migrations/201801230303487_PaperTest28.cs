namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest28 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("tpt.MaterialDoctorAdvice", "ID", "tpt.DoctorAdviceBase");
            DropForeignKey("tpt.MaterialDoctorAdviceDetail", "ID", "tpt.DoctorAdviceDetailBase");
            DropForeignKey("tpt.MaterialDoctorAdviceDetail", "MaterialID", "dbo.MaterialItems");
            DropForeignKey("tpt.MaterialDoctorAdviceDetail", "MaterialDoctorAdviceID", "tpt.MaterialDoctorAdvice");
            DropIndex("tpt.MaterialDoctorAdvice", new[] { "ID" });
            DropIndex("tpt.MaterialDoctorAdviceDetail", new[] { "ID" });
            DropIndex("tpt.MaterialDoctorAdviceDetail", new[] { "MaterialID" });
            DropIndex("tpt.MaterialDoctorAdviceDetail", new[] { "MaterialDoctorAdviceID" });
            DropTable("tpt.MaterialDoctorAdvice");
            DropTable("tpt.MaterialDoctorAdviceDetail");
        }
        
        public override void Down()
        {
            CreateTable(
                "tpt.MaterialDoctorAdviceDetail",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        MaterialDoctorAdviceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "tpt.MaterialDoctorAdvice",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ReCheckName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("tpt.MaterialDoctorAdviceDetail", "MaterialDoctorAdviceID");
            CreateIndex("tpt.MaterialDoctorAdviceDetail", "MaterialID");
            CreateIndex("tpt.MaterialDoctorAdviceDetail", "ID");
            CreateIndex("tpt.MaterialDoctorAdvice", "ID");
            AddForeignKey("tpt.MaterialDoctorAdviceDetail", "MaterialDoctorAdviceID", "tpt.MaterialDoctorAdvice", "ID");
            AddForeignKey("tpt.MaterialDoctorAdviceDetail", "MaterialID", "dbo.MaterialItems", "ID", cascadeDelete: true);
            AddForeignKey("tpt.MaterialDoctorAdviceDetail", "ID", "tpt.DoctorAdviceDetailBase", "ID");
            AddForeignKey("tpt.MaterialDoctorAdvice", "ID", "tpt.DoctorAdviceBase", "ID");
        }
    }
}
