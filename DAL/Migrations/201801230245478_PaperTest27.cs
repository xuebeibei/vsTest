namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest27 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("tpt.MaterialDoctorAdviceDetail", "MaterialDoctorAdviceID");
            AddForeignKey("tpt.MaterialDoctorAdviceDetail", "MaterialDoctorAdviceID", "tpt.MaterialDoctorAdvice", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("tpt.MaterialDoctorAdviceDetail", "MaterialDoctorAdviceID", "tpt.MaterialDoctorAdvice");
            DropIndex("tpt.MaterialDoctorAdviceDetail", new[] { "MaterialDoctorAdviceID" });
        }
    }
}
