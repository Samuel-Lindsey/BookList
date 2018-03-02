namespace BookList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReadersMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        ReaderId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ReaderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Readers");
        }
    }
}
