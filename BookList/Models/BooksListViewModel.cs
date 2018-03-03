using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookList.Models
{
    public class BooksListViewModel
    {
        public List <BooksViewModel> Books { get; set; }
        public int TotalBooks { get; set; }
    }
}