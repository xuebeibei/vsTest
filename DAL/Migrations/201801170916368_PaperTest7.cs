namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TherapyItems", "YiBaoEnum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TherapyItems", "YiBaoEnum");
        }
    }
}
