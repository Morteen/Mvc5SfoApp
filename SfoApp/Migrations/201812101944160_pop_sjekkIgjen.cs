namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pop_sjekkIgjen : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SjekkInLoggs( SjekkInn ,SjekkUt ,Info,ElevId,SkoleId)VALUES('06/01/2018 11:30','06/01/2018 16:30','Vi prøver igjen',6,1)");
            Sql("INSERT INTO SjekkInLoggs( SjekkInn ,SjekkUt ,Info,ElevId,SkoleId)VALUES('06/02/2018 11:30','06/02/2018 16:30','Dette er en  ny forekomst',6,1)");
            Sql("INSERT INTO SjekkInLoggs( SjekkInn ,SjekkUt ,Info,ElevId,SkoleId)VALUES('06/03/2018 7:30','06/03/2018 16:15','Igjen og igjen',6,1)");
            Sql("INSERT INTO SjekkInLoggs( SjekkInn ,SjekkUt ,Info,ElevId,SkoleId)VALUES('06/03/2018 7:30','06/03/2018 16:15','Igjen og igjen for nummer 3',3,1)");
        }
        
        public override void Down()
        {
        }
    }
}
