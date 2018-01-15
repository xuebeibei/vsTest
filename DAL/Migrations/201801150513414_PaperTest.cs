namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssayDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssayItemID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Illustration = c.String(),
                        AssayID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Assays", t => t.AssayID, cascadeDelete: true)
                .ForeignKey("dbo.AssayItems", t => t.AssayItemID, cascadeDelete: true)
                .Index(t => t.AssayItemID)
                .Index(t => t.AssayID);
            
            CreateTable(
                "dbo.Assays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        RegistrationID = c.Int(nullable: false),
                        InpatientID = c.Int(nullable: false),
                        SumOfMoney = c.Double(nullable: false),
                        WriteTime = c.DateTime(nullable: false),
                        WriteUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.WriteUserID, cascadeDelete: true)
                .Index(t => t.WriteUserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Status = c.Int(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbr = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        JobID = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobID, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.JobID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbr = c.String(),
                        DepartmentEnum = c.Int(nullable: false),
                        ParentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Default = c.Boolean(nullable: false),
                        JobEnum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Responsibilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InpatientID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Inpatients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        No = c.String(),
                        PatientID = c.Int(nullable: false),
                        InHospitalTime = c.DateTime(nullable: false),
                        InPatientUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.InPatientUserID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.PatientID)
                .Index(t => t.InPatientUserID);
            
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
                "dbo.MedicalRecords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        MedicalRecordEnum = c.Int(nullable: false),
                        RegistrationID = c.Int(nullable: false),
                        WriteTime = c.DateTime(nullable: false),
                        WriteUserID = c.Int(nullable: false),
                        ContentXml = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Registrations", t => t.RegistrationID, cascadeDelete: true)
                .Index(t => t.RegistrationID);
            
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
                "dbo.Inspects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        RegistrationID = c.Int(nullable: false),
                        InpatientID = c.Int(nullable: false),
                        SumOfMoney = c.Double(nullable: false),
                        WriteTime = c.DateTime(nullable: false),
                        WriteUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.WriteUserID, cascadeDelete: true)
                .Index(t => t.WriteUserID);
            
            CreateTable(
                "dbo.InspectDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InspectItemID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Illustration = c.String(),
                        InspectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inspects", t => t.InspectID, cascadeDelete: true)
                .ForeignKey("dbo.InspectItems", t => t.InspectItemID, cascadeDelete: true)
                .Index(t => t.InspectItemID)
                .Index(t => t.InspectID);
            
            CreateTable(
                "dbo.InspectItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                        Price = c.Double(nullable: false),
                        Unit = c.String(),
                        BodyRegionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BodyRegions", t => t.BodyRegionID, cascadeDelete: true)
                .Index(t => t.BodyRegionID);
            
            CreateTable(
                "dbo.BodyRegions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MaterialBills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        RegistrationID = c.Int(nullable: false),
                        InpatientID = c.Int(nullable: false),
                        SumOfMoney = c.Double(nullable: false),
                        WriteTime = c.DateTime(nullable: false),
                        WriteUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.WriteUserID, cascadeDelete: true)
                .Index(t => t.WriteUserID);
            
            CreateTable(
                "dbo.MaterialBillDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MaterialItemID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Illustration = c.String(),
                        MaterialBillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MaterialBills", t => t.MaterialBillID, cascadeDelete: true)
                .ForeignKey("dbo.MaterialItems", t => t.MaterialItemID, cascadeDelete: true)
                .Index(t => t.MaterialItemID)
                .Index(t => t.MaterialBillID);
            
            CreateTable(
                "dbo.MaterialItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                        StockPrice = c.Double(nullable: false),
                        Unit = c.String(),
                        Specifications = c.String(),
                        Manufacturer = c.String(),
                        Valuable = c.Boolean(nullable: false),
                        YiBaoEnum = c.Int(nullable: false),
                        MaxNum = c.Int(nullable: false),
                        MinNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicineInStores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        SumOfMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperateTime = c.DateTime(nullable: false),
                        InStoreEnum = c.Int(nullable: false),
                        FromSupplierID = c.Int(nullable: false),
                        ToStoreID = c.Int(nullable: false),
                        Remarks = c.String(),
                        OperateUserID = c.Int(nullable: false),
                        ReCheckStatusEnum = c.Int(nullable: false),
                        ReCheckUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Suppliers", t => t.FromSupplierID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.OperateUserID, cascadeDelete: true)
                .Index(t => t.FromSupplierID)
                .Index(t => t.OperateUserID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbr1 = c.String(),
                        Abbr2 = c.String(),
                        Abbr3 = c.String(),
                        Address = c.String(),
                        Contents = c.String(),
                        Tel = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StoreRoomMedicineNums",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoreRoomID = c.Int(nullable: false),
                        SupplierID = c.Int(nullable: false),
                        MedicineID = c.Int(nullable: false),
                        Batch = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        StorePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Num = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Medicines", t => t.MedicineID, cascadeDelete: true)
                .ForeignKey("dbo.StoreRooms", t => t.StoreRoomID, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.StoreRoomID)
                .Index(t => t.SupplierID)
                .Index(t => t.MedicineID);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MedicineTypeEnum = c.Int(nullable: false),
                        Name = c.String(),
                        Abbr1 = c.String(),
                        Abbr2 = c.String(),
                        Abbr3 = c.String(),
                        DosageFormEnum = c.Int(nullable: false),
                        Unit = c.String(),
                        AdministrationRoute = c.String(),
                        Specifications = c.String(),
                        Manufacturer = c.String(),
                        PoisonousHemp = c.Boolean(nullable: false),
                        Valuable = c.Boolean(nullable: false),
                        EssentialDrugs = c.Boolean(nullable: false),
                        YiBaoEnum = c.Int(nullable: false),
                        MaxNum = c.Int(nullable: false),
                        MinNum = c.Int(nullable: false),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicineInStoreDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MedicineID = c.Int(nullable: false),
                        Batch = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        StorePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Num = c.Int(nullable: false),
                        MedicineInStoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Medicines", t => t.MedicineID, cascadeDelete: true)
                .ForeignKey("dbo.MedicineInStores", t => t.MedicineInStoreID, cascadeDelete: true)
                .Index(t => t.MedicineID)
                .Index(t => t.MedicineInStoreID);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Medicines", t => t.MedicineID, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.MedicineID)
                .Index(t => t.RecipeID);
            
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
                        SumOfMoney = c.Double(nullable: false),
                        WriteTime = c.DateTime(nullable: false),
                        WriteUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.WriteUserID, cascadeDelete: true)
                .Index(t => t.WriteUserID);
            
            CreateTable(
                "dbo.MedicineOutStoreDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoreRoomMedicineNumID = c.Int(nullable: false),
                        NumBeforeOut = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        StorePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MedicineOutStoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MedicineOutStores", t => t.MedicineOutStoreID, cascadeDelete: true)
                .ForeignKey("dbo.StoreRoomMedicineNums", t => t.StoreRoomMedicineNumID, cascadeDelete: true)
                .Index(t => t.StoreRoomMedicineNumID)
                .Index(t => t.MedicineOutStoreID);
            
            CreateTable(
                "dbo.MedicineOutStores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        SumOfMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperateTime = c.DateTime(nullable: false),
                        OutStoreEnum = c.Int(nullable: false),
                        FromStoreID = c.Int(nullable: false),
                        ToStoreID = c.Int(nullable: false),
                        ToOtherHospitalID = c.Int(nullable: false),
                        ToSupplierID = c.Int(nullable: false),
                        Remarks = c.String(),
                        OperateUserID = c.Int(nullable: false),
                        ReCheckUserID = c.Int(nullable: false),
                        ReCheckStatusEnum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StoreRooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbr1 = c.String(),
                        Abbr2 = c.String(),
                        Abbr3 = c.String(),
                        Address = c.String(),
                        Contents = c.String(),
                        Tel = c.String(),
                        StoreRoomEnum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OtherServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        RegistrationID = c.Int(nullable: false),
                        InpatientID = c.Int(nullable: false),
                        SumOfMoney = c.Double(nullable: false),
                        WriteTime = c.DateTime(nullable: false),
                        WriteUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.WriteUserID, cascadeDelete: true)
                .Index(t => t.WriteUserID);
            
            CreateTable(
                "dbo.OtherServiceDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OtherServiceItemID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Illustration = c.String(),
                        OtherServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OtherServices", t => t.OtherServiceID, cascadeDelete: true)
                .ForeignKey("dbo.OtherServiceItems", t => t.OtherServiceItemID, cascadeDelete: true)
                .Index(t => t.OtherServiceItemID)
                .Index(t => t.OtherServiceID);
            
            CreateTable(
                "dbo.OtherServiceItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                        Price = c.Double(nullable: false),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Therapies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        RegistrationID = c.Int(nullable: false),
                        InpatientID = c.Int(nullable: false),
                        SumOfMoney = c.Double(nullable: false),
                        WriteTime = c.DateTime(nullable: false),
                        WriteUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.WriteUserID, cascadeDelete: true)
                .Index(t => t.WriteUserID);
            
            CreateTable(
                "dbo.TherapyDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TherapyItemID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Illustration = c.String(),
                        TherapyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Therapies", t => t.TherapyID, cascadeDelete: true)
                .ForeignKey("dbo.TherapyItems", t => t.TherapyItemID, cascadeDelete: true)
                .Index(t => t.TherapyItemID)
                .Index(t => t.TherapyID);
            
            CreateTable(
                "dbo.TherapyItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                        Price = c.Double(nullable: false),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AssayItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                        Price = c.Double(nullable: false),
                        SpecimenID = c.Int(nullable: false),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Specimen", t => t.SpecimenID, cascadeDelete: true)
                .Index(t => t.SpecimenID);
            
            CreateTable(
                "dbo.Specimen",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AbbrPY = c.String(),
                        AbbrWB = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicineCheckStoreDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoreRoomMedicineNumID = c.Int(nullable: false),
                        NumBeforeCheck = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        StorePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MedicineCheckStoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MedicineCheckStores", t => t.MedicineCheckStoreID, cascadeDelete: true)
                .Index(t => t.MedicineCheckStoreID);
            
            CreateTable(
                "dbo.MedicineCheckStores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        SumOfMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperateTime = c.DateTime(nullable: false),
                        CheckStoreID = c.Int(nullable: false),
                        Remarks = c.String(),
                        OperateUserID = c.Int(nullable: false),
                        ReCheckUserID = c.Int(nullable: false),
                        ReCheckStatusEnum = c.Int(nullable: false),
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
            DropForeignKey("dbo.MedicineCheckStoreDetails", "MedicineCheckStoreID", "dbo.MedicineCheckStores");
            DropForeignKey("dbo.AssayItems", "SpecimenID", "dbo.Specimen");
            DropForeignKey("dbo.AssayDetails", "AssayItemID", "dbo.AssayItems");
            DropForeignKey("dbo.Therapies", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.TherapyDetails", "TherapyItemID", "dbo.TherapyItems");
            DropForeignKey("dbo.TherapyDetails", "TherapyID", "dbo.Therapies");
            DropForeignKey("dbo.OtherServices", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.OtherServiceDetails", "OtherServiceItemID", "dbo.OtherServiceItems");
            DropForeignKey("dbo.OtherServiceDetails", "OtherServiceID", "dbo.OtherServices");
            DropForeignKey("dbo.MedicineInStores", "OperateUserID", "dbo.Users");
            DropForeignKey("dbo.StoreRoomMedicineNums", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.StoreRoomMedicineNums", "StoreRoomID", "dbo.StoreRooms");
            DropForeignKey("dbo.MedicineOutStoreDetails", "StoreRoomMedicineNumID", "dbo.StoreRoomMedicineNums");
            DropForeignKey("dbo.MedicineOutStoreDetails", "MedicineOutStoreID", "dbo.MedicineOutStores");
            DropForeignKey("dbo.StoreRoomMedicineNums", "MedicineID", "dbo.Medicines");
            DropForeignKey("dbo.Recipes", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.RecipeDetails", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.RecipeDetails", "MedicineID", "dbo.Medicines");
            DropForeignKey("dbo.MedicineInStoreDetails", "MedicineInStoreID", "dbo.MedicineInStores");
            DropForeignKey("dbo.MedicineInStoreDetails", "MedicineID", "dbo.Medicines");
            DropForeignKey("dbo.MedicineInStores", "FromSupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.MaterialBills", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.MaterialBillDetails", "MaterialItemID", "dbo.MaterialItems");
            DropForeignKey("dbo.MaterialBillDetails", "MaterialBillID", "dbo.MaterialBills");
            DropForeignKey("dbo.Inspects", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.InspectDetails", "InspectItemID", "dbo.InspectItems");
            DropForeignKey("dbo.InspectItems", "BodyRegionID", "dbo.BodyRegions");
            DropForeignKey("dbo.InspectDetails", "InspectID", "dbo.Inspects");
            DropForeignKey("dbo.Registrations", "SignalSourceID", "dbo.SignalSources");
            DropForeignKey("dbo.Registrations", "RegisterUserID", "dbo.Users");
            DropForeignKey("dbo.Registrations", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.MedicalRecords", "RegistrationID", "dbo.Registrations");
            DropForeignKey("dbo.Inpatients", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Inpatients", "InPatientUserID", "dbo.Users");
            DropForeignKey("dbo.Users", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Responsibilities", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Assays", "WriteUserID", "dbo.Users");
            DropForeignKey("dbo.AssayDetails", "AssayID", "dbo.Assays");
            DropIndex("dbo.Triages", new[] { "User_ID" });
            DropIndex("dbo.MedicineCheckStoreDetails", new[] { "MedicineCheckStoreID" });
            DropIndex("dbo.AssayItems", new[] { "SpecimenID" });
            DropIndex("dbo.TherapyDetails", new[] { "TherapyID" });
            DropIndex("dbo.TherapyDetails", new[] { "TherapyItemID" });
            DropIndex("dbo.Therapies", new[] { "WriteUserID" });
            DropIndex("dbo.OtherServiceDetails", new[] { "OtherServiceID" });
            DropIndex("dbo.OtherServiceDetails", new[] { "OtherServiceItemID" });
            DropIndex("dbo.OtherServices", new[] { "WriteUserID" });
            DropIndex("dbo.MedicineOutStoreDetails", new[] { "MedicineOutStoreID" });
            DropIndex("dbo.MedicineOutStoreDetails", new[] { "StoreRoomMedicineNumID" });
            DropIndex("dbo.Recipes", new[] { "WriteUserID" });
            DropIndex("dbo.RecipeDetails", new[] { "RecipeID" });
            DropIndex("dbo.RecipeDetails", new[] { "MedicineID" });
            DropIndex("dbo.MedicineInStoreDetails", new[] { "MedicineInStoreID" });
            DropIndex("dbo.MedicineInStoreDetails", new[] { "MedicineID" });
            DropIndex("dbo.StoreRoomMedicineNums", new[] { "MedicineID" });
            DropIndex("dbo.StoreRoomMedicineNums", new[] { "SupplierID" });
            DropIndex("dbo.StoreRoomMedicineNums", new[] { "StoreRoomID" });
            DropIndex("dbo.MedicineInStores", new[] { "OperateUserID" });
            DropIndex("dbo.MedicineInStores", new[] { "FromSupplierID" });
            DropIndex("dbo.MaterialBillDetails", new[] { "MaterialBillID" });
            DropIndex("dbo.MaterialBillDetails", new[] { "MaterialItemID" });
            DropIndex("dbo.MaterialBills", new[] { "WriteUserID" });
            DropIndex("dbo.InspectItems", new[] { "BodyRegionID" });
            DropIndex("dbo.InspectDetails", new[] { "InspectID" });
            DropIndex("dbo.InspectDetails", new[] { "InspectItemID" });
            DropIndex("dbo.Inspects", new[] { "WriteUserID" });
            DropIndex("dbo.MedicalRecords", new[] { "RegistrationID" });
            DropIndex("dbo.Registrations", new[] { "RegisterUserID" });
            DropIndex("dbo.Registrations", new[] { "SignalSourceID" });
            DropIndex("dbo.Registrations", new[] { "PatientID" });
            DropIndex("dbo.Inpatients", new[] { "InPatientUserID" });
            DropIndex("dbo.Inpatients", new[] { "PatientID" });
            DropIndex("dbo.Responsibilities", new[] { "EmployeeID" });
            DropIndex("dbo.Employees", new[] { "JobID" });
            DropIndex("dbo.Employees", new[] { "DepartmentID" });
            DropIndex("dbo.Users", new[] { "EmployeeID" });
            DropIndex("dbo.Assays", new[] { "WriteUserID" });
            DropIndex("dbo.AssayDetails", new[] { "AssayID" });
            DropIndex("dbo.AssayDetails", new[] { "AssayItemID" });
            DropTable("dbo.Triages");
            DropTable("dbo.MedicineCheckStores");
            DropTable("dbo.MedicineCheckStoreDetails");
            DropTable("dbo.Specimen");
            DropTable("dbo.AssayItems");
            DropTable("dbo.TherapyItems");
            DropTable("dbo.TherapyDetails");
            DropTable("dbo.Therapies");
            DropTable("dbo.OtherServiceItems");
            DropTable("dbo.OtherServiceDetails");
            DropTable("dbo.OtherServices");
            DropTable("dbo.StoreRooms");
            DropTable("dbo.MedicineOutStores");
            DropTable("dbo.MedicineOutStoreDetails");
            DropTable("dbo.Recipes");
            DropTable("dbo.RecipeDetails");
            DropTable("dbo.MedicineInStoreDetails");
            DropTable("dbo.Medicines");
            DropTable("dbo.StoreRoomMedicineNums");
            DropTable("dbo.Suppliers");
            DropTable("dbo.MedicineInStores");
            DropTable("dbo.MaterialItems");
            DropTable("dbo.MaterialBillDetails");
            DropTable("dbo.MaterialBills");
            DropTable("dbo.BodyRegions");
            DropTable("dbo.InspectItems");
            DropTable("dbo.InspectDetails");
            DropTable("dbo.Inspects");
            DropTable("dbo.SignalSources");
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.Registrations");
            DropTable("dbo.Patients");
            DropTable("dbo.Inpatients");
            DropTable("dbo.Responsibilities");
            DropTable("dbo.Jobs");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Users");
            DropTable("dbo.Assays");
            DropTable("dbo.AssayDetails");
        }
    }
}
