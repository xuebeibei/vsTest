namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest36 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MedicineInStoreDetails", "MedicineID");
            AddForeignKey("dbo.MedicineInStoreDetails", "MedicineID", "dbo.Medicines", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineInStoreDetails", "MedicineID", "dbo.Medicines");
            DropIndex("dbo.MedicineInStoreDetails", new[] { "MedicineID" });
        }
    }
}
