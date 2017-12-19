namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DosageForms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DosageFormEnum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Medicines", "DosageFormID", c => c.Int(nullable: false));
            CreateIndex("dbo.Medicines", "DosageFormID");
            AddForeignKey("dbo.Medicines", "DosageFormID", "dbo.DosageForms", "ID", cascadeDelete: true);
            DropColumn("dbo.Medicines", "DosageForm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicines", "DosageForm", c => c.String());
            DropForeignKey("dbo.Medicines", "DosageFormID", "dbo.DosageForms");
            DropIndex("dbo.Medicines", new[] { "DosageFormID" });
            DropColumn("dbo.Medicines", "DosageFormID");
            DropTable("dbo.DosageForms");
        }
    }
}
