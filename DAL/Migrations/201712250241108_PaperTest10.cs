namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        MedicalRecordEnum = c.Int(nullable: false),
                        RegistrationID = c.Int(nullable: false),
                        InpatientID = c.Int(nullable: false),
                        WriteTime = c.DateTime(nullable: false),
                        WriteUserID = c.Int(nullable: false),
                        ContentXml = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inpatients", t => t.InpatientID, cascadeDelete: true)
                .ForeignKey("dbo.Registrations", t => t.RegistrationID, cascadeDelete: true)
                .Index(t => t.RegistrationID)
                .Index(t => t.InpatientID);
            
            CreateTable(
                "dbo.Inpatients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        No = c.String(),
                        PatientID = c.Int(nullable: false),
                        InHospitalTime = c.DateTime(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        DepertmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalRecords", "RegistrationID", "dbo.Registrations");
            DropForeignKey("dbo.MedicalRecords", "InpatientID", "dbo.Inpatients");
            DropIndex("dbo.MedicalRecords", new[] { "InpatientID" });
            DropIndex("dbo.MedicalRecords", new[] { "RegistrationID" });
            DropTable("dbo.Inpatients");
            DropTable("dbo.MedicalRecords");
        }
    }
}
