using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BookList.Models
{
    public class BRViewModel
    {
        public int? BRId { get; set; }
        public BooksViewModel Books { get; set; }
        public ReaderViewModel Readers { get; set; }

        [DisplayName("Rating")]
        public int? Star { get; set; }

    }
}