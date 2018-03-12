namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student2", "ImageFile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student2", "ImageFile");
        }
    }
}
