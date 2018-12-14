namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainingAndEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        TrainingId = c.String(nullable: false, maxLength: 128),
                        TrainingType = c.String(),
                        TrainingDate = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                        Employee_EmployeeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TrainingId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Employee_EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainings", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Trainings", new[] { "Employee_EmployeeId" });
            DropTable("dbo.Trainings");
        }
    }
}
