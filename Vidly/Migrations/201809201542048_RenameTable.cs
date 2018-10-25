namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RenameTable : DbMigration
    {
        public override void Up()
        {
            Sql("EXEC sp_rename 'Genre', 'Genres'");
        }

        public override void Down()
        {
        }
    }
}
