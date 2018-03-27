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
      // creates Readers List using reader Id passed in 
        public ActionResult ReadersBookList(int Id)
        {
            var returnBookList = new BRListViewModel();
            returnBookList.ReaderId = Id;
            using (var booksListContext = new BooksListContext())
            {
                var booksRead = booksListContext.BooksRead.Where(p => p.ReaderId == Id).ToList();
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
                        returnBookList.TotalBR = booksRead.Count; 

                    }


                    return View(returnBookList);



                }
            }

            return new HttpNotFoundResult();
        }

        public ActionResult ReadBooksAdd(int ReaderId)
        {
            var brViewModel = new BRViewModel();
            using (var booksListContext = new BooksListContext())
            {
                var reader = booksListContext.Readers.SingleOrDefault(p => p.ReaderId == ReaderId);
                var readerViewModel = new ReaderViewModel()
                {
                    ReaderId = ReaderId,
                    Name = reader.Name,
                   

                };

                brViewModel.Readers = readerViewModel;
                var booksRead = booksListContext.BooksRead.Where(p => p.ReaderId == ReaderId).ToList();
                var allbooks = booksListContext.Books.ToList();
                var Result = allbooks.Where(item => !booksRead.Any(item2 => item2.BookId == item.BookId));

                ViewBag.BooksRead = Result.Select(c => new SelectListItem
                
                {
                    Value = c.BookId.ToString(),
                    Text = c.Title
                }).ToList();
            }

           

            return View("AddEditBooksRead", brViewModel);
        }

        // httpost post to Datbase
        [HttpPost]
        public ActionResult AddReadBooks (BRViewModel brViewModel)
        {
            // Test if dropdown selector is empty and returns to Readers Book list
            if (brViewModel.Books == null) return RedirectToAction("ReadersBookList", new { Id = brViewModel.Readers.ReaderId.Value });
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

            return RedirectToAction("ReadersBookList", new { Id = brViewModel.Readers.ReaderId.Value });
        }

        [HttpPost]
        public ActionResult DeleteBookRead (BRViewModel brViewModel)
        {
            using (var booksListContext = new BooksListContext())
            {
          
                var bookRead = booksListContext.BooksRead.SingleOrDefault(b => b.BRId == brViewModel.BRId);
                

                if (bookRead != null)
                {

                    booksListContext.BooksRead.Remove(bookRead);
                    booksListContext.SaveChanges();

                    return RedirectToAction("ReadersBookList", new { Id = bookRead.ReaderId });
                   
                }
            }

            return new HttpNotFoundResult();
        }


    }
}