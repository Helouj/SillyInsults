namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSillyInsultsHistorytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SillyInsultHistory",
                c => new
                    {
                        SillyInsultHistoryID = c.Int(nullable: false, identity: true),
                        AdjectiveWord = c.String(),
                        NounWord = c.String(),
                        TitleWord = c.String(),
                    })
                .PrimaryKey(t => t.SillyInsultHistoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SillyInsultHistory");
        }
    }
}
