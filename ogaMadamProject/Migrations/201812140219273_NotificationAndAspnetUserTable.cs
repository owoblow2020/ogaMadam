namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotificationAndAspnetUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.String(nullable: false, maxLength: 128),
                        Details = c.String(),
                        IsRead = c.Boolean(nullable: false),
                        NotificationDate = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "AspNetUser_Id" });
            DropTable("dbo.Notifications");
        }
    }
}
