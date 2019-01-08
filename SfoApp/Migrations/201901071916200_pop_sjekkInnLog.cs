namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pop_sjekkInnLog : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SjekkInLoggs(SjekkInn,SjekkUt,Aar,Dato,ElevId,AnsattId,SkoleId)VALUES(07.35,15.30,2019, 2.1, 1,4,13)," +
                "(08.00,15.00,2019, 3.1, 1,4,13),(07.37,15.34,2019, 4.1, 2,4,13),(07.35,15.30,2019, 2.1, 2,4,13),(07.35,15.30,2019, 2.1, 4,5,14)," +
                "(07.36,15.30,2019, 1.1, 9,6,15),(07.35,15.30,2019, 2.1, 3,4,13),(07.35,15.30,2019, 2.1, 2,1,13)");
        }
        
        public override void Down()
        {
        }
    }
}
