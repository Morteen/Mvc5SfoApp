namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pop_SjekkInnTryTwo : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SjekkInLoggs(SjekkInn,SjekkUt,Aar,Dato,ElevId,AnsattId,SkoleId)VALUES(07.40,15.30,2019, 3.1, 1,4,13)");
            Sql("INSERT INTO SjekkInLoggs(SjekkInn,SjekkUt,Aar,Dato,ElevId,AnsattId,SkoleId)VALUES(07.20,15.40,2019,43.1, 1,4,13)");

        }
        
        public override void Down()
        {
        }
    }
}
