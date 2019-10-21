namespace Scheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auditories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lector_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lectors", t => t.Lector_Id)
                .Index(t => t.Lector_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "Lector_Id", "dbo.Lectors");
            DropIndex("dbo.Lessons", new[] { "Lector_Id" });
            DropTable("dbo.Lessons");
            DropTable("dbo.Lectors");
            DropTable("dbo.Groups");
            DropTable("dbo.Auditories");
        }
    }
}
