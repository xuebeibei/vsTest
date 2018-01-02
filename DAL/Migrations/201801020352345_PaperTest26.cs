namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest26 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medicines", "DosageFormID", "dbo.DosageForms");
            DropForeignKey("dbo.MedicineAlias", "MedicineID", "dbo.Medicines");
            DropForeignKey("dbo.MedicinePackings", "MedicineID", "dbo.Medicines");
            DropIndex("dbo.Medicines", new[] { "DosageFormID" });
            DropIndex("dbo.MedicineAlias", new[] { "MedicineID" });
            DropIndex("dbo.MedicinePackings", new[] { "MedicineID" });
            AddColumn("dbo.Medicines", "Abbr1", c => c.String());
            AddColumn("dbo.Medicines", "Abbr2", c => c.String());
            AddColumn("dbo.Medicines", "Abbr3", c => c.String());
            AddColumn("dbo.Medicines", "DosageFormEnum", c => c.Int(nullable: false));
            AddColumn("dbo.Medicines", "Unit", c => c.String());
            DropColumn("dbo.Medicines", "DosageFormID");
            DropTable("dbo.DosageForms");
            DropTable("dbo.MedicineAlias");
            DropTable("dbo.MedicinePackings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MedicinePackings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BigUnit = c.String(),
                        Num = c.Int(nullable: false),
                        SmallID = c.Int(nullable: false),
                        MedicineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicineAlias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Alias = c.String(),
                        MedicineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
            DropColumn("dbo.Medicines", "Unit");
            DropColumn("dbo.Medicines", "DosageFormEnum");
            DropColumn("dbo.Medicines", "Abbr3");
            DropColumn("dbo.Medicines", "Abbr2");
            DropColumn("dbo.Medicines", "Abbr1");
            CreateIndex("dbo.MedicinePackings", "MedicineID");
            CreateIndex("dbo.MedicineAlias", "MedicineID");
            CreateIndex("dbo.Medicines", "DosageFormID");
            AddForeignKey("dbo.MedicinePackings", "MedicineID", "dbo.Medicines", "ID", cascadeDelete: true);
            AddForeignKey("dbo.MedicineAlias", "MedicineID", "dbo.Medicines", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Medicines", "DosageFormID", "dbo.DosageForms", "ID", cascadeDelete: true);
        }
    }
}
