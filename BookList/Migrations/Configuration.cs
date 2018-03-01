namespace BookList.Migrations
{
    using BookList.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BooksListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BooksListContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            
                context.Books.AddOrUpdate(
                  b => b.BookId,
                  new Books { BookId = 1, Title = "Wind", Author = "Carol Thompson" },
                  new Books { BookId = 2, Title = "Grumpy Bird", Author = "Jeremy Tankard" },
                  new Books { BookId = 3, Title = "How Hippo Says Hello", Author = "Abigail Samoun" },
                  new Books { BookId = 4, Title ="GEM", Author = "Holly Hobbie" },
                  new Books { BookId = 5, Title = "Happy", Author = "MeeToo"}

                );
            
        }
    }
}