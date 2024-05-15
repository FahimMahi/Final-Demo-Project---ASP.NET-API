namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllDone : DbMigration
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
                "dbo.Feedbacks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                "dbo.Memberships",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PlanName = c.String(nullable: false, maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentMethod = c.String(nullable: false, maxLength: 50),
                        Status = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.SupportTickets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        Status = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        userid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.userid, cascadeDelete: true)
                .Index(t => t.userid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "userid", "dbo.Users");
            DropForeignKey("dbo.SupportTickets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Payments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Payments", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Memberships", "UserId", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Biddings", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Properties", "LandLordId", "dbo.Landlords");
            DropForeignKey("dbo.Biddings", "BidderId", "dbo.Buyers");
            DropIndex("dbo.Tokens", new[] { "userid" });
            DropIndex("dbo.SupportTickets", new[] { "UserId" });
            DropIndex("dbo.Reviews", new[] { "PropertyId" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "PropertyId" });
            DropIndex("dbo.Payments", new[] { "UserId" });
            DropIndex("dbo.Memberships", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropIndex("dbo.Properties", new[] { "LandLordId" });
            DropIndex("dbo.Biddings", new[] { "BidderId" });
            DropIndex("dbo.Biddings", new[] { "PropertyId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.SupportTickets");
            DropTable("dbo.Reviews");
            DropTable("dbo.Payments");
            DropTable("dbo.Memberships");
            DropTable("dbo.Managements");
            DropTable("dbo.Users");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Landlords");
            DropTable("dbo.Properties");
            DropTable("dbo.Buyers");
            DropTable("dbo.Biddings");
        }
    }
}
