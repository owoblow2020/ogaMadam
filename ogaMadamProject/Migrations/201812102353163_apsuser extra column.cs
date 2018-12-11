namespace ogaMadamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apsuserextracolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "MiddleName", c => c.String());
            AddColumn("dbo.AspNetUsers", "PlaceOfBirth", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Sex", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "StateOfOrigin", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserType", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsEmailVerified", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsPhoneVerified", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsUserVerified", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CreatedAt");
            DropColumn("dbo.AspNetUsers", "IsUserVerified");
            DropColumn("dbo.AspNetUsers", "IsPhoneVerified");
            DropColumn("dbo.AspNetUsers", "IsEmailVerified");
            DropColumn("dbo.AspNetUsers", "UserType");
            DropColumn("dbo.AspNetUsers", "StateOfOrigin");
            DropColumn("dbo.AspNetUsers", "Sex");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "PlaceOfBirth");
            DropColumn("dbo.AspNetUsers", "MiddleName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
