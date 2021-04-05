namespace SOSOfortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editGuidAdmin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "Mem_guid", c => c.String(unicode: false));
            AlterColumn("dbo.Member", "Admin", c => c.String(maxLength: 1, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "Admin", c => c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false));
            AlterColumn("dbo.Member", "Mem_guid", c => c.String(nullable: false, unicode: false));
        }
    }
}
