namespace Demo.XBanking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConfigurationEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configurations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Version = c.String(),
                        SetupDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Configurations");
        }
    }
}
