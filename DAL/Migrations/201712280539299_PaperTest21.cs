namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest21 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Inpatients", "PatientID");
            AddForeignKey("dbo.Inpatients", "PatientID", "dbo.Patients", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inpatients", "PatientID", "dbo.Patients");
            DropIndex("dbo.Inpatients", new[] { "PatientID" });
        }
    }
}
