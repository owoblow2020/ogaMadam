namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAspNetUserRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "igr_collections.aspnetuserroles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
        }
        
        public override void Down()
        {
            DropTable("igr_collections.aspnetuserroles");
        }
    }
}
