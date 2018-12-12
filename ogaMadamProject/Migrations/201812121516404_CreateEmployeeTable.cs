namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        BVN = c.String(),
                        NIMC = c.String(),
                        ImageId = c.String(),
                        CreatedAt = c.DateTime(),
                        AspNetUserID_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserID_Id)
                .Index(t => t.AspNetUserID_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "AspNetUserID_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "AspNetUserID_Id" });
            DropTable("dbo.Employees");
        }
    }
}
