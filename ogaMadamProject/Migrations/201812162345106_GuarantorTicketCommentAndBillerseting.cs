namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuarantorTicketCommentAndBillerseting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApiSettings",
                c => new
                    {
                        ApiSettingId = c.String(nullable: false, maxLength: 128),
                        BillerSettingId = c.String(maxLength: 128),
                        Uri = c.String(),
                        Token = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Mode = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ApiSettingId)
                .ForeignKey("dbo.BillerSettings", t => t.BillerSettingId)
                .Index(t => t.BillerSettingId);
            
            CreateTable(
                "dbo.BillerSettings",
                c => new
                    {
                        BillerId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BillerId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.String(nullable: false, maxLength: 128),
                        TicketId = c.String(maxLength: 128),
                        AspNetUserId = c.String(maxLength: 128),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .ForeignKey("dbo.Tickets", t => t.TicketId)
                .Index(t => t.TicketId)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.String(nullable: false, maxLength: 128),
                        AspNetUserId = c.String(maxLength: 128),
                        Title = c.String(),
                        Description = c.String(),
                        status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.Guarantors",
                c => new
                    {
                        GuarantorId = c.String(nullable: false, maxLength: 128),
                        EmployeeId = c.String(maxLength: 128),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        PlaceOfWork = c.String(),
                    })
                .PrimaryKey(t => t.GuarantorId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guarantors", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Comments", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApiSettings", "BillerSettingId", "dbo.BillerSettings");
            DropIndex("dbo.Guarantors", new[] { "EmployeeId" });
            DropIndex("dbo.Tickets", new[] { "AspNetUserId" });
            DropIndex("dbo.Comments", new[] { "AspNetUserId" });
            DropIndex("dbo.Comments", new[] { "TicketId" });
            DropIndex("dbo.ApiSettings", new[] { "BillerSettingId" });
            DropTable("dbo.Guarantors");
            DropTable("dbo.Tickets");
            DropTable("dbo.Comments");
            DropTable("dbo.BillerSettings");
            DropTable("dbo.ApiSettings");
        }
    }
}
