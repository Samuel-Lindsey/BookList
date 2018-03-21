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

                booksList.TotalBooks = booksList.Books.Count;

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
        public ActionResult BooksEdit(int id)
        {
            using (var booksListContext = new BooksListContext())
            {
                var books = booksListContext.Books.SingleOrDefault(b => b.BookId == id);
                if (books != null)
                {
                    var booksViewModel = new BooksViewModel
                    {
                        BookId = books.BookId,
                        Title = books.Title,
                        Author = books.Author
                    };

                    return View("AddEditBook", booksViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditBooks(BooksViewModel booksViewModel)
        {
            using (var booksListContext = new BooksListContext())
            {
                var books = booksListContext.Books.SingleOrDefault(b => b.BookId == booksViewModel.BookId);

                if (books != null)
                {
                    books.Title = booksViewModel.Title;
                    books.Author = booksViewModel.Author;
                    booksListContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult DeleteBooks(BooksViewModel booksViewModel)
        {
            using (var booksListContext = new BooksListContext())
            {
                var books = booksListContext.Books.SingleOrDefault(b => b.BookId == booksViewModel.BookId);

                if (books != null)
                {
                    booksListContext.Books.Remove(books);
                    booksListContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }
        

    }
}