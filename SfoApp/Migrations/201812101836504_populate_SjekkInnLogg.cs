namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate_SjekkInnLogg : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SjekkInLoggs( SjekkInn ,SjekkUt ,Info,ElevId,SkoleId)VALUES('05/29/2018 7:50','05/29/2018 15:50','Bla bla bla',1,1)");
            Sql("INSERT INTO SjekkInLoggs( SjekkInn ,SjekkUt ,Info,ElevId,SkoleId)VALUES('05/30/2018 8:30','05/30/2018 16:00','Bla bla bla',1,1)");
            Sql("INSERT INTO SjekkInLoggs( SjekkInn ,SjekkUt ,Info,ElevId,SkoleId)VALUES('05/30/2018 9:30','05/30/2018 16:00','Bla bla bla',3,1)");
            Sql("INSERT INTO SjekkInLoggs( SjekkInn ,SjekkUt ,Info,ElevId,SkoleId)VALUES('05/30/2018 9:30','05/30/2018 16:00','Bla bla bla',3,1)");
            Sql("INSERT INTO SjekkInLoggs( SjekkInn ,SjekkUt ,Info,ElevId,SkoleId)VALUES('05/30/2018 9:30','05/30/2018 16:00','Bla bla bla',5,1)");
            Sql("INSERT INTO SjekkInLoggs( SjekkInn ,SjekkUt ,Info,ElevId,SkoleId)VALUES('05/30/2018 9:30','05/30/2018 16:00','Bla bla bla',6,1)");
        }
        
        public override void Down()
        {
        }
    }
}
