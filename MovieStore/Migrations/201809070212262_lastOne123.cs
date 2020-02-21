namespace MovieStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastOne123 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rentals", "MovieId");
            DropColumn("dbo.Rentals", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "CustomerId", c => c.Byte(nullable: false));
            AddColumn("dbo.Rentals", "MovieId", c => c.Byte(nullable: false));
        }
    }
}
