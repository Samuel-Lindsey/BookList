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
                  new Books { BookId = 5, Title = "Happy", Author = "MeeToo"},
                  new Books { BookId = 6, Title = "The Land of Nod", Author = "Robert L. Stevenson & Robert Hunter" },
                  new Books { BookId = 7, Title = "Green Eggs and Ham", Author = "Dr. Seuss" },
                  new Books { BookId = 8, Title = "Beekle", Author = "Dan Santat" },
                  new Books { BookId = 9, Title = "Harold and the Purple Crayon", Author = "Crockett Johnson" },
                  new Books { BookId = 10, Title = "The Storyteller", Author = "Evan Turk" },
                  new Books { BookId = 11, Title = "After the Fall", Author = "Dan Santat" },
                  new Books { BookId = 12, Title = "Itsy Bitsy Spider", Author = "Kate Toms" },
                  new Books { BookId = 13, Title = "Dream Walkers", Author = "Adrienne Lindsey" },
                  new Books { BookId = 14, Title = "The Worm", Author = "Elise Gravel" }

                );

            context.Readers.AddOrUpdate(
                  b => b.ReaderId,
                  new Reader { ReaderId = 1, Name = "Silas"},
                  new Reader { ReaderId = 2, Name = "Leon"}
                );

            context.BooksRead.AddOrUpdate(
                  b => b.BRId,
                  new BooksRead { BRId = 1, ReaderId = 1, BookId = 3, Star = 4  },
                  new BooksRead { BRId = 2, ReaderId = 2, BookId = 4, Star = 3 },
                  new BooksRead { BRId = 3, ReaderId = 1, BookId = 1, Star = 4 },
                  new BooksRead { BRId = 4, ReaderId = 2, BookId = 2, Star = 5}
                );

        }
    }
}
