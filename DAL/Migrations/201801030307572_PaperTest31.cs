namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest31 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MedicineInStores", "FromSupplierID");
            AddForeignKey("dbo.MedicineInStores", "FromSupplierID", "dbo.Suppliers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineInStores", "FromSupplierID", "dbo.Suppliers");
            DropIndex("dbo.MedicineInStores", new[] { "FromSupplierID" });
        }
    }
}
