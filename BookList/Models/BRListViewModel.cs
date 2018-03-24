using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookList.Models
{
    public class BRListViewModel
 
    {
        public BRListViewModel()
        {
            BooksRead = new List<BRViewModel>();
        }
        public List<BRViewModel> BooksRead { get; set; }
        public int ReaderId { get; set; }
        public int TotalBR{ get; set; }
    }
}