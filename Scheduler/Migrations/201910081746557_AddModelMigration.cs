namespace Scheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auditories", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Groups", "Name", c => c.String());
            AddColumn("dbo.Groups", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Lessons", "HoursPlan", c => c.Int(nullable: false));
            AddColumn("dbo.Lessons", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "Name");
            DropColumn("dbo.Lessons", "HoursPlan");
            DropColumn("dbo.Groups", "Year");
            DropColumn("dbo.Groups", "Name");
            DropColumn("dbo.Auditories", "Number");
        }
    }
}
