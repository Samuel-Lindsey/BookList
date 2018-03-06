using BookList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookList.Controllers
{
    public class BooksReadController : Controller
    {
        public ActionResult Index()
        {
            using (var booksListContext = new BooksListContext())
            {
                var brList = new BRListViewModel
                {
                    //Convert each BooksRead to a BooksReadViewModel
                    BooksRead = booksListContext.BooksRead.Select(r => new BRViewModel
                    {
                        BRId = r.BRId,
                    
                        Books = new BooksViewModel
                        {
                            BookId = r.Books.BookId,
                            Title = r.Books.Title,
                            Author = r.Books.Author
                        },

                        Readers = new ReaderViewModel
                        {
                            ReaderId = r.Reader.ReaderId,
                            Name = r.Reader.Name
                        }
                  
                    }).ToList()
                };

               // brList.TotalBooks = brList.Books.Count;

                return View(brList);
            }
        }

        public ActionResult ReadersBookList(int id)
        {
            using (var booksListContext = new BooksListContext())
            {
                var booksRead = booksListContext.BooksRead.SingleOrDefault(p => p.BRId == id);
                if (booksRead != null)
                {
                    var brViewModel = new BRViewModel
                    {
                        BRId = booksRead.BRId,

                        Books = new BooksViewModel
                        {
                            BookId = booksRead.BookId,
                            Title = booksRead.Books.Title,
                            Author = booksRead.Books.Author
                        },

                        Readers = new ReaderViewModel
                        {
                            ReaderId = booksRead.Reader.ReaderId,
                            Name = booksRead.Reader.Name
                        }


                    };

                    return View(brViewModel);
                }
            }

            return new HttpNotFoundResult();
        }
    }
}