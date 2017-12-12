namespace SearchSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ClickSummary : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clicks", "TrackId", c => c.Long(nullable: false));
            AlterColumn("dbo.Clicks", "CollectionId", c => c.Long(nullable: false));

            Sql("CREATE VIEW [dbo].[ClickSummary] WITH SCHEMABINDING AS SELECT [TrackId],    [TrackName],    [TrackViewUrl],    [WrapperType],    [Kind],    [PrimaryGenreName],    [Country],    [Currency],    [CollectionId],    [CollectionName],    COUNT_BIG(*) AS[Clicks]    FROM[dbo].[Clicks]    GROUP BY    [TrackId],    [TrackName],    [TrackViewUrl],    [WrapperType],    [Kind],    [PrimaryGenreName],    [Country],    [Currency],    [CollectionId],    [CollectionName]");
            Sql("CREATE UNIQUE CLUSTERED INDEX idx_ClickSummary ON ClickSummary([CollectionId], TrackId)");
        }

        public override void Down()
        {
            Sql("DROP VIEW [dbo].[ClickSummary]");

            AlterColumn("dbo.Clicks", "CollectionId", c => c.String());
            AlterColumn("dbo.Clicks", "TrackId", c => c.String());
        }
    }
}
