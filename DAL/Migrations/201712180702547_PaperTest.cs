namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbr = c.String(),
                        IsDoctorDepartment = c.Boolean(nullable: false),
                        ParentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.Int(nullable: false),
                        Department_ID = c.Int(),
                        Job_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.Department_ID)
                .ForeignKey("dbo.Jobs", t => t.Job_ID)
                .Index(t => t.Department_ID)
                .Index(t => t.Job_ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Default = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.Int(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        Volk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(nullable: false),
                        SignalSourceID = c.Int(nullable: false),
                        RegisterUserID = c.Int(nullable: false),
                        RegisterFee = c.Double(nullable: false),
                        RegisterTime = c.DateTime(nullable: false),
                        SeeDoctorStatus = c.Int(nullable: false),
                        TriageStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.RegisterUserID, cascadeDelete: true)
                .ForeignKey("dbo.SignalSources", t => t.SignalSourceID, cascadeDelete: true)
                .Index(t => t.PatientID)
                .Index(t => t.SignalSourceID)
                .Index(t => t.RegisterUserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Status = c.Int(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                        Employee_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.Employee_ID)
                .Index(t => t.Employee_ID);
            
            CreateTable(
                "dbo.SignalSources",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        VistTime = c.DateTime(nullable: false),
                        TimeIntival = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        SignalType = c.Int(nullable: false),
                        MaxNum = c.Int(nullable: false),
                        AddMaxNum = c.Int(nullable: false),
                        HasUsedNum = c.Int(nullable: false),
                        Specialist = c.Int(nullable: false),
                        Explain = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            CreateTable(
                "dbo.Triages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegistrationID = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Triages", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Registrations", "SignalSourceID", "dbo.SignalSources");
            DropForeignKey("dbo.Registrations", "RegisterUserID", "dbo.Users");
            DropForeignKey("dbo.Users", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.Registrations", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Employees", "Job_ID", "dbo.Jobs");
            DropForeignKey("dbo.Employees", "Department_ID", "dbo.Departments");
            DropIndex("dbo.Triages", new[] { "User_ID" });
            DropIndex("dbo.Users", new[] { "Employee_ID" });
            DropIndex("dbo.Registrations", new[] { "RegisterUserID" });
            DropIndex("dbo.Registrations", new[] { "SignalSourceID" });
            DropIndex("dbo.Registrations", new[] { "PatientID" });
            DropIndex("dbo.Employees", new[] { "Job_ID" });
            DropIndex("dbo.Employees", new[] { "Department_ID" });
            DropTable("dbo.Triages");
            DropTable("dbo.Recipes");
            DropTable("dbo.RecipeDetails");
            DropTable("dbo.SignalSources");
            DropTable("dbo.Users");
            DropTable("dbo.Registrations");
            DropTable("dbo.Patients");
            DropTable("dbo.Medicines");
            DropTable("dbo.MedicinePackings");
            DropTable("dbo.MedicineAlias");
            DropTable("dbo.Jobs");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
