namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUploadTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uploads",
                c => new
                    {
                        UploadId = c.String(nullable: false, maxLength: 128),
                        AspNetUserId = c.String(maxLength: 128),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UploadId)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
            AddColumn("dbo.Notifications", "Description", c => c.String());
            DropColumn("dbo.Notifications", "Details");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "Details", c => c.String());
            DropForeignKey("dbo.Uploads", "AspNetUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Uploads", new[] { "AspNetUserId" });
            DropColumn("dbo.Notifications", "Description");
            DropTable("dbo.Uploads");
        }
    }
}
