namespace TutorGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atik2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "IsCompleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Post", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "Status", c => c.String());
            DropColumn("dbo.Post", "IsCompleted");
        }
    }
}
