namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("tpt.MaterialDoctorAdvice", "ReCheckName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("tpt.MaterialDoctorAdvice", "ReCheckName");
        }
    }
}
