namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSkole : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Skoles(SkoleNavn)VALUES('Holla 10�rige skole')");
            Sql("INSERT INTO Skoles(SkoleNavn)VALUES('�foss barneskole')");
            Sql("INSERT INTO Skoles(SkoleNavn)VALUES('Klyve barneskole')");
            Sql("INSERT INTO Skoles(SkoleNavn)VALUES('Skotfoss barneskole')");
            Sql("INSERT INTO Skoles(SkoleNavn)VALUES('Lunde barneskole')");

        }
        
        public override void Down()
        {
        }
    }
}
