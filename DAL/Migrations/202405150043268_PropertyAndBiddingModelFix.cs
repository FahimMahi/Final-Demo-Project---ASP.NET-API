namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyAndBiddingModelFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Properties", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "Type", c => c.String(nullable: false));
            DropColumn("dbo.Biddings", "TimeDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Biddings", "TimeDuration", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Properties", "Type", c => c.String());
            AlterColumn("dbo.Properties", "Status", c => c.String());
            AlterColumn("dbo.Properties", "Description", c => c.String());
            AlterColumn("dbo.Properties", "Address", c => c.String());
            AlterColumn("dbo.Properties", "Name", c => c.String());
        }
    }
}
