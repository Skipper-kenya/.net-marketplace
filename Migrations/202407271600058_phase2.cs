namespace marketplace1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phase2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "Category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Category", c => c.String());
            AlterColumn("dbo.Items", "Description", c => c.String());
            AlterColumn("dbo.Items", "Name", c => c.String());
        }
    }
}
