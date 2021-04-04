namespace SOSOfortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBirthday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Member", "Birthday");
        }
    }
}
