using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookList.Models
{
    public class BooksRead
    {
        [Key]
        public int BRId { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public virtual Books Books { get; set; }
        public virtual Reader Reader { get; set; }
        public int Star { get; set; }
        
    }
}