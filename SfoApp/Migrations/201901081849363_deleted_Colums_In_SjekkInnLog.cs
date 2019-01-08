namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleted_Colums_In_SjekkInnLog : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SjekkInLoggs", "SjekkUt", c => c.DateTime());
            DropColumn("dbo.SjekkInLoggs", "Aar");
            DropColumn("dbo.SjekkInLoggs", "Dato");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SjekkInLoggs", "Dato", c => c.DateTime(nullable: false));
            AddColumn("dbo.SjekkInLoggs", "Aar", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SjekkInLoggs", "SjekkUt", c => c.DateTime(nullable: false));
        }
    }
}
