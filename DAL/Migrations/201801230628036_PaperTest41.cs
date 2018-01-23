namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest41 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeDetails", "MedicineID", "dbo.Medicines");
            DropForeignKey("dbo.RecipeChargeBills", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.RecipeDetails", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "WriteUserID", "dbo.Users");
            DropIndex("dbo.RecipeDetails", new[] { "MedicineID" });
            DropIndex("dbo.RecipeDetails", new[] { "RecipeID" });
            DropIndex("dbo.Recipes", new[] { "WriteUserID" });
            DropIndex("dbo.RecipeChargeBills", new[] { "RecipeID" });
            AddColumn("dbo.RecipeChargeBills", "MedicineDoctorAdviceID", c => c.Int(nullable: false));
            CreateIndex("dbo.RecipeChargeBills", "MedicineDoctorAdviceID");
            AddForeignKey("dbo.RecipeChargeBills", "MedicineDoctorAdviceID", "tpt.MedicineDoctorAdvice", "ID");
            DropColumn("dbo.RecipeChargeBills", "RecipeID");
            DropTable("dbo.RecipeDetails");
            DropTable("dbo.Recipes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        No = c.String(),
                        RecipeTypeEnum = c.Int(nullable: false),
                        RecipeContentEnum = c.Int(nullable: false),
                        MedicalInstitution = c.String(),
                        ChargeTypeEnum = c.Int(nullable: false),
                        RegistrationID = c.Int(nullable: false),
                        InpatientID = c.Int(nullable: false),
                        ClinicalDiagnosis = c.String(),
                        PatientsIDCardNum = c.String(),
                        ProxyIDCardNum = c.String(),
                        ProxyName = c.String(),
                        SumOfMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WriteTime = c.DateTime(),
                        WriteUserID = c.Int(nullable: false),
                        ChargeStatusEnum = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RecipeDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupNum = c.String(),
                        MedicineID = c.Int(nullable: false),
                        SingleDose = c.Int(nullable: false),
                        Usage = c.Int(nullable: false),
                        DDDS = c.Int(nullable: false),
                        DaysNum = c.Int(nullable: false),
                        IntegralDose = c.Int(nullable: false),
                        Illustration = c.String(),
                        RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.RecipeChargeBills", "RecipeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.RecipeChargeBills", "MedicineDoctorAdviceID", "tpt.MedicineDoctorAdvice");
            DropIndex("dbo.RecipeChargeBills", new[] { "MedicineDoctorAdviceID" });
            DropColumn("dbo.RecipeChargeBills", "MedicineDoctorAdviceID");
            CreateIndex("dbo.RecipeChargeBills", "RecipeID");
            CreateIndex("dbo.Recipes", "WriteUserID");
            CreateIndex("dbo.RecipeDetails", "RecipeID");
            CreateIndex("dbo.RecipeDetails", "MedicineID");
            AddForeignKey("dbo.Recipes", "WriteUserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.RecipeDetails", "RecipeID", "dbo.Recipes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.RecipeChargeBills", "RecipeID", "dbo.Recipes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.RecipeDetails", "MedicineID", "dbo.Medicines", "ID", cascadeDelete: true);
        }
    }
}
