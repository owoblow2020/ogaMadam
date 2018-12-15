namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedAllTableAddCreatedBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "EmployeeId", c => c.String(maxLength: 128));
            AddColumn("dbo.Reports", "Description", c => c.String());
            AddColumn("dbo.Reports", "CreatedBy", c => c.String());
            AddColumn("dbo.Reports", "ModifiedBy", c => c.String());
            AddColumn("dbo.Reports", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Reviews", "EmployerId", c => c.String(maxLength: 128));
            AddColumn("dbo.Reviews", "Description", c => c.String());
            AddColumn("dbo.Trainings", "Description", c => c.String());
            AddColumn("dbo.Trainings", "TrainingStartDate", c => c.DateTime());
            AddColumn("dbo.Trainings", "TrainingEndDate", c => c.DateTime());
            AddColumn("dbo.Trainings", "CreatedBy", c => c.String());
            AddColumn("dbo.Trainings", "ModifiedBy", c => c.String());
            AddColumn("dbo.Trainings", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Verifications", "CreatedBy", c => c.String());
            AddColumn("dbo.Verifications", "ModifiedBy", c => c.String());
            AddColumn("dbo.Verifications", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Notifications", "CreatedBy", c => c.String());
            AddColumn("dbo.Notifications", "ModifiedBy", c => c.String());
            AddColumn("dbo.Notifications", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Reports", "ReportType", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "EmployerId");
            CreateIndex("dbo.Transactions", "EmployeeId");
            AddForeignKey("dbo.Reviews", "EmployerId", "dbo.Employers", "EmployerId");
            AddForeignKey("dbo.Transactions", "EmployeeId", "dbo.Employees", "EmployeeId");
            DropColumn("dbo.Reports", "Details");
            DropColumn("dbo.Reviews", "Details");
            DropColumn("dbo.Trainings", "TrainingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainings", "TrainingDate", c => c.DateTime());
            AddColumn("dbo.Reviews", "Details", c => c.String());
            AddColumn("dbo.Reports", "Details", c => c.String());
            DropForeignKey("dbo.Transactions", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Reviews", "EmployerId", "dbo.Employers");
            DropIndex("dbo.Transactions", new[] { "EmployeeId" });
            DropIndex("dbo.Reviews", new[] { "EmployerId" });
            AlterColumn("dbo.Reports", "ReportType", c => c.String());
            DropColumn("dbo.Notifications", "ModifiedDate");
            DropColumn("dbo.Notifications", "ModifiedBy");
            DropColumn("dbo.Notifications", "CreatedBy");
            DropColumn("dbo.Verifications", "ModifiedDate");
            DropColumn("dbo.Verifications", "ModifiedBy");
            DropColumn("dbo.Verifications", "CreatedBy");
            DropColumn("dbo.Trainings", "ModifiedDate");
            DropColumn("dbo.Trainings", "ModifiedBy");
            DropColumn("dbo.Trainings", "CreatedBy");
            DropColumn("dbo.Trainings", "TrainingEndDate");
            DropColumn("dbo.Trainings", "TrainingStartDate");
            DropColumn("dbo.Trainings", "Description");
            DropColumn("dbo.Reviews", "Description");
            DropColumn("dbo.Reviews", "EmployerId");
            DropColumn("dbo.Reports", "ModifiedDate");
            DropColumn("dbo.Reports", "ModifiedBy");
            DropColumn("dbo.Reports", "CreatedBy");
            DropColumn("dbo.Reports", "Description");
            DropColumn("dbo.Transactions", "EmployeeId");
        }
    }
}
