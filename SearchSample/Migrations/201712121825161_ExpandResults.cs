namespace SearchSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpandResults : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clicks", "ArtistName", c => c.String());
            AddColumn("dbo.Clicks", "CollectionCensoredName", c => c.String());
            AddColumn("dbo.Clicks", "TrackCensoredName", c => c.String());
            AddColumn("dbo.Clicks", "ArtistViewUrl", c => c.String());
            AddColumn("dbo.Clicks", "CollectionViewUrl", c => c.String());
            AddColumn("dbo.Clicks", "PreviewUrl", c => c.String());
            AddColumn("dbo.Clicks", "ArtworkUrl60", c => c.String());
            AddColumn("dbo.Clicks", "ArtworkUrl100", c => c.String());
            AddColumn("dbo.Clicks", "CollectionPrice", c => c.String());
            AddColumn("dbo.Clicks", "TrackPrice", c => c.String());
            AddColumn("dbo.Clicks", "CollectionExplicitness", c => c.String());
            AddColumn("dbo.Clicks", "TrackExplicitness", c => c.String());
            AddColumn("dbo.Clicks", "DiscCount", c => c.String());
            AddColumn("dbo.Clicks", "DiscNumber", c => c.String());
            AddColumn("dbo.Clicks", "TrackCount", c => c.String());
            AddColumn("dbo.Clicks", "TrackNumber", c => c.String());
            AddColumn("dbo.Clicks", "TrackTimeMillis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clicks", "TrackTimeMillis");
            DropColumn("dbo.Clicks", "TrackNumber");
            DropColumn("dbo.Clicks", "TrackCount");
            DropColumn("dbo.Clicks", "DiscNumber");
            DropColumn("dbo.Clicks", "DiscCount");
            DropColumn("dbo.Clicks", "TrackExplicitness");
            DropColumn("dbo.Clicks", "CollectionExplicitness");
            DropColumn("dbo.Clicks", "TrackPrice");
            DropColumn("dbo.Clicks", "CollectionPrice");
            DropColumn("dbo.Clicks", "ArtworkUrl100");
            DropColumn("dbo.Clicks", "ArtworkUrl60");
            DropColumn("dbo.Clicks", "PreviewUrl");
            DropColumn("dbo.Clicks", "CollectionViewUrl");
            DropColumn("dbo.Clicks", "ArtistViewUrl");
            DropColumn("dbo.Clicks", "TrackCensoredName");
            DropColumn("dbo.Clicks", "CollectionCensoredName");
            DropColumn("dbo.Clicks", "ArtistName");
        }
    }
}
