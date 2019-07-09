namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Title",
                c => new
                    {
                        TitleID = c.Int(nullable: false, identity: true),
                        TitleWord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TitleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Title");
        }
    }
}
