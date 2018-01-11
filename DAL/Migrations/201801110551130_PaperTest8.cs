namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeChargeBills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        SumOfMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChargeTime = c.DateTime(nullable: false),
                        RecipeID = c.Int(nullable: false),
                        Block = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RecipeChargeDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoreRoomMedicineNumID = c.Int(nullable: false),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Num = c.Int(nullable: false),
                        Rebate = c.Int(nullable: false),
                        ChargeRecipeBill_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RecipeChargeBills", t => t.ChargeRecipeBill_ID)
                .Index(t => t.ChargeRecipeBill_ID);
            
            AlterColumn("dbo.Assays", "SumOfMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Registrations", "RegisterFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Inspects", "SumOfMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MaterialBills", "SumOfMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Recipes", "SumOfMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OtherServices", "SumOfMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Therapies", "SumOfMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeChargeDetails", "ChargeRecipeBill_ID", "dbo.RecipeChargeBills");
            DropIndex("dbo.RecipeChargeDetails", new[] { "ChargeRecipeBill_ID" });
            AlterColumn("dbo.Therapies", "SumOfMoney", c => c.Double(nullable: false));
            AlterColumn("dbo.OtherServices", "SumOfMoney", c => c.Double(nullable: false));
            AlterColumn("dbo.Recipes", "SumOfMoney", c => c.Double(nullable: false));
            AlterColumn("dbo.MaterialBills", "SumOfMoney", c => c.Double(nullable: false));
            AlterColumn("dbo.Inspects", "SumOfMoney", c => c.Double(nullable: false));
            AlterColumn("dbo.Registrations", "RegisterFee", c => c.Double(nullable: false));
            AlterColumn("dbo.Assays", "SumOfMoney", c => c.Double(nullable: false));
            DropTable("dbo.RecipeChargeDetails");
            DropTable("dbo.RecipeChargeBills");
        }
    }
}
