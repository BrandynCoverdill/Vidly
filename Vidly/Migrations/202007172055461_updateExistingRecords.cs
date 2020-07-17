﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateExistingRecords : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipType SET Name = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipType SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipType SET Name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipType SET Name = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
