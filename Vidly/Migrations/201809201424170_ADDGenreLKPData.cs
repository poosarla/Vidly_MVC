namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ADDGenreLKPData : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO GENRE (GenreDescription) VALUES('Action')");
            Sql("INSERT INTO GENRE (GenreDescription) VALUES('Comedy')");
            Sql("INSERT INTO GENRE (GenreDescription) VALUES('Action Thriller')");
            Sql("INSERT INTO GENRE (GenreDescription) VALUES('Motivational')");
            Sql("INSERT INTO GENRE (GenreDescription) VALUES('Suspence')");
            Sql("INSERT INTO GENRE (GenreDescription) VALUES('Love')");
            Sql("INSERT INTO GENRE (GenreDescription) VALUES('Fights')");
        }

        public override void Down()
        {
            DropTable("dbo.Genres");
        }
    }
}
