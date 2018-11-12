namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate_Ansatt_and_Elev : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ansatts( Fornavn,Etternavn,SkoleId)VALUES('Gry','Kvilekval Olsen',1)");
            Sql("INSERT INTO Ansatts( Fornavn,Etternavn,SkoleId)VALUES('Morten','Kvilekval Olsen',1)");
            Sql("INSERT INTO Ansatts( Fornavn,Etternavn,SkoleId)VALUES('Maria','Kvilekval Olsen',1)");
            Sql("INSERT INTO Ansatts( Fornavn,Etternavn,SkoleId)VALUES('Kåre','Kvilekval', 2)");
            Sql("INSERT INTO Ansatts( Fornavn,Etternavn,SkoleId)VALUES('Tine','Kvilekval ' ,2)");

            Sql("INSERT INTO Elevs( Fornavn,Etternavn,Trinn,Klasse,SkoleId)VALUES('Ola','Normann',1,'B',1)");
            Sql("INSERT INTO Elevs( Fornavn,Etternavn,Trinn,Klasse,SkoleId)VALUES('Kari','Normann',2,'A',2)");
            Sql("INSERT INTO Elevs( Fornavn,Etternavn,Trinn,Klasse,SkoleId)VALUES('Mari','Marisen',1,'B',1)");
            Sql("INSERT INTO Elevs( Fornavn,Etternavn,Trinn,Klasse,SkoleId)VALUES('Janne','Jannessen',3,'a',2)");
            Sql("INSERT INTO Elevs( Fornavn,Etternavn,Trinn,Klasse,SkoleId)VALUES('Kari','Traa',1,'B',1)");
            Sql("INSERT INTO Elevs( Fornavn,Etternavn,Trinn,Klasse,SkoleId)VALUES('Olav','Tufte',1,'B',1)");
        }
        
        public override void Down()
        {
        }
    }
}
