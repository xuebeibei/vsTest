namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicineCheckStores", "ReCheckStatusEnum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicineCheckStores", "ReCheckStatusEnum");
        }
    }
}
