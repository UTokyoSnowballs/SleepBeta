namespace SleepMakeSense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tst1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Userdatas", "WakeUpFreshness", c => c.String());
            AddColumn("dbo.Userdatas", "Coffee", c => c.String());
            AddColumn("dbo.Userdatas", "CoffeeTime", c => c.String());
            AddColumn("dbo.Userdatas", "Alcohol", c => c.String());
            AddColumn("dbo.Userdatas", "Mood", c => c.String());
            AddColumn("dbo.Userdatas", "Stress", c => c.String());
            AddColumn("dbo.Userdatas", "Tiredness", c => c.String());
            AddColumn("dbo.Userdatas", "Dream", c => c.String());
            AddColumn("dbo.Userdatas", "DigitalDev", c => c.String());
            AddColumn("dbo.Userdatas", "Light", c => c.String());
            AddColumn("dbo.Userdatas", "NapDuration", c => c.String());
            AddColumn("dbo.Userdatas", "NapTime", c => c.String());
            AddColumn("dbo.Userdatas", "SocialActivity", c => c.String());
            AddColumn("dbo.Userdatas", "DinnerTime", c => c.String());
            AddColumn("dbo.Userdatas", "AmbientTemp", c => c.String());
            AddColumn("dbo.Userdatas", "AmbientHumd", c => c.String());
            AddColumn("dbo.Userdatas", "ExerciseTime", c => c.String());
            AddColumn("dbo.Userdatas", "BodyTemp", c => c.String());
            AddColumn("dbo.Userdatas", "Hormone", c => c.String());
            DropColumn("dbo.Userdatas", "Floors");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Userdatas", "Floors", c => c.String());
            DropColumn("dbo.Userdatas", "Hormone");
            DropColumn("dbo.Userdatas", "BodyTemp");
            DropColumn("dbo.Userdatas", "ExerciseTime");
            DropColumn("dbo.Userdatas", "AmbientHumd");
            DropColumn("dbo.Userdatas", "AmbientTemp");
            DropColumn("dbo.Userdatas", "DinnerTime");
            DropColumn("dbo.Userdatas", "SocialActivity");
            DropColumn("dbo.Userdatas", "NapTime");
            DropColumn("dbo.Userdatas", "NapDuration");
            DropColumn("dbo.Userdatas", "Light");
            DropColumn("dbo.Userdatas", "DigitalDev");
            DropColumn("dbo.Userdatas", "Dream");
            DropColumn("dbo.Userdatas", "Tiredness");
            DropColumn("dbo.Userdatas", "Stress");
            DropColumn("dbo.Userdatas", "Mood");
            DropColumn("dbo.Userdatas", "Alcohol");
            DropColumn("dbo.Userdatas", "CoffeeTime");
            DropColumn("dbo.Userdatas", "Coffee");
            DropColumn("dbo.Userdatas", "WakeUpFreshness");
        }
    }
}
