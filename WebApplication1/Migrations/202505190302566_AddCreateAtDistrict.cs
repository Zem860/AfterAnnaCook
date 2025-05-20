namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateAtDistrict : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Districts", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Districts", "CreatedAt");
        }
    }
}
