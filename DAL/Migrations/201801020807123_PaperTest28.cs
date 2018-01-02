namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest28 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicineCheckStoreDetails", "MedicineCheckStoreID", c => c.Int(nullable: false));
            AddColumn("dbo.MedicineInStoreDetails", "MedicineInStoreID", c => c.Int(nullable: false));
            AddColumn("dbo.MedicineOutStoreDetails", "MedicineOutStoreID", c => c.Int(nullable: false));
            CreateIndex("dbo.MedicineCheckStoreDetails", "MedicineCheckStoreID");
            CreateIndex("dbo.MedicineInStoreDetails", "MedicineInStoreID");
            CreateIndex("dbo.MedicineOutStoreDetails", "MedicineOutStoreID");
            AddForeignKey("dbo.MedicineCheckStoreDetails", "MedicineCheckStoreID", "dbo.MedicineCheckStores", "ID", cascadeDelete: true);
            AddForeignKey("dbo.MedicineInStoreDetails", "MedicineInStoreID", "dbo.MedicineInStores", "ID", cascadeDelete: true);
            AddForeignKey("dbo.MedicineOutStoreDetails", "MedicineOutStoreID", "dbo.MedicineOutStores", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineOutStoreDetails", "MedicineOutStoreID", "dbo.MedicineOutStores");
            DropForeignKey("dbo.MedicineInStoreDetails", "MedicineInStoreID", "dbo.MedicineInStores");
            DropForeignKey("dbo.MedicineCheckStoreDetails", "MedicineCheckStoreID", "dbo.MedicineCheckStores");
            DropIndex("dbo.MedicineOutStoreDetails", new[] { "MedicineOutStoreID" });
            DropIndex("dbo.MedicineInStoreDetails", new[] { "MedicineInStoreID" });
            DropIndex("dbo.MedicineCheckStoreDetails", new[] { "MedicineCheckStoreID" });
            DropColumn("dbo.MedicineOutStoreDetails", "MedicineOutStoreID");
            DropColumn("dbo.MedicineInStoreDetails", "MedicineInStoreID");
            DropColumn("dbo.MedicineCheckStoreDetails", "MedicineCheckStoreID");
        }
    }
}
