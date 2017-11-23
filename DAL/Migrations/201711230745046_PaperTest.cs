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
                        Fee = c.Double(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Patient_ID = c.Int(),
                        SignalSource_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Patients", t => t.Patient_ID)
                .ForeignKey("dbo.SignalSources", t => t.SignalSource_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Patient_ID)
                .Index(t => t.SignalSource_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.SignalSources",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        VistTime = c.DateTime(nullable: false),
                        TimeIntival = c.Int(nullable: false),
                        SignalType = c.Int(nullable: false),
                        MaxNum = c.Int(nullable: false),
                        AddMaxNum = c.Int(nullable: false),
                        HasUsedNum = c.Int(nullable: false),
                        Specialist = c.Int(nullable: false),
                        Explain = c.String(),
                        Department_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.Department_ID)
                .Index(t => t.Department_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Status = c.Int(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Registrations", "SignalSource_ID", "dbo.SignalSources");
            DropForeignKey("dbo.SignalSources", "Department_ID", "dbo.Departments");
            DropForeignKey("dbo.Registrations", "Patient_ID", "dbo.Patients");
            DropIndex("dbo.SignalSources", new[] { "Department_ID" });
            DropIndex("dbo.Registrations", new[] { "User_ID" });
            DropIndex("dbo.Registrations", new[] { "SignalSource_ID" });
            DropIndex("dbo.Registrations", new[] { "Patient_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.SignalSources");
            DropTable("dbo.Registrations");
            DropTable("dbo.Patients");
            DropTable("dbo.Departments");
        }
    }
}
