namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSalaryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        SalaryId = c.String(nullable: false, maxLength: 128),
                        EmployeeId = c.String(maxLength: 128),
                        EmployerId = c.String(maxLength: 128),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Day = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalaryId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Employers", t => t.EmployerId)
                .Index(t => t.EmployeeId)
                .Index(t => t.EmployerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "EmployerId", "dbo.Employers");
            DropForeignKey("dbo.Salaries", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Salaries", new[] { "EmployerId" });
            DropIndex("dbo.Salaries", new[] { "EmployeeId" });
            DropTable("dbo.Salaries");
        }
    }
}
