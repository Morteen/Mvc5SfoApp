namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleted_Colums_In_SjekkInnLogVol2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SjekkInLoggs", "SjekkInn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SjekkInLoggs", "SjekkInn", c => c.DateTime(nullable: false));
        }
    }
}
