namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEmployeeWithAccount : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reports", name: "Employee_EmployeeId", newName: "EmployeeId");
            RenameIndex(table: "dbo.Reports", name: "IX_Employee_EmployeeId", newName: "IX_EmployeeId");
            AddColumn("dbo.AspNetUsers", "AccountStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "IsAttachedApproved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "AttachedDate", c => c.DateTime());
            AddColumn("dbo.Employees", "BankName", c => c.String());
            AddColumn("dbo.Employees", "AccountName", c => c.String());
            AddColumn("dbo.Employees", "AccountNumber", c => c.String());
            AddColumn("dbo.Employees", "SalaryAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Employees", "IsUserVerified", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "IsTrained", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "QualificationType", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "CreatedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "Status");
            DropColumn("dbo.AspNetUsers", "IsUserVerified");
            DropColumn("dbo.Employees", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ImageId", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsUserVerified", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "CreatedAt", c => c.DateTime());
            DropColumn("dbo.Employees", "QualificationType");
            DropColumn("dbo.Employees", "IsTrained");
            DropColumn("dbo.Employees", "IsUserVerified");
            DropColumn("dbo.Employees", "SalaryAmount");
            DropColumn("dbo.Employees", "AccountNumber");
            DropColumn("dbo.Employees", "AccountName");
            DropColumn("dbo.Employees", "BankName");
            DropColumn("dbo.Employees", "AttachedDate");
            DropColumn("dbo.Employees", "IsAttachedApproved");
            DropColumn("dbo.AspNetUsers", "AccountStatus");
            RenameIndex(table: "dbo.Reports", name: "IX_EmployeeId", newName: "IX_Employee_EmployeeId");
            RenameColumn(table: "dbo.Reports", name: "EmployeeId", newName: "Employee_EmployeeId");
        }
    }
}
