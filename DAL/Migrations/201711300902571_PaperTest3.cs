namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "SeeDoctorStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Registrations", "TriageStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Registrations", "EmployeeID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "EmployeeID");
            DropColumn("dbo.Registrations", "TriageStatus");
            DropColumn("dbo.Registrations", "SeeDoctorStatus");
        }
    }
}
