namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewandEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.String(nullable: false, maxLength: 128),
                        Details = c.String(),
                        Star = c.Int(),
                        CreatedAt = c.DateTime(nullable: false),
                        Employee_EmployeeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Employee_EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Reviews", new[] { "Employee_EmployeeId" });
            DropTable("dbo.Reviews");
        }
    }
}
