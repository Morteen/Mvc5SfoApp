namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_username_and_password_to_Ansatt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ansatts", "Username", c => c.String());
            AddColumn("dbo.Ansatts", "Password", c => c.String(maxLength: 18));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ansatts", "Password");
            DropColumn("dbo.Ansatts", "Username");
        }
    }
}
