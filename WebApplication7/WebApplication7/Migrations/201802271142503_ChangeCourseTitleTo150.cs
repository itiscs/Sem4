namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCourseTitleTo150 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Course", "Title", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Course", "Title", c => c.String(maxLength: 100));
        }
    }
}
