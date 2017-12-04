namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest7 : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.Triages", new[] { "User_ID" });
            DropTable("dbo.Triages");
        }
    }
}
