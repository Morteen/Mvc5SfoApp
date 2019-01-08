namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleted_Colums_In_SjekkInnLogVol3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SjekkInLoggs", "SjekkInn", c => c.String());
            AlterColumn("dbo.SjekkInLoggs", "SjekkUt", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SjekkInLoggs", "SjekkUt", c => c.DateTime());
            AlterColumn("dbo.SjekkInLoggs", "SjekkInn", c => c.DateTime());
        }
    }
}
