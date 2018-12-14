namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VerificationAndEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Verifications",
                c => new
                    {
                        VerificationId = c.String(nullable: false, maxLength: 128),
                        VerificationType = c.Int(nullable: false),
                        IsVerify = c.Boolean(nullable: false),
                        VerifyDate = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                        Employee_EmployeeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VerificationId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Employee_EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Verifications", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Verifications", new[] { "Employee_EmployeeId" });
            DropTable("dbo.Verifications");
        }
    }
}
