namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedBirthdateForCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customer SET Birthdate = CAST('1998-11-17' as date) WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
