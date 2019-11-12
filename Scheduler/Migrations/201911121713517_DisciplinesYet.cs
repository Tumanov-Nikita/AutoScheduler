namespace Scheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisciplinesYet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "Discipline_Id", "dbo.Disciplines");
            DropIndex("dbo.Groups", new[] { "Discipline_Id" });
            AddColumn("dbo.Disciplines", "Groups", c => c.String());
            DropColumn("dbo.Groups", "Discipline_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "Discipline_Id", c => c.Int());
            DropColumn("dbo.Disciplines", "Groups");
            CreateIndex("dbo.Groups", "Discipline_Id");
            AddForeignKey("dbo.Groups", "Discipline_Id", "dbo.Disciplines", "Id");
        }
    }
}
