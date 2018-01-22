namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest20 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("tpt.DoctorAdviceBase", "WriteDoctorUserID");
            CreateIndex("tpt.DoctorAdviceBase", "PatientID");
            AddForeignKey("tpt.DoctorAdviceBase", "PatientID", "dbo.Patients", "ID", cascadeDelete: true);
            AddForeignKey("tpt.DoctorAdviceBase", "WriteDoctorUserID", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("tpt.DoctorAdviceBase", "WriteDoctorUserID", "dbo.Users");
            DropForeignKey("tpt.DoctorAdviceBase", "PatientID", "dbo.Patients");
            DropIndex("tpt.DoctorAdviceBase", new[] { "PatientID" });
            DropIndex("tpt.DoctorAdviceBase", new[] { "WriteDoctorUserID" });
        }
    }
}
