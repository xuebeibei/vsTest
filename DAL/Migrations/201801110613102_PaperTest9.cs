namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest9 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RecipeChargeDetails", name: "ChargeRecipeBill_ID", newName: "RecipeChargeBill_ID");
            RenameIndex(table: "dbo.RecipeChargeDetails", name: "IX_ChargeRecipeBill_ID", newName: "IX_RecipeChargeBill_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RecipeChargeDetails", name: "IX_RecipeChargeBill_ID", newName: "IX_ChargeRecipeBill_ID");
            RenameColumn(table: "dbo.RecipeChargeDetails", name: "RecipeChargeBill_ID", newName: "ChargeRecipeBill_ID");
        }
    }
}
