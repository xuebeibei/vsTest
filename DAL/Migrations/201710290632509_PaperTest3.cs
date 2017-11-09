namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SignalSources", "SignalType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SignalSources", "SignalType", c => c.String());
        }
    }
}
