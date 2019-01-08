namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pop_moreElever : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Elevs(Fornavn,Etternavn,Trinn,Klasse,Telefon,SkoleId)VALUES('Kurt','Nielsen','3','B',152589,13),('Filip','Ingebretsen','1','B','5565265',14),('Heidi','Weng','2','A','6545455',14),('Jhohannes','Klæbo','3','B',152589,14)," +
                "('Mari','Tufte','1','B','5565265',15)," +
                "('Morten','harket','2','A','6545455',15)," +
                "('Magne','Furuholmen','3','B','152589',15)" );
        }
        
        public override void Down()
        {
        }
    }
}
