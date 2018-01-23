namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest35 : DbMigration
    {
        public override void Up()
        {
            DropColumn("tpt.AssayDoctorAdvice", "ReCheckName");
            DropColumn("tpt.MaterialDoctorAdvice", "ReCheckName");
        }
        
        public override void Down()
        {
            AddColumn("tpt.MaterialDoctorAdvice", "ReCheckName", c => c.String());
            AddColumn("tpt.AssayDoctorAdvice", "ReCheckName", c => c.String());
        }
    }
}
