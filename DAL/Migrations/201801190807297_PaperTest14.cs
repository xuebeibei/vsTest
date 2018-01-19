namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest14 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Inpatients", "LeaveIllnesSstateEnum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inpatients", "LeaveIllnesSstateEnum", c => c.Int(nullable: false));
        }
    }
}
