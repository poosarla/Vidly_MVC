namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ADDGenreLKP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
             "dbo.Genre",
             c => new
             {
                 GenreID = c.Int(nullable: false, identity: true),
                 GenreDescription = c.String(),
             })
             .PrimaryKey(t => t.GenreID);
        }

        public override void Down()
        {
        }
    }
}
