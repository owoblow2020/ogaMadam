namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Employees", "CategoryId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "CategoryId");
            AddForeignKey("dbo.Employees", "CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Employees", new[] { "CategoryId" });
            DropColumn("dbo.Employees", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
