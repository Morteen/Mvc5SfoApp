namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pop_skoler : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Skoles(SkoleNavn)VALUES('�foss'),('Holla 10�rige Skole'),('Klyve'),('Lunde 10�rige Skole')");
            


        }
        
        public override void Down()
        {
        }
    }
}
