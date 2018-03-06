namespace BookList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooksReadMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BooksReads",
                c => new
                    {
                        BRId = c.Int(nullable: false, identity: true),
                        ReaderId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Star = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BRId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Readers", t => t.ReaderId, cascadeDelete: true)
                .Index(t => t.ReaderId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BooksReads", "ReaderId", "dbo.Readers");
            DropForeignKey("dbo.BooksReads", "BookId", "dbo.Books");
            DropIndex("dbo.BooksReads", new[] { "BookId" });
            DropIndex("dbo.BooksReads", new[] { "ReaderId" });
            DropTable("dbo.BooksReads");
        }
    }
}
