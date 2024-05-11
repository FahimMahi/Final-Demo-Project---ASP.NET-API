namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Biddings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BiddingAmount = c.Int(nullable: false),
                        TimeDuration = c.DateTime(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        BidderId = c.Int(nullable: false),
                        BuyerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyers", t => t.BidderId, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId)
                .Index(t => t.BidderId);
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        address = c.String(nullable: false),
                        userid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LandLordId = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Description = c.String(),
                        Status = c.String(),
                        Type = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Landlords", t => t.LandLordId, cascadeDelete: true)
                .Index(t => t.LandLordId);
            
            CreateTable(
                "dbo.Landlords",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        address = c.String(nullable: false),
                        userid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Managements",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        designation = c.String(nullable: false),
                        address = c.String(nullable: false),
                        userid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        uname = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Biddings", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Properties", "LandLordId", "dbo.Landlords");
            DropForeignKey("dbo.Biddings", "BidderId", "dbo.Buyers");
            DropIndex("dbo.Properties", new[] { "LandLordId" });
            DropIndex("dbo.Biddings", new[] { "BidderId" });
            DropIndex("dbo.Biddings", new[] { "PropertyId" });
            DropTable("dbo.Users");
            DropTable("dbo.Managements");
            DropTable("dbo.Landlords");
            DropTable("dbo.Properties");
            DropTable("dbo.Buyers");
            DropTable("dbo.Biddings");
        }
    }
}
