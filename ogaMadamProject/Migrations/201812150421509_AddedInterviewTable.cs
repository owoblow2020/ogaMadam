namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInterviewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        InterviewId = c.String(nullable: false, maxLength: 128),
                        Score = c.Int(nullable: false),
                        IsPassed = c.Boolean(nullable: false),
                        Description = c.String(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InterviewId)
                .ForeignKey("dbo.Employees", t => t.InterviewId)
                .Index(t => t.InterviewId);
            
            AddColumn("dbo.Employees", "IsInterviewed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interviews", "InterviewId", "dbo.Employees");
            DropIndex("dbo.Interviews", new[] { "InterviewId" });
            DropColumn("dbo.Employees", "IsInterviewed");
            DropTable("dbo.Interviews");
        }
    }
}
