namespace SleepMakeSense.Migrations.SleepbetaDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            /*
            CreateTable(
                "dbo.DiaryDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AspNetUserId = c.String(maxLength: 128),
                        DateStamp = c.DateTime(nullable: false),
                        WakeUpFreshness = c.String(),
                        Mood = c.String(),
                        Stress = c.String(),
                        Tiredness = c.String(),
                        Dream = c.String(),
                        BodyTemp = c.String(),
                        Hormone = c.String(),
                        SchoolStress = c.String(),
                        CoffeeAmt = c.String(),
                        CoffeeTime = c.String(),
                        AlcoholAmt = c.String(),
                        AlcoholTime = c.String(),
                        NapTime = c.String(),
                        NapDuration = c.String(),
                        DigDeviceDuration = c.String(),
                        GamesDuration = c.String(),
                        SocialFamily = c.String(),
                        SocialFriend = c.String(),
                        MusicDuration = c.String(),
                        TVDuration = c.String(),
                        WorkTime = c.String(),
                        WorkDuration = c.String(),
                        ExerciseDuration = c.String(),
                        ExerciseIntensity = c.String(),
                        DinnerTime = c.String(),
                        SnackTime = c.String(),
                        AmbientHumd = c.String(),
                        SunRiseTime = c.String(),
                        SunSetTime = c.String(),
                        SocialMedia = c.String(),
                        AmbientTemp = c.String(),
                        Light = c.String(),
                        Noise = c.String(),
                        Cleanliness = c.String(),
                        Medication = c.String(),
                        PerFactor1 = c.String(),
                        PerFactor2 = c.String(),
                        PerFactor3 = c.String(),
                        PerFactor4 = c.String(),
                        PerFactor5 = c.String(),
                        PerFactor6 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FitbitDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AspNetUserId = c.String(maxLength: 128),
                        DateStamp = c.DateTime(nullable: false),
                        SleepEfficiency = c.String(),
                        TimeEnteredBed = c.String(),
                        MinutesAsleep = c.String(),
                        MinutesAwake = c.String(),
                        TimeInBed = c.String(),
                        AwakeningsCount = c.String(),
                        MinutesToFallAsleep = c.String(),
                        MinutesAfterWakeup = c.String(),
                        Steps = c.String(),
                        Distance = c.String(),
                        MinutesSedentary = c.String(),
                        MinutesLightlyActive = c.String(),
                        MinutesFairlyActive = c.String(),
                        MinutesVeryActive = c.String(),
                        Water = c.String(),
                        CaloriesIn = c.String(),
                        CaloriesOut = c.String(),
                        ActivityCalories = c.String(),
                        Weight = c.String(),
                        BMI = c.String(),
                        Fat = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.TokenManagements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AspNetUserId = c.String(maxLength: 128),
                        Token = c.String(),
                        TokenType = c.String(),
                        ExpiresIn = c.Int(nullable: false),
                        RefreshToken = c.String(),
                        DateChanged = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.UserQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AspNetUserId = c.String(maxLength: 128),
                        WakeUpFreshness = c.Boolean(nullable: false),
                        Mood = c.Boolean(nullable: false),
                        Stress = c.Boolean(nullable: false),
                        Tiredness = c.Boolean(nullable: false),
                        Dream = c.Boolean(nullable: false),
                        SchoolQuestions = c.Boolean(nullable: false),
                        CoffeeQuestions = c.Boolean(nullable: false),
                        AlcoholQuestions = c.Boolean(nullable: false),
                        NapQuestions = c.Boolean(nullable: false),
                        DigDeviceDurationQuestion = c.Boolean(nullable: false),
                        GameDurationQuestion = c.Boolean(nullable: false),
                        SocialMediaDurationQuestion = c.Boolean(nullable: false),
                        SocialActivityDurationQuestion = c.Boolean(nullable: false),
                        MusicDurationQuestion = c.Boolean(nullable: false),
                        TVDurationQuestion = c.Boolean(nullable: false),
                        WorkQuestions = c.Boolean(nullable: false),
                        ExersiseQuestions = c.Boolean(nullable: false),
                        FoodQuestions = c.Boolean(nullable: false),
                        GenderHormoneQuestion = c.Boolean(nullable: false),
                        TempQuestion = c.Boolean(nullable: false),
                        LightQuestion = c.Boolean(nullable: false),
                        NoiseQuestion = c.Boolean(nullable: false),
                        CleanlinessQuestion = c.Boolean(nullable: false),
                        MedicationQuestion = c.Boolean(nullable: false),
                        PerFactor1Question = c.Boolean(nullable: false),
                        PerFactor1Name = c.String(),
                        PerFactor2Question = c.Boolean(nullable: false),
                        PerFactor2Name = c.String(),
                        PerFactor3Question = c.Boolean(nullable: false),
                        PerFactor3Name = c.String(),
                        PerFactor4Question = c.Boolean(nullable: false),
                        PerFactor4Name = c.String(),
                        PerFactor5Question = c.Boolean(nullable: false),
                        PerFactor5Name = c.String(),
                        PerFactor6Question = c.Boolean(nullable: false),
                        PerFactor6Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);*/
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiaryDatas", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserQuestions", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TokenManagements", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FitbitDatas", "AspNetUserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserQuestions", new[] { "AspNetUserId" });
            DropIndex("dbo.TokenManagements", new[] { "AspNetUserId" });
            DropIndex("dbo.FitbitDatas", new[] { "AspNetUserId" });
            DropIndex("dbo.DiaryDatas", new[] { "AspNetUserId" });
            DropTable("dbo.UserQuestions");
            DropTable("dbo.TokenManagements");
            DropTable("dbo.FitbitDatas");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.DiaryDatas");
        }
    }
}
