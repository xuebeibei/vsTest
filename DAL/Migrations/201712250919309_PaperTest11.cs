namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicalRecords", "InpatientID", "dbo.Inpatients");
            DropIndex("dbo.MedicalRecords", new[] { "InpatientID" });
            DropColumn("dbo.MedicalRecords", "InpatientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicalRecords", "InpatientID", c => c.Int(nullable: false));
            CreateIndex("dbo.MedicalRecords", "InpatientID");
            AddForeignKey("dbo.MedicalRecords", "InpatientID", "dbo.Inpatients", "ID", cascadeDelete: true);
        }
    }
}
