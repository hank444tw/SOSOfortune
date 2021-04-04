namespace SOSOfortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 128, fixedLength: true, unicode: false),
                        Email = c.String(nullable: false, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 10, unicode: false),
                        Mem_id = c.String(nullable: false, unicode: false),
                        Mem_password = c.String(nullable: false, unicode: false),
                        Mem_guid = c.String(nullable: false, unicode: false),
                        Admin = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Member");
        }
    }
}
