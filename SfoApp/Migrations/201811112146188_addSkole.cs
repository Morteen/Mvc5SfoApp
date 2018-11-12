namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSkole : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Skoles(SkoleNavn)VALUES('Holla 10årige skole')");
            Sql("INSERT INTO Skoles(SkoleNavn)VALUES('Åfoss barneskole')");
            Sql("INSERT INTO Skoles(SkoleNavn)VALUES('Klyve barneskole')");
            Sql("INSERT INTO Skoles(SkoleNavn)VALUES('Skotfoss barneskole')");
            Sql("INSERT INTO Skoles(SkoleNavn)VALUES('Lunde barneskole')");

        }
        
        public override void Down()
        {
        }
    }
}
