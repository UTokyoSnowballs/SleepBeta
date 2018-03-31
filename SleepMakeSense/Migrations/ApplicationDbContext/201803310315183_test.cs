namespace SleepMakeSense.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserQuestions", "PerFactor1Name", c => c.String());
            AddColumn("dbo.UserQuestions", "PerFactor2Name", c => c.String());
            AddColumn("dbo.UserQuestions", "PerFactor3Name", c => c.String());
            AddColumn("dbo.UserQuestions", "PerFactor4Name", c => c.String());
            AddColumn("dbo.UserQuestions", "PerFactor5Name", c => c.String());
            AddColumn("dbo.UserQuestions", "PerFactor6Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserQuestions", "PerFactor6Name");
            DropColumn("dbo.UserQuestions", "PerFactor5Name");
            DropColumn("dbo.UserQuestions", "PerFactor4Name");
            DropColumn("dbo.UserQuestions", "PerFactor3Name");
            DropColumn("dbo.UserQuestions", "PerFactor2Name");
            DropColumn("dbo.UserQuestions", "PerFactor1Name");
        }
    }
}
