namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "ChargeStatusEnum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "ChargeStatusEnum");
        }
    }
}
