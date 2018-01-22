namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest21 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("tpt.MedicineDoctorAdviceDetail", "MedicineID");
            AddForeignKey("tpt.MedicineDoctorAdviceDetail", "MedicineID", "dbo.Medicines", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("tpt.MedicineDoctorAdviceDetail", "MedicineID", "dbo.Medicines");
            DropIndex("tpt.MedicineDoctorAdviceDetail", new[] { "MedicineID" });
        }
    }
}
