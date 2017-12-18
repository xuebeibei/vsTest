namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Registrations", "Patient_ID", "dbo.Patients");
            DropIndex("dbo.Registrations", new[] { "Patient_ID" });
            RenameColumn(table: "dbo.Registrations", name: "Patient_ID", newName: "PatientID");
            AlterColumn("dbo.Registrations", "PatientID", c => c.Int(nullable: false));
            CreateIndex("dbo.Registrations", "PatientID");
            AddForeignKey("dbo.Registrations", "PatientID", "dbo.Patients", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "PatientID", "dbo.Patients");
            DropIndex("dbo.Registrations", new[] { "PatientID" });
            AlterColumn("dbo.Registrations", "PatientID", c => c.Int());
            RenameColumn(table: "dbo.Registrations", name: "PatientID", newName: "Patient_ID");
            CreateIndex("dbo.Registrations", "Patient_ID");
            AddForeignKey("dbo.Registrations", "Patient_ID", "dbo.Patients", "ID");
        }
    }
}
