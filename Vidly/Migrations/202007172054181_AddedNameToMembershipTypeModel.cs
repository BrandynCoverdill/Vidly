namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameToMembershipTypeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipType", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipType", "Name");
        }
    }
}
