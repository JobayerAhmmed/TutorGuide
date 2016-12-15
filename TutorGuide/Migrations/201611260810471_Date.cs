namespace TutorGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Date : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Communication", "PhoneNumber");
            DropColumn("dbo.Communication", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Communication", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Communication", "PhoneNumber", c => c.String());
        }
    }
}
