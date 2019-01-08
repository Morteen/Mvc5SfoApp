namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pop_elever : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Elevs(Fornavn,Etternavn,Trinn,Klasse,Telefon,SkoleId)VALUES('Bård', 'Tufte', '1', 'B', '5565265', 13)");

            Sql(
                "INSERT INTO Elevs(Fornavn,Etternavn,Trinn,Klasse,Telefon,SkoleId)VALUES('Harald','Eia','2','A','6545455',13)");
               
        }
        
        public override void Down()
        {
        }
    }
}
