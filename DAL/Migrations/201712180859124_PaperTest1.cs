namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MedicineAlias", "MedicineID");
            CreateIndex("dbo.MedicinePackings", "MedicineID");
            AddForeignKey("dbo.MedicineAlias", "MedicineID", "dbo.Medicines", "ID", cascadeDelete: true);
            AddForeignKey("dbo.MedicinePackings", "MedicineID", "dbo.Medicines", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicinePackings", "MedicineID", "dbo.Medicines");
            DropForeignKey("dbo.MedicineAlias", "MedicineID", "dbo.Medicines");
            DropIndex("dbo.MedicinePackings", new[] { "MedicineID" });
            DropIndex("dbo.MedicineAlias", new[] { "MedicineID" });
        }
    }
}
