namespace SearchSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClickTrack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clicks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TrackId = c.String(),
                        TrackName = c.String(),
                        TrackViewUrl = c.String(),
                        WrapperType = c.String(),
                        Kind = c.String(),
                        PrimaryGenreName = c.String(),
                        Country = c.String(),
                        Currency = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clicks");
        }
    }
}
