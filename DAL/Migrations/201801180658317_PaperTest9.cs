namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inpatients", "PayTypeEnum", c => c.Int(nullable: false));
            AddColumn("dbo.Inpatients", "YiBaoNo", c => c.String());
            AddColumn("dbo.Inpatients", "MarriageEnum", c => c.Int(nullable: false));
            AddColumn("dbo.Inpatients", "Job", c => c.String());
            AddColumn("dbo.Inpatients", "WorkAddress", c => c.String());
            AddColumn("dbo.Inpatients", "ContactsName", c => c.String());
            AddColumn("dbo.Inpatients", "ContactsTel", c => c.String());
            AddColumn("dbo.Inpatients", "ContactsAddress", c => c.String());
            AddColumn("dbo.Inpatients", "InHospitalDiagnoses", c => c.String());
            AddColumn("dbo.Inpatients", "IllnesSstateEnum", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "IDCardNo", c => c.String());
            AddColumn("dbo.Patients", "Tel", c => c.String());
            AddColumn("dbo.Patients", "JiGuan", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "JiGuan");
            DropColumn("dbo.Patients", "Tel");
            DropColumn("dbo.Patients", "IDCardNo");
            DropColumn("dbo.Inpatients", "IllnesSstateEnum");
            DropColumn("dbo.Inpatients", "InHospitalDiagnoses");
            DropColumn("dbo.Inpatients", "ContactsAddress");
            DropColumn("dbo.Inpatients", "ContactsTel");
            DropColumn("dbo.Inpatients", "ContactsName");
            DropColumn("dbo.Inpatients", "WorkAddress");
            DropColumn("dbo.Inpatients", "Job");
            DropColumn("dbo.Inpatients", "MarriageEnum");
            DropColumn("dbo.Inpatients", "YiBaoNo");
            DropColumn("dbo.Inpatients", "PayTypeEnum");
        }
    }
}
