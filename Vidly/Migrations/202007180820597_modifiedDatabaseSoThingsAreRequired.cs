namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedDatabaseSoThingsAreRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "Name", c => c.String());
        }
    }
}
