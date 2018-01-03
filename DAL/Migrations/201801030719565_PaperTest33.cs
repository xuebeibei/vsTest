namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicineInStoreDetails", "MedicineID", c => c.Int(nullable: false));
            AddColumn("dbo.MedicineInStoreDetails", "Batch", c => c.String());
            AddColumn("dbo.MedicineInStoreDetails", "ExpirationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.MedicineInStoreDetails", "MedicineBatchID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicineInStoreDetails", "MedicineBatchID", c => c.Int(nullable: false));
            DropColumn("dbo.MedicineInStoreDetails", "ExpirationDate");
            DropColumn("dbo.MedicineInStoreDetails", "Batch");
            DropColumn("dbo.MedicineInStoreDetails", "MedicineID");
        }
    }
}
