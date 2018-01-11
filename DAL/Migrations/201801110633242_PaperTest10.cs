namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecipeChargeDetails", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecipeChargeDetails", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}