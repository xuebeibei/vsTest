namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "PatientID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "PatientID");
        }
    }
}
