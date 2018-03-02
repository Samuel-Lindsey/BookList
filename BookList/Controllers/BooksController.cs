using BookList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookList.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            using (var booksListContext = new BooksListContext())
            {
                var booksList = new BooksViewModel
                {
                    //Convert each Book to a BooksViewModel
                    Books = booksListContext.Books.Select(b => new BooksViewModel
                    {
                        BookId = b.BookId,
                        Title = b.Title,
                        Author = b.Author
                    }).ToList()
                };

                

                return View(booksList);
            }
        }
    }
}