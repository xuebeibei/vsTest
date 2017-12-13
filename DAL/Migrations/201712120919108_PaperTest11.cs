namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupNum = c.String(),
                        DrugID = c.Int(nullable: false),
                        SingleDose = c.Int(nullable: false),
                        Usage = c.String(),
                        DDDS = c.String(),
                        DaysNum = c.Int(nullable: false),
                        IntegralDose = c.Int(nullable: false),
                        Illustration = c.String(),
                        RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        No = c.String(),
                        RecipeTypeEnum = c.Int(nullable: false),
                        MedicalInstitution = c.String(),
                        ChargeTypeEnum = c.Int(nullable: false),
                        RegistrationID = c.Int(nullable: false),
                        InpatientID = c.Int(nullable: false),
                        ClinicalDiagnosis = c.String(),
                        PatientsIDCardNum = c.String(),
                        ProxyIDCardNum = c.String(),
                        ProxyName = c.String(),
                        SumOfMoney = c.Double(nullable: false),
                        WriteTime = c.DateTime(nullable: false),
                        WriteUserID = c.Int(nullable: false),
                        AuditorUserID = c.Int(nullable: false),
                        AuditorTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Recipes");
            DropTable("dbo.RecipeDetails");
        }
    }
}
