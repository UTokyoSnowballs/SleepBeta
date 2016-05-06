namespace SleepMakeSense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tst : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Userdatas", "MinutesAwake", c => c.String());
            AddColumn("dbo.Userdatas", "TimeInBed", c => c.String());
            AddColumn("dbo.Userdatas", "MinutesToFallAsleep", c => c.String());
            AddColumn("dbo.Userdatas", "MinutesAfterWakeup", c => c.String());
            AddColumn("dbo.Userdatas", "SleepEfficienty", c => c.String());
            AddColumn("dbo.Userdatas", "CaloriesIn", c => c.String());
            AddColumn("dbo.Userdatas", "CaloriesOut", c => c.String());
            AddColumn("dbo.Userdatas", "MinutesLightlyActive", c => c.String());
            AddColumn("dbo.Userdatas", "MinutesFairlyActive", c => c.String());
            AddColumn("dbo.Userdatas", "ActivityCalories", c => c.String());
            AddColumn("dbo.Userdatas", "BMI", c => c.String());
            AddColumn("dbo.Userdatas", "Fat", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Userdatas", "Fat");
            DropColumn("dbo.Userdatas", "BMI");
            DropColumn("dbo.Userdatas", "ActivityCalories");
            DropColumn("dbo.Userdatas", "MinutesFairlyActive");
            DropColumn("dbo.Userdatas", "MinutesLightlyActive");
            DropColumn("dbo.Userdatas", "CaloriesOut");
            DropColumn("dbo.Userdatas", "CaloriesIn");
            DropColumn("dbo.Userdatas", "SleepEfficienty");
            DropColumn("dbo.Userdatas", "MinutesAfterWakeup");
            DropColumn("dbo.Userdatas", "MinutesToFallAsleep");
            DropColumn("dbo.Userdatas", "TimeInBed");
            DropColumn("dbo.Userdatas", "MinutesAwake");
        }
    }
}
