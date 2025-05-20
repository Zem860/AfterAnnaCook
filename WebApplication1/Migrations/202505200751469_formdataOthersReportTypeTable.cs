namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class formdataOthersReportTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(nullable: false, maxLength: 20),
                        TaxId = c.String(nullable: false, maxLength: 8),
                        ResponsiblePersonName = c.String(nullable: false, maxLength: 20),
                        PersonalId = c.String(nullable: false, maxLength: 10),
                        BusinessPostalCode = c.String(nullable: false, maxLength: 3),
                        BusinessCountyId = c.Int(nullable: false),
                        BusinessDistrictId = c.Int(nullable: false),
                        BusinessAddress = c.String(nullable: false, maxLength: 30),
                        ReportTypeId = c.Int(nullable: false),
                        StartYear = c.Int(nullable: false),
                        startMonth = c.Int(nullable: false),
                        OtherId = c.Int(nullable: false),
                        ContactPersonName = c.String(nullable: false, maxLength: 20),
                        ContactPhone = c.String(),
                        ContactCellPhone = c.String(),
                        ContactExt = c.String(),
                        IsSameAsBusinessAddress = c.Boolean(nullable: false),
                        ContactPostalCode = c.String(nullable: false, maxLength: 3),
                        ContactCountyId = c.Int(nullable: false),
                        ContactDistrictId = c.Int(nullable: false),
                        ContactAddress = c.String(nullable: false, maxLength: 30),
                        ContactEmail = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Counties", t => t.BusinessCountyId)
                .ForeignKey("dbo.Districts", t => t.BusinessDistrictId)
                .ForeignKey("dbo.Counties", t => t.ContactCountyId)
                .ForeignKey("dbo.Districts", t => t.ContactDistrictId)
                .ForeignKey("dbo.Others", t => t.OtherId, cascadeDelete: true)
                .ForeignKey("dbo.ReportTypes", t => t.ReportTypeId, cascadeDelete: true)
                .Index(t => t.BusinessCountyId)
                .Index(t => t.BusinessDistrictId)
                .Index(t => t.ReportTypeId)
                .Index(t => t.OtherId)
                .Index(t => t.ContactCountyId)
                .Index(t => t.ContactDistrictId);
            
            CreateTable(
                "dbo.Others",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Other = c.String(nullable: false, maxLength: 20),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReportTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportTypeName = c.String(nullable: false, maxLength: 20),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FormDatas", "ReportTypeId", "dbo.ReportTypes");
            DropForeignKey("dbo.FormDatas", "OtherId", "dbo.Others");
            DropForeignKey("dbo.FormDatas", "ContactDistrictId", "dbo.Districts");
            DropForeignKey("dbo.FormDatas", "ContactCountyId", "dbo.Counties");
            DropForeignKey("dbo.FormDatas", "BusinessDistrictId", "dbo.Districts");
            DropForeignKey("dbo.FormDatas", "BusinessCountyId", "dbo.Counties");
            DropIndex("dbo.FormDatas", new[] { "ContactDistrictId" });
            DropIndex("dbo.FormDatas", new[] { "ContactCountyId" });
            DropIndex("dbo.FormDatas", new[] { "OtherId" });
            DropIndex("dbo.FormDatas", new[] { "ReportTypeId" });
            DropIndex("dbo.FormDatas", new[] { "BusinessDistrictId" });
            DropIndex("dbo.FormDatas", new[] { "BusinessCountyId" });
            DropTable("dbo.ReportTypes");
            DropTable("dbo.Others");
            DropTable("dbo.FormDatas");
        }
    }
}
