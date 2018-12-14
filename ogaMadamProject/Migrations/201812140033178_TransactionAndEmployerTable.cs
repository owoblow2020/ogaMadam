namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionAndEmployerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.String(nullable: false, maxLength: 128),
                        TransactionDate = c.DateTime(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentCategory = c.String(),
                        PaymentStatus = c.Int(nullable: false),
                        PaymentChannel = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Employer_EmployerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Employers", t => t.Employer_EmployerId)
                .Index(t => t.Employer_EmployerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Employer_EmployerId", "dbo.Employers");
            DropIndex("dbo.Transactions", new[] { "Employer_EmployerId" });
            DropTable("dbo.Transactions");
        }
    }
}
