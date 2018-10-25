namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class MemberShipLookupUpdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes SET MemberShipTypeDesc='PAY AS YOU GO' WHERE ID=1");
            Sql("UPDATE MemberShipTypes SET MemberShipTypeDesc='MONTHLY' WHERE ID=2");
            Sql("UPDATE MemberShipTypes SET MemberShipTypeDesc='QUATERLY' WHERE ID=3");
            Sql("UPDATE MemberShipTypes SET MemberShipTypeDesc='YEARLY' WHERE ID=4");

        }

        public override void Down()
        {
        }
    }
}
