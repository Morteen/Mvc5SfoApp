namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pop_skoler : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Skoles(SkoleNavn)VALUES('Åfoss'),('Holla 10årige Skole'),('Klyve'),('Lunde 10årige Skole')");
            


        }
        
        public override void Down()
        {
        }
    }
}
