namespace EmployeesSoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Username", c => c.String(maxLength: 4000));
            AddColumn("dbo.Users", "Password", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Username");
        }
    }
}
