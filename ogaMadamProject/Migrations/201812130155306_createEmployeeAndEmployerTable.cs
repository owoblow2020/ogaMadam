namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createEmployeeAndEmployerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                        BVN = c.String(),
                        NIMC = c.String(),
                        ImageId = c.String(),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        EmployerId = c.String(nullable: false, maxLength: 128),
                        ImageId = c.String(),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmployerId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployerId)
                .Index(t => t.EmployerId);
            
            AddColumn("dbo.AspNetUsers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employers", "EmployerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "EmployeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Employers", new[] { "EmployerId" });
            DropIndex("dbo.Employees", new[] { "EmployeeId" });
            DropColumn("dbo.AspNetUsers", "Status");
            DropTable("dbo.Employers");
            DropTable("dbo.Employees");
        }
    }
}
