namespace SleepMakeSense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {          
            
            CreateTable(
                "dbo.Userdatas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateStamp = c.DateTime(nullable: false),
                        MinutesAsleep = c.Double(),
                        MinutesAwake = c.Double(),
                        AwakeningsCount = c.Double(),
                        TimeInBed = c.Double(),
                        MinutesToFallAsleep = c.Double(),
                        MinutesAfterWakeup = c.Double(),
                        SleepEfficiency = c.Double(),
                        CaloriesIn = c.Double(),
                        Water = c.Double(),
                        CaloriesOut = c.Double(),
                        Steps = c.Double(),
                        Distance = c.Double(),
                        MinutesSedentary = c.Double(),
                        MinutesLightlyActive = c.Double(),
                        MinutesFairlyActive = c.Double(),
                        MinutesVeryActive = c.Double(),
                        ActivityCalories = c.Double(),
                        TimeEnteredBed = c.Time(precision: 7),
                        Weight = c.Double(),
                        BMI = c.Double(),
                        Fat = c.Double(),
                        WakeUpFreshness = c.Double(),
                        Mood = c.Double(),
                        Stress = c.Double(),
                        Tiredness = c.Double(),
                        Dream = c.Double(),
                        BodyTemp = c.Double(),
                        Hormone = c.Double(),
                        SchoolStress = c.Double(),
                        CoffeeAmt = c.Double(),
                        CoffeeTime = c.DateTime(),
                        AlcoholAmt = c.Double(),
                        AlcoholTime = c.DateTime(),
                        NapTime = c.DateTime(),
                        NapDuration = c.Double(),
                        DigDeviceDuration = c.Double(),
                        GamesDuration = c.Double(),
                        SocialActivites = c.Double(),
                        SocialActivity = c.Double(),
                        MusicDuration = c.Double(),
                        TVDuration = c.Double(),
                        WorkTime = c.DateTime(),
                        WorkDuration = c.Double(),
                        ExerciseDuration = c.Double(),
                        ExerciseIntensity = c.Double(),
                        DinnerTime = c.DateTime(),
                        SnackTime = c.DateTime(),
                        AmbientTemp = c.Double(),
                        AmbientHumd = c.Double(),
                        Light = c.Double(),
                        SunRiseTime = c.DateTime(),
                        SunSetTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Userdatas");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
