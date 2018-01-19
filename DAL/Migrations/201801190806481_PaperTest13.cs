namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inpatients", "LeaveHospitalTime", c => c.DateTime());
            AddColumn("dbo.Inpatients", "LeaveHospitalDiagnoses", c => c.String());
            AddColumn("dbo.Inpatients", "LeaveIllnesSstateEnum", c => c.Int(nullable: false));
            AddColumn("dbo.Inpatients", "LeaveHospitalDoctorName", c => c.String());
            AddColumn("dbo.Inpatients", "LeaveHospitalDepartment", c => c.String());
            AddColumn("dbo.Inpatients", "LeaveHospitalUserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inpatients", "LeaveHospitalUserID");
            DropColumn("dbo.Inpatients", "LeaveHospitalDepartment");
            DropColumn("dbo.Inpatients", "LeaveHospitalDoctorName");
            DropColumn("dbo.Inpatients", "LeaveIllnesSstateEnum");
            DropColumn("dbo.Inpatients", "LeaveHospitalDiagnoses");
            DropColumn("dbo.Inpatients", "LeaveHospitalTime");
        }
    }
}
