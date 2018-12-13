namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employerAndEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Employer_EmployerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "Employer_EmployerId");
            AddForeignKey("dbo.Employees", "Employer_EmployerId", "dbo.Employers", "EmployerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Employer_EmployerId", "dbo.Employers");
            DropIndex("dbo.Employees", new[] { "Employer_EmployerId" });
            DropColumn("dbo.Employees", "Employer_EmployerId");
        }
    }
}
