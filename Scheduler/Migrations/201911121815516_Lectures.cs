namespace Scheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lectures : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "Lecture", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "Lecture");
        }
    }
}
