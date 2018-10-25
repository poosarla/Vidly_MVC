namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0dc3cd95-fb0b-4e58-b615-7191b29329a0', N'admin@vidly.com', 0, N'AHiyoY7Z+/WraDDhQFLQeMomYH3I5KKWH2+Fa7LDLBoAP8xNbyMA1jyYdgryQHhcoQ==', N'185218c1-dd7d-474f-b7a2-e7f75962ff85', NULL, 0, 0, NULL, 0, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0eab9c50-1fcc-44de-babf-f94d8d83038d', N'guest@gmail.com', 0, N'ABEaxGZKBbdrNM0/dBSJuQxueif6Ha7vLhOdyo7A5Al27ET4dkKJNl0Zcq9Y2SLGFg==', N'd152142d-e0c9-4b0c-841f-8ca6ac3fd30e', NULL, 0, 0, NULL, 0, 0, N'guest@gmail.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2993eba2-2702-4e04-a497-fdf864d111e6', N'canManageMovies')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0dc3cd95-fb0b-4e58-b615-7191b29329a0', N'2993eba2-2702-4e04-a497-fdf864d111e6')

            ");

        }

        public override void Down()
        {
        }
    }
}
