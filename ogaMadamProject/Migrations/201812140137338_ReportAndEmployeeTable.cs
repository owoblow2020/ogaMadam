namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportAndEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.String(nullable: false, maxLength: 128),
                        ReportType = c.String(),
                        Details = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        Employee_EmployeeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Employee_EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Reports", new[] { "Employee_EmployeeId" });
            DropTable("dbo.Reports");
        }
    }
}
