using System;
using BookList.Models;
using System.Data.Entity;
using System.Linq;



namespace BookList
{
  

    public class BooksListContext : DbContext
    {
      
        public BooksListContext() : base("name=BookList") { }
        
        public virtual DbSet<Books> Books { get; set; } 
        public virtual DbSet<Reader> Readers { get; set; }
        

        
    }



    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}