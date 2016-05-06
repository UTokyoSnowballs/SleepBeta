namespace SleepMakeSense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Userdatas", "DateStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Userdatas", "Water", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Userdatas", "Water");
            DropColumn("dbo.Userdatas", "DateStamp");
        }
    }
}
