namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SignalSources", "VistTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.SignalSources", "TimeIntival", c => c.String());
            AddColumn("dbo.SignalSources", "DepartmentID", c => c.Int(nullable: false));
            AddColumn("dbo.SignalSources", "SignalType", c => c.String());
            AddColumn("dbo.SignalSources", "MaxNum", c => c.Int(nullable: false));
            AddColumn("dbo.SignalSources", "AddMaxNum", c => c.Int(nullable: false));
            AddColumn("dbo.SignalSources", "HasUsedNum", c => c.Int(nullable: false));
            AddColumn("dbo.SignalSources", "Specialist", c => c.String());
            AddColumn("dbo.SignalSources", "Explain", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SignalSources", "Explain");
            DropColumn("dbo.SignalSources", "Specialist");
            DropColumn("dbo.SignalSources", "HasUsedNum");
            DropColumn("dbo.SignalSources", "AddMaxNum");
            DropColumn("dbo.SignalSources", "MaxNum");
            DropColumn("dbo.SignalSources", "SignalType");
            DropColumn("dbo.SignalSources", "DepartmentID");
            DropColumn("dbo.SignalSources", "TimeIntival");
            DropColumn("dbo.SignalSources", "VistTime");
        }
    }
}
