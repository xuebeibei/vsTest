namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterialItems", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            DropColumn("dbo.MaterialItems", "StockPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaterialItems", "StockPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            DropColumn("dbo.MaterialItems", "SellPrice");
        }
    }
}
