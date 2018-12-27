namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedSalaryWithTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salaries", "StartDate", c => c.DateTime());
            AddColumn("dbo.Salaries", "EndDate", c => c.DateTime());
            CreateIndex("dbo.Salaries", "SalaryId");
            AddForeignKey("dbo.Salaries", "SalaryId", "dbo.Transactions", "TransactionId");
            DropColumn("dbo.Salaries", "Day");
            DropColumn("dbo.Salaries", "Month");
            DropColumn("dbo.Salaries", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salaries", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "Day", c => c.Int(nullable: false));
            DropForeignKey("dbo.Salaries", "SalaryId", "dbo.Transactions");
            DropIndex("dbo.Salaries", new[] { "SalaryId" });
            DropColumn("dbo.Salaries", "EndDate");
            DropColumn("dbo.Salaries", "StartDate");
        }
    }
}
