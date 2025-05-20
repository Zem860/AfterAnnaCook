namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDistrictName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Districts", "DistrictName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Districts", "DistrictName");
        }
    }
}
