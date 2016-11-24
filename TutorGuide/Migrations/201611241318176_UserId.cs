namespace TutorGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentProfile", "UserId", c => c.String());
            AddColumn("dbo.TutorProfile", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TutorProfile", "UserId");
            DropColumn("dbo.StudentProfile", "UserId");
        }
    }
}
