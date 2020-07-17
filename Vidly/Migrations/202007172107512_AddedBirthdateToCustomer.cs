namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBirthdateToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Birthdate", c => c.DateTime());
            Sql("UPDATE Customer SET Birthdate = CAST('1998-11-17') WHERE Id = 1");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "Birthdate");
        }
    }
}
