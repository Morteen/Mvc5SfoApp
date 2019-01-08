namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pop_ansatte : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ansatts(Fornavn,Etternavn,Username,Password,SkoleId)VALUES('Morten','Olsen','morteen','1234',13)," +
                "('Gry','Kvilekval Olsen','gry','1234',14),('Maria','Kvilekval Olsen','maria','1234',15)");
        }
        
        public override void Down()
        {
        }
    }
}
