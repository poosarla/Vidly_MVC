namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationsto_Movie_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleasedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberinStock", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "CheckProp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "CheckProp", c => c.String());
            DropColumn("dbo.Movies", "NumberinStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleasedDate");
        }
    }
}
