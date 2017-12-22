namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecipeDetails", "Usage", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipeDetails", "DDDS", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecipeDetails", "DDDS", c => c.String());
            AlterColumn("dbo.RecipeDetails", "Usage", c => c.String());
        }
    }
}
