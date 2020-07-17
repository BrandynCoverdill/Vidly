namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMovieMockData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movie (Name, Genre, ReleaseDate, DateAdded, NumberInStock)" +
                " VALUES('Hangover', 'Comedy', '2009/6/5', GETDATE(), 5)");
            Sql("INSERT INTO Movie (Name, Genre, ReleaseDate, DateAdded, NumberInStock)" +
                " VALUES('Die Hard', 'Action', '1988/7/20', GETDATE(), 7)");
            Sql("INSERT INTO Movie (Name, Genre, ReleaseDate, DateAdded, NumberInStock)" +
                " VALUES('The Terminator', 'Action', '1984/10/26', GETDATE(), 12)");
            Sql("INSERT INTO Movie (Name, Genre, ReleaseDate, DateAdded, NumberInStock)" +
                " VALUES('Toy Story', 'Family', '1995/11/22', GETDATE(), 9)");
            Sql("INSERT INTO Movie (Name, Genre, ReleaseDate, DateAdded, NumberInStock)" +
                " VALUES('Titanic', 'Romance', '1997/12/19', GETDATE(), 11)");
        }
        
        public override void Down()
        {
        }
    }
}
