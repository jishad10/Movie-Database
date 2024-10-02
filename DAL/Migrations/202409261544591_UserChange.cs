namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Users", "PasswordHash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PasswordHash", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Users", "Password");
        }
    }
}
