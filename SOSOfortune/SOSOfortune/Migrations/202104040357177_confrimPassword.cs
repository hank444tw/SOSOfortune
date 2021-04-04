namespace SOSOfortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confrimPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "Mem_confirmPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Member", "Mem_confirmPassword");
        }
    }
}
