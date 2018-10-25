namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddMemberShipLookup : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes (SignUpFee,DiscountRate,DurationinMonths) VALUES(0,0,0)");
            Sql("INSERT INTO MemberShipTypes (SignUpFee,DiscountRate,DurationinMonths) VALUES(30,1,10)");
            Sql("INSERT INTO MemberShipTypes (SignUpFee,DiscountRate,DurationinMonths) VALUES(90,15,3)");
            Sql("INSERT INTO MemberShipTypes (SignUpFee,DiscountRate,DurationinMonths) VALUES(300,20,12)");

        }

        public override void Down()
        {
        }
    }
}
