namespace TutorGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "Status");
        }
    }
}
