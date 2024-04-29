namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDBWithLandlordAndManagement : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.userid, cascadeDelete: true)
                .Index(t => t.userid);
            
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.userid, cascadeDelete: true)
                .Index(t => t.userid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managements", "userid", "dbo.Users");
            DropForeignKey("dbo.Landlords", "userid", "dbo.Users");
            DropIndex("dbo.Managements", new[] { "userid" });
            DropIndex("dbo.Landlords", new[] { "userid" });
            DropTable("dbo.Managements");
            DropTable("dbo.Landlords");
        }
    }
}
