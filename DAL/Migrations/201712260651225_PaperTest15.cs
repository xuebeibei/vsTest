namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssayItems", "Unit", c => c.String());
            AddColumn("dbo.InspectItems", "Unit", c => c.String());
            AddColumn("dbo.TherapyItems", "Unit", c => c.String());
            AddColumn("dbo.MaterialItems", "Unit", c => c.String());
            AddColumn("dbo.MaterialItems", "Specifications", c => c.String());
            AddColumn("dbo.MaterialItems", "Manufacturer", c => c.String());
            AddColumn("dbo.MaterialItems", "Valuable", c => c.Boolean(nullable: false));
            AddColumn("dbo.MaterialItems", "YiBaoEnum", c => c.Int(nullable: false));
            AddColumn("dbo.MaterialItems", "MaxNum", c => c.Int(nullable: false));
            AddColumn("dbo.MaterialItems", "MinNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MaterialItems", "MinNum");
            DropColumn("dbo.MaterialItems", "MaxNum");
            DropColumn("dbo.MaterialItems", "YiBaoEnum");
            DropColumn("dbo.MaterialItems", "Valuable");
            DropColumn("dbo.MaterialItems", "Manufacturer");
            DropColumn("dbo.MaterialItems", "Specifications");
            DropColumn("dbo.MaterialItems", "Unit");
            DropColumn("dbo.TherapyItems", "Unit");
            DropColumn("dbo.InspectItems", "Unit");
            DropColumn("dbo.AssayItems", "Unit");
        }
    }
}
