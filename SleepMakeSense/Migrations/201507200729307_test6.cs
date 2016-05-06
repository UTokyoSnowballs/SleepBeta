namespace SleepMakeSense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Userdatas", "SleepEfficiency", c => c.String());
            DropColumn("dbo.Userdatas", "SleepEfficienty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Userdatas", "SleepEfficienty", c => c.String());
            DropColumn("dbo.Userdatas", "SleepEfficiency");
        }
    }
}
