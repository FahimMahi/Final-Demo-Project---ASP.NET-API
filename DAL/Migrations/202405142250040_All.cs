namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Buyers", "userid", "dbo.Users");
            DropForeignKey("dbo.Landlords", "userid", "dbo.Users");
            DropForeignKey("dbo.Managements", "userid", "dbo.Users");
            DropIndex("dbo.Buyers", new[] { "userid" });
            DropIndex("dbo.Landlords", new[] { "userid" });
            DropIndex("dbo.Managements", new[] { "userid" });
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
            
        }
        
        public override void Down()
        {
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
            DropTable("dbo.SupportTickets");
            DropTable("dbo.Reviews");
            DropTable("dbo.Payments");
            DropTable("dbo.Memberships");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Properties");
            DropTable("dbo.Biddings");
            CreateIndex("dbo.Managements", "userid");
            CreateIndex("dbo.Landlords", "userid");
            CreateIndex("dbo.Buyers", "userid");
            AddForeignKey("dbo.Managements", "userid", "dbo.Users", "id", cascadeDelete: true);
            AddForeignKey("dbo.Landlords", "userid", "dbo.Users", "id", cascadeDelete: true);
            AddForeignKey("dbo.Buyers", "userid", "dbo.Users", "id", cascadeDelete: true);
        }
    }
}
