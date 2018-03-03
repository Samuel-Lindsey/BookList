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
                var booksList = new BooksListViewModel
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

        public ActionResult BooksAdd()
        {
            var booksViewModel = new BooksViewModel();

            return View("AddEditBook", booksViewModel);
        }

        [HttpPost]
        public ActionResult AddBooks(BooksViewModel booksViewModel)
        {
            using (var booksListContext = new BooksListContext())
            {
                var books = new Books
                {
                    Title = booksViewModel.Title,
                    Author = booksViewModel.Author
                };

                booksListContext.Books.Add(books);
                booksListContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}