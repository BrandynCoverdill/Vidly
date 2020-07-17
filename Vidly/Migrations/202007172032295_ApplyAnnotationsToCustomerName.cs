namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToCustomerName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "MembershipType_Id", "dbo.MembershipType");
            DropIndex("dbo.Customer", new[] { "MembershipType_Id" });
            DropColumn("dbo.Customer", "MembershipTypeId");
            RenameColumn(table: "dbo.Customer", name: "MembershipType_Id", newName: "MembershipTypeId");
            AlterColumn("dbo.Customer", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customer", "MembershipTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customer", "MembershipTypeId");
            AddForeignKey("dbo.Customer", "MembershipTypeId", "dbo.MembershipType", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "MembershipTypeId", "dbo.MembershipType");
            DropIndex("dbo.Customer", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customer", "MembershipTypeId", c => c.Int());
            AlterColumn("dbo.Customer", "MembershipTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customer", "Name", c => c.String());
            RenameColumn(table: "dbo.Customer", name: "MembershipTypeId", newName: "MembershipType_Id");
            AddColumn("dbo.Customer", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customer", "MembershipType_Id");
            AddForeignKey("dbo.Customer", "MembershipType_Id", "dbo.MembershipType", "Id");
        }
    }
}
