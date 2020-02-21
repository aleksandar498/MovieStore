namespace MovieStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'845cd9f9-c8e5-4b75-8ce9-e10f3c55da67', N'guest@moviestore.com', 0, N'AG4/zs6iTK2FGJIvXnNyOrv9fINHDcnlrs3BP8MeozD3uTvllDNnxiPnnvRExs9v5Q==', N'7d58b61f-de70-499f-97d5-b0690c698ef8', NULL, 0, 0, NULL, 1, 0, N'guest@moviestore.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a4e34df5-b8dc-4a92-877f-0aae8c05528f', N'admin@moviestore.com', 0, N'AB4YDdhHfvVxDH2DEAD9SfVSJ6HwRDLKaw8LiNHziMF7838vOQdtP97l7i31PrJh6g==', N'9d0dba3f-9ce4-4f3b-9c92-3cae6a86a94d', NULL, 0, 0, NULL, 1, 0, N'admin@moviestore.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7bc68e94-7c1f-4c40-9279-5bb8159a53ea', N'canManageMovies')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a4e34df5-b8dc-4a92-877f-0aae8c05528f', N'7bc68e94-7c1f-4c40-9279-5bb8159a53ea')
");


        }
        
        public override void Down()
        {
        }
    }
}
