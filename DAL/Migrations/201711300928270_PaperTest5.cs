namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Registrations", name: "User_ID", newName: "CancelUser_ID");
            RenameIndex(table: "dbo.Registrations", name: "IX_User_ID", newName: "IX_CancelUser_ID");
            AddColumn("dbo.Registrations", "RegisterFee", c => c.Double(nullable: false));
            AddColumn("dbo.Registrations", "RegisterTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Registrations", "CancelTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Registrations", "CancelFee", c => c.Double(nullable: false));
            AddColumn("dbo.Registrations", "ArrivalTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Registrations", "ArrivalNum", c => c.Int(nullable: false));
            AddColumn("dbo.Registrations", "RegisterUser_ID", c => c.Int());
            CreateIndex("dbo.Registrations", "RegisterUser_ID");
            AddForeignKey("dbo.Registrations", "RegisterUser_ID", "dbo.Users", "ID");
            DropColumn("dbo.Registrations", "Fee");
            DropColumn("dbo.Registrations", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registrations", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Registrations", "Fee", c => c.Double(nullable: false));
            DropForeignKey("dbo.Registrations", "RegisterUser_ID", "dbo.Users");
            DropIndex("dbo.Registrations", new[] { "RegisterUser_ID" });
            DropColumn("dbo.Registrations", "RegisterUser_ID");
            DropColumn("dbo.Registrations", "ArrivalNum");
            DropColumn("dbo.Registrations", "ArrivalTime");
            DropColumn("dbo.Registrations", "CancelFee");
            DropColumn("dbo.Registrations", "CancelTime");
            DropColumn("dbo.Registrations", "RegisterTime");
            DropColumn("dbo.Registrations", "RegisterFee");
            RenameIndex(table: "dbo.Registrations", name: "IX_CancelUser_ID", newName: "IX_User_ID");
            RenameColumn(table: "dbo.Registrations", name: "CancelUser_ID", newName: "User_ID");
        }
    }
}
