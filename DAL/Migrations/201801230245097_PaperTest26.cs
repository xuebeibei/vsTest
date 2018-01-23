namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest26 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("tpt.MaterialDoctorAdviceDetail", "MaterialDoctorAdviceID", "tpt.MaterialDoctorAdvice");
            DropIndex("tpt.MaterialDoctorAdviceDetail", new[] { "MaterialDoctorAdviceID" });
        }
        
        public override void Down()
        {
            CreateIndex("tpt.MaterialDoctorAdviceDetail", "MaterialDoctorAdviceID");
            AddForeignKey("tpt.MaterialDoctorAdviceDetail", "MaterialDoctorAdviceID", "tpt.MaterialDoctorAdvice", "ID");
        }
    }
}
