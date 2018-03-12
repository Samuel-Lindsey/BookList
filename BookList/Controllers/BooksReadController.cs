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

        public ActionResult ReadersBookList(int readerId)
        {
            var returnBookList = new BRListViewModel();
            using (var booksListContext = new BooksListContext())
            {
                var booksRead = booksListContext.BooksRead.Where(p => p.ReaderId == readerId).ToList();
                if (booksRead != null)
                {
                    foreach (var bookread in booksRead)
                    {
                        var brViewModel = new BRViewModel
                        {
                            BRId = bookread.BRId,

                            Books = new BooksViewModel
                            {
                                BookId = bookread.BookId,
                                Title = bookread.Books.Title,
                                Author = bookread.Books.Author
                            },

                            Readers = new ReaderViewModel
                            {
                                ReaderId = bookread.Reader.ReaderId,
                                Name = bookread.Reader.Name
                            }


                        };
                        returnBookList.BooksRead.Add(brViewModel);
                      
                    }

                    return View(returnBookList);



                }
            }

            return new HttpNotFoundResult();
        }

        public ActionResult ReadBooksAdd()
        {
            using (var booksListContext = new BooksListContext())
            {
                ViewBag.BooksRead = booksListContext.Books.Select(c => new SelectListItem
                {
                    Value = c.BookId.ToString(),
                    Text = c.Title
                }).ToList();
            }

            var brViewModel = new BRViewModel();

            return View("AddEditBooksRead", brViewModel);
        }

        [HttpPost]
        public ActionResult AddReadBooks (BRViewModel brViewModel)
        {
            using (var booksListContext = new BooksListContext())
            {
                var bookRead = new BooksRead
                {
                    ReaderId = brViewModel.Readers.ReaderId.Value,
                    BookId = brViewModel.Books.BookId.Value
                };

                booksListContext.BooksRead.Add(bookRead);
                booksListContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        

    }
}