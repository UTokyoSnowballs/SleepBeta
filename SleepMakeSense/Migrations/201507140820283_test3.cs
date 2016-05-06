namespace SleepMakeSense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Userdatas", "Distance", c => c.String());
            AddColumn("dbo.Userdatas", "MinutesSedentary", c => c.String());
            AddColumn("dbo.Userdatas", "MinutesVeryActive", c => c.String());
            AddColumn("dbo.Userdatas", "Floors", c => c.String());
            AddColumn("dbo.Userdatas", "AwakeningsCount", c => c.String());
            AddColumn("dbo.Userdatas", "TimeEnteredBed", c => c.String());
            AddColumn("dbo.Userdatas", "Weight", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Userdatas", "Weight");
            DropColumn("dbo.Userdatas", "TimeEnteredBed");
            DropColumn("dbo.Userdatas", "AwakeningsCount");
            DropColumn("dbo.Userdatas", "Floors");
            DropColumn("dbo.Userdatas", "MinutesVeryActive");
            DropColumn("dbo.Userdatas", "MinutesSedentary");
            DropColumn("dbo.Userdatas", "Distance");
        }
    }
}
