namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest29 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MedicineInStoreDetails", "MedicineBatchID");
            AddForeignKey("dbo.MedicineInStoreDetails", "MedicineBatchID", "dbo.MedicineBatches", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineInStoreDetails", "MedicineBatchID", "dbo.MedicineBatches");
            DropIndex("dbo.MedicineInStoreDetails", new[] { "MedicineBatchID" });
        }
    }
}
