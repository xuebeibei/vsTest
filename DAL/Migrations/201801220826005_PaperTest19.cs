namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("tpt.MedicineDoctorAdviceDetail", "MedicineDoctorAdviceID", c => c.Int(nullable: false));
            CreateIndex("tpt.MedicineDoctorAdviceDetail", "MedicineDoctorAdviceID");
            AddForeignKey("tpt.MedicineDoctorAdviceDetail", "MedicineDoctorAdviceID", "tpt.MedicineDoctorAdvice", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("tpt.MedicineDoctorAdviceDetail", "MedicineDoctorAdviceID", "tpt.MedicineDoctorAdvice");
            DropIndex("tpt.MedicineDoctorAdviceDetail", new[] { "MedicineDoctorAdviceID" });
            DropColumn("tpt.MedicineDoctorAdviceDetail", "MedicineDoctorAdviceID");
        }
    }
}
