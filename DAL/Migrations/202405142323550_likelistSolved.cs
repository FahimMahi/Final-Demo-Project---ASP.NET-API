namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class likelistSolved : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LikedProperties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Buyers", t => t.BuyerId, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId)
                .Index(t => t.BuyerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LikedProperties", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.LikedProperties", "BuyerId", "dbo.Buyers");
            DropIndex("dbo.LikedProperties", new[] { "BuyerId" });
            DropIndex("dbo.LikedProperties", new[] { "PropertyId" });
            DropTable("dbo.LikedProperties");
        }
    }
}
