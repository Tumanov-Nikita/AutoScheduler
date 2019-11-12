namespace Scheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class formAuditories : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auditories", "Number", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Auditories", "Number", c => c.Int(nullable: false));
        }
    }
}
