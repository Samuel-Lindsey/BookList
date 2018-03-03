using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BookList.Models
{
    public class BooksViewModel
    {
        public int? BookId { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Author")]
        public string Author { get; set; }
 
    }
}