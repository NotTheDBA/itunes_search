namespace SearchSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Searches",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Term = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Searches");
        }
    }
}
