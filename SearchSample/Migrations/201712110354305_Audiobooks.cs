namespace SearchSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Audiobooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clicks", "CollectionId", c => c.String());
            AddColumn("dbo.Clicks", "CollectionName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clicks", "CollectionName");
            DropColumn("dbo.Clicks", "CollectionId");
        }
    }
}
