namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAdjectives : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adjective",
                c => new
                    {
                        AdjectiveID = c.Int(nullable: false, identity: true),
                        AdjectiveWord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdjectiveID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Adjective");
        }
    }
}
