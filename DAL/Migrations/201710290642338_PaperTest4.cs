namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SignalSources", "TimeIntival", c => c.Int(nullable: false));
            AlterColumn("dbo.SignalSources", "Specialist", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SignalSources", "Specialist", c => c.String());
            AlterColumn("dbo.SignalSources", "TimeIntival", c => c.String());
        }
    }
}
