namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inpatients", "CaseNo", c => c.String());
            AddColumn("dbo.Inpatients", "InHospitalDoctorName", c => c.String());
            AddColumn("dbo.Inpatients", "InHospitalDepartment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inpatients", "InHospitalDepartment");
            DropColumn("dbo.Inpatients", "InHospitalDoctorName");
            DropColumn("dbo.Inpatients", "CaseNo");
        }
    }
}
