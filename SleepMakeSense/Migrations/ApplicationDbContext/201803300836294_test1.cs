namespace SleepMakeSense.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiaryDatas", "Noise", c => c.String());
            AddColumn("dbo.DiaryDatas", "Cleanliness", c => c.String());
            AddColumn("dbo.DiaryDatas", "Medication", c => c.String());
            AddColumn("dbo.DiaryDatas", "PerFactor1", c => c.String());
            AddColumn("dbo.DiaryDatas", "PerFactor2", c => c.String());
            AddColumn("dbo.DiaryDatas", "PerFactor3", c => c.String());
            AddColumn("dbo.DiaryDatas", "PerFactor4", c => c.String());
            AddColumn("dbo.DiaryDatas", "PerFactor5", c => c.String());
            AddColumn("dbo.DiaryDatas", "PerFactor6", c => c.String());
            AddColumn("dbo.UserQuestions", "TempQuestion", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserQuestions", "LightQuestion", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserQuestions", "NoiseQuestion", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserQuestions", "CleanlinessQuestion", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserQuestions", "MedicationQuestion", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserQuestions", "PerFactor1Question", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserQuestions", "PerFactor2Question", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserQuestions", "PerFactor3Question", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserQuestions", "PerFactor4Question", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserQuestions", "PerFactor5Question", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserQuestions", "PerFactor6Question", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserQuestions", "PerFactor6Question");
            DropColumn("dbo.UserQuestions", "PerFactor5Question");
            DropColumn("dbo.UserQuestions", "PerFactor4Question");
            DropColumn("dbo.UserQuestions", "PerFactor3Question");
            DropColumn("dbo.UserQuestions", "PerFactor2Question");
            DropColumn("dbo.UserQuestions", "PerFactor1Question");
            DropColumn("dbo.UserQuestions", "MedicationQuestion");
            DropColumn("dbo.UserQuestions", "CleanlinessQuestion");
            DropColumn("dbo.UserQuestions", "NoiseQuestion");
            DropColumn("dbo.UserQuestions", "LightQuestion");
            DropColumn("dbo.UserQuestions", "TempQuestion");
            DropColumn("dbo.DiaryDatas", "PerFactor6");
            DropColumn("dbo.DiaryDatas", "PerFactor5");
            DropColumn("dbo.DiaryDatas", "PerFactor4");
            DropColumn("dbo.DiaryDatas", "PerFactor3");
            DropColumn("dbo.DiaryDatas", "PerFactor2");
            DropColumn("dbo.DiaryDatas", "PerFactor1");
            DropColumn("dbo.DiaryDatas", "Medication");
            DropColumn("dbo.DiaryDatas", "Cleanliness");
            DropColumn("dbo.DiaryDatas", "Noise");
        }
    }
}
