namespace Scheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Disciplines : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "Lector_Id", "dbo.Lectors");
            DropIndex("dbo.Lessons", new[] { "Lector_Id" });
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HoursPlan = c.Int(nullable: false),
                        Lector_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lectors", t => t.Lector_Id)
                .Index(t => t.Lector_Id);
            
            AddColumn("dbo.Groups", "Discipline_Id", c => c.Int());
            AddColumn("dbo.Lessons", "Auditory_Id", c => c.Int());
            AddColumn("dbo.Lessons", "Discipline_Id", c => c.Int());
            AddColumn("dbo.Lessons", "Group_Id", c => c.Int());
            CreateIndex("dbo.Groups", "Discipline_Id");
            CreateIndex("dbo.Lessons", "Auditory_Id");
            CreateIndex("dbo.Lessons", "Discipline_Id");
            CreateIndex("dbo.Lessons", "Group_Id");
            AddForeignKey("dbo.Groups", "Discipline_Id", "dbo.Disciplines", "Id");
            AddForeignKey("dbo.Lessons", "Auditory_Id", "dbo.Auditories", "Id");
            AddForeignKey("dbo.Lessons", "Discipline_Id", "dbo.Disciplines", "Id");
            AddForeignKey("dbo.Lessons", "Group_Id", "dbo.Groups", "Id");
            DropColumn("dbo.Lessons", "Name");
            DropColumn("dbo.Lessons", "HoursPlan");
            DropColumn("dbo.Lessons", "Lector_Id");
            DropTable("dbo.Days");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaxLessons = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Lessons", "Lector_Id", c => c.Int());
            AddColumn("dbo.Lessons", "HoursPlan", c => c.Int(nullable: false));
            AddColumn("dbo.Lessons", "Name", c => c.String());
            DropForeignKey("dbo.Lessons", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Lessons", "Discipline_Id", "dbo.Disciplines");
            DropForeignKey("dbo.Lessons", "Auditory_Id", "dbo.Auditories");
            DropForeignKey("dbo.Disciplines", "Lector_Id", "dbo.Lectors");
            DropForeignKey("dbo.Groups", "Discipline_Id", "dbo.Disciplines");
            DropIndex("dbo.Lessons", new[] { "Group_Id" });
            DropIndex("dbo.Lessons", new[] { "Discipline_Id" });
            DropIndex("dbo.Lessons", new[] { "Auditory_Id" });
            DropIndex("dbo.Groups", new[] { "Discipline_Id" });
            DropIndex("dbo.Disciplines", new[] { "Lector_Id" });
            DropColumn("dbo.Lessons", "Group_Id");
            DropColumn("dbo.Lessons", "Discipline_Id");
            DropColumn("dbo.Lessons", "Auditory_Id");
            DropColumn("dbo.Groups", "Discipline_Id");
            DropTable("dbo.Disciplines");
            CreateIndex("dbo.Lessons", "Lector_Id");
            AddForeignKey("dbo.Lessons", "Lector_Id", "dbo.Lectors", "Id");
        }
    }
}
