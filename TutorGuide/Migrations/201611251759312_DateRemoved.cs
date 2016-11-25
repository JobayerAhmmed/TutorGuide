namespace TutorGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Post", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "Date", c => c.DateTime(nullable: false));
        }
    }
}
