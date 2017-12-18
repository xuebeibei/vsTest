namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobEnum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "JobEnum");
        }
    }
}
