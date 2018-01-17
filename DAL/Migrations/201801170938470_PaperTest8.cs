namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssayItems", "SpecimenID", "dbo.Specimen");
            DropIndex("dbo.AssayItems", new[] { "SpecimenID" });
            AddColumn("dbo.AssayItems", "YiBaoEnum", c => c.Int(nullable: false));
            DropColumn("dbo.AssayItems", "SpecimenID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssayItems", "SpecimenID", c => c.Int(nullable: false));
            DropColumn("dbo.AssayItems", "YiBaoEnum");
            CreateIndex("dbo.AssayItems", "SpecimenID");
            AddForeignKey("dbo.AssayItems", "SpecimenID", "dbo.Specimen", "ID", cascadeDelete: true);
        }
    }
}
