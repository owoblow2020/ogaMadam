namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedEmployer : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Notifications", name: "AspNetUser_Id", newName: "AspNetUserId");
            RenameColumn(table: "dbo.Employees", name: "Employer_EmployerId", newName: "EmployerId");
            RenameColumn(table: "dbo.Reviews", name: "Employee_EmployeeId", newName: "EmployeeId");
            RenameColumn(table: "dbo.Trainings", name: "Employee_EmployeeId", newName: "EmployeeId");
            RenameColumn(table: "dbo.Verifications", name: "Employee_EmployeeId", newName: "EmployeeId");
            RenameColumn(table: "dbo.Transactions", name: "Employer_EmployerId", newName: "EmployerId");
            RenameIndex(table: "dbo.Employees", name: "IX_Employer_EmployerId", newName: "IX_EmployerId");
            RenameIndex(table: "dbo.Transactions", name: "IX_Employer_EmployerId", newName: "IX_EmployerId");
            RenameIndex(table: "dbo.Reviews", name: "IX_Employee_EmployeeId", newName: "IX_EmployeeId");
            RenameIndex(table: "dbo.Trainings", name: "IX_Employee_EmployeeId", newName: "IX_EmployeeId");
            RenameIndex(table: "dbo.Verifications", name: "IX_Employee_EmployeeId", newName: "IX_EmployeeId");
            RenameIndex(table: "dbo.Notifications", name: "IX_AspNetUser_Id", newName: "IX_AspNetUserId");
            AddColumn("dbo.Employers", "PlaceOfWork", c => c.String());
            AddColumn("dbo.Employers", "EmploymentIdNumber", c => c.String());
            AddColumn("dbo.Employers", "NextOfKin", c => c.String());
            AddColumn("dbo.Employers", "NextOfKinPhoneNumber", c => c.String());
            AddColumn("dbo.Employers", "NextOfKinAddress", c => c.String());
            AddColumn("dbo.Employers", "Profession", c => c.String());
            DropColumn("dbo.Employers", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employers", "ImageId", c => c.String());
            DropColumn("dbo.Employers", "Profession");
            DropColumn("dbo.Employers", "NextOfKinAddress");
            DropColumn("dbo.Employers", "NextOfKinPhoneNumber");
            DropColumn("dbo.Employers", "NextOfKin");
            DropColumn("dbo.Employers", "EmploymentIdNumber");
            DropColumn("dbo.Employers", "PlaceOfWork");
            RenameIndex(table: "dbo.Notifications", name: "IX_AspNetUserId", newName: "IX_AspNetUser_Id");
            RenameIndex(table: "dbo.Verifications", name: "IX_EmployeeId", newName: "IX_Employee_EmployeeId");
            RenameIndex(table: "dbo.Trainings", name: "IX_EmployeeId", newName: "IX_Employee_EmployeeId");
            RenameIndex(table: "dbo.Reviews", name: "IX_EmployeeId", newName: "IX_Employee_EmployeeId");
            RenameIndex(table: "dbo.Transactions", name: "IX_EmployerId", newName: "IX_Employer_EmployerId");
            RenameIndex(table: "dbo.Employees", name: "IX_EmployerId", newName: "IX_Employer_EmployerId");
            RenameColumn(table: "dbo.Transactions", name: "EmployerId", newName: "Employer_EmployerId");
            RenameColumn(table: "dbo.Verifications", name: "EmployeeId", newName: "Employee_EmployeeId");
            RenameColumn(table: "dbo.Trainings", name: "EmployeeId", newName: "Employee_EmployeeId");
            RenameColumn(table: "dbo.Reviews", name: "EmployeeId", newName: "Employee_EmployeeId");
            RenameColumn(table: "dbo.Employees", name: "EmployerId", newName: "Employer_EmployerId");
            RenameColumn(table: "dbo.Notifications", name: "AspNetUserId", newName: "AspNetUser_Id");
        }
    }
}
