namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Movie_Table_AddGenreIDColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreID", c => c.Int());

        }

        public override void Down()
        {
            DropColumn("dbo.Movies", "GenreID");
        }
    }
}
