namespace SleepMakeSense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Userdatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Steps = c.String(),
                        MinutesAsleep = c.String(),
                        DateStamp = c.DateTime(nullable: false),
                        Water = c.String(),
                        Distance = c.String(),
                        MinutesSedentary = c.String(),
                        MinutesVeryActive = c.String(),
                        AwakeningsCount = c.String(),
                        TimeEnteredBed = c.String(),
                        Weight = c.String(),
                        MinutesAwake = c.String(),
                        TimeInBed = c.String(),
                        MinutesToFallAsleep = c.String(),
                        MinutesAfterWakeup = c.String(),
                        CaloriesIn = c.String(),
                        CaloriesOut = c.String(),
                        MinutesLightlyActive = c.String(),
                        MinutesFairlyActive = c.String(),
                        ActivityCalories = c.String(),
                        BMI = c.String(),
                        Fat = c.String(),
                        SleepEfficiency = c.String(),
                        WakeUpFreshness = c.String(),
                        Coffee = c.String(),
                        CoffeeTime = c.String(),
                        Alcohol = c.String(),
                        Mood = c.String(),
                        Stress = c.String(),
                        Tiredness = c.String(),
                        Dream = c.String(),
                        DigitalDev = c.String(),
                        Light = c.String(),
                        NapDuration = c.String(),
                        NapTime = c.String(),
                        SocialActivity = c.String(),
                        DinnerTime = c.String(),
                        AmbientTemp = c.String(),
                        AmbientHumd = c.String(),
                        ExerciseTime = c.String(),
                        BodyTemp = c.String(),
                        Hormone = c.String(),
                        FitbitData = c.Boolean(nullable: false),
                        DiaryDataNight = c.Boolean(nullable: false),
                        WatchTV = c.String(),
                        ExerciseDuration = c.String(),
                        ExerciseIntensity = c.String(),
                        ExerciseType = c.String(),
                        Snack = c.String(),
                        Snack2 = c.String(),
                        Job = c.String(),
                        Job2 = c.String(),
                        Phone = c.String(),
                        SleepDiary = c.String(),
                        Music = c.String(),
                        MusicDuration = c.String(),
                        MusicType = c.String(),
                        SocialMedia = c.String(),
                        Games = c.String(),
                        Assessment = c.String(),
                        AspNetUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.Table",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TokenManagements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(nullable: false),
                        TokenType = c.String(nullable: false),
                        ExpiresIn = c.Int(nullable: false),
                        RefreshToken = c.String(nullable: false),
                        UserId = c.String(),
                        AspNetUserId = c.String(nullable: false, maxLength: 128),
                        DateChanged = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId, cascadeDelete: true)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.UserQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PresentInStudy = c.Boolean(nullable: false),
                        Question1 = c.Boolean(),
                        Question2 = c.Boolean(),
                        Question3 = c.Boolean(),
                        Question4 = c.Boolean(),
                        Question5 = c.Boolean(),
                        Question6 = c.Boolean(),
                        Question7 = c.Boolean(),
                        Question8 = c.Boolean(),
                        Question9 = c.Boolean(),
                        Question10 = c.Boolean(),
                        Question11 = c.Boolean(),
                        Question12 = c.Boolean(),
                        Question13 = c.Boolean(),
                        Question14 = c.Boolean(),
                        Question15 = c.Boolean(),
                        Question16 = c.Boolean(),
                        Question17 = c.Boolean(),
                        Question18 = c.Boolean(),
                        Question19 = c.Boolean(),
                        Question20 = c.Boolean(),
                        AspNetUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId, cascadeDelete: true)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserQuestions", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TokenManagements", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Userdatas", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserQuestions", new[] { "AspNetUserId" });
            DropIndex("dbo.TokenManagements", new[] { "AspNetUserId" });
            DropIndex("dbo.Userdatas", new[] { "AspNetUserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.UserQuestions");
            DropTable("dbo.TokenManagements");
            DropTable("dbo.Table");
            DropTable("dbo.Userdatas");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
        }
    }
}
