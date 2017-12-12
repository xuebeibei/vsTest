namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest10 : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Medicines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MedicineTypeEnum = c.Int(nullable: false),
                        Name = c.String(),
                        DosageForm = c.String(),
                        AdministrationRoute = c.String(),
                        Specifications = c.String(),
                        Manufacturer = c.String(),
                        PoisonousHemp = c.Boolean(nullable: false),
                        Valuable = c.Boolean(nullable: false),
                        EssentialDrugs = c.Boolean(nullable: false),
                        YiBaoEnum = c.Int(nullable: false),
                        MaxNum = c.Int(nullable: false),
                        MinNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medicines");
            DropTable("dbo.MedicinePackings");
            DropTable("dbo.MedicineAlias");
        }
    }
}
