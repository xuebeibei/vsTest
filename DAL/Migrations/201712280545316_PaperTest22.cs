namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest22 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Inpatients", "DoctorID");
            DropColumn("dbo.Inpatients", "DepertmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inpatients", "DepertmentID", c => c.Int(nullable: false));
            AddColumn("dbo.Inpatients", "DoctorID", c => c.Int(nullable: false));
        }
    }
}
