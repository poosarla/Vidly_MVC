namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "MemberShipTypeDesc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemberShipTypes", "MemberShipTypeDesc");
        }
    }
}
