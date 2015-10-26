namespace Demo.XBanking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReleaseNotesOnConfigurationEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configurations", "ReleaseNotes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configurations", "ReleaseNotes");
        }
    }
}
