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
            
            AddColumn("dbo.Properties", "LandLordId", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "Name", c => c.String());
            AddColumn("dbo.Properties", "Address", c => c.String());
            AddColumn("dbo.Properties", "Description", c => c.String());
            AddColumn("dbo.Properties", "Status", c => c.String());
            AddColumn("dbo.Properties", "Type", c => c.String());
            AddColumn("dbo.Properties", "Price", c => c.Int(nullable: false));
            CreateIndex("dbo.Properties", "LandLordId");
            AddForeignKey("dbo.Properties", "LandLordId", "dbo.Landlords", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "userid", "dbo.Users");
            DropForeignKey("dbo.Biddings", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Properties", "LandLordId", "dbo.Landlords");
            DropForeignKey("dbo.Biddings", "BidderId", "dbo.Buyers");
            DropIndex("dbo.Tokens", new[] { "userid" });
            DropIndex("dbo.Properties", new[] { "LandLordId" });
            DropIndex("dbo.Biddings", new[] { "BidderId" });
            DropIndex("dbo.Biddings", new[] { "PropertyId" });
            DropColumn("dbo.Properties", "Price");
            DropColumn("dbo.Properties", "Type");
            DropColumn("dbo.Properties", "Status");
            DropColumn("dbo.Properties", "Description");
            DropColumn("dbo.Properties", "Address");
            DropColumn("dbo.Properties", "Name");
            DropColumn("dbo.Properties", "LandLordId");
            DropTable("dbo.Tokens");
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
