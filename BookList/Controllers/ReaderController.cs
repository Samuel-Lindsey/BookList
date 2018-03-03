using BookList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookList.Controllers
{
    public class ReaderController : Controller
    {
        public ActionResult Index()
        {
            using (var readerListContext = new BooksListContext())
            {
                var readerList = new ReaderListViewModel
                {
                    //Convert each Reader to a ReadersViewModel
                    Readers = readerListContext.Readers.Select(r => new ReaderViewModel
                    {
                        ReaderId = r.ReaderId,
                        Name = r.Name,
                        
                    }).ToList()
                };



                return View(readerList);
            }
        }
    }
}