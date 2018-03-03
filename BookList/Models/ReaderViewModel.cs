using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BookList.Models
{
    public class ReaderViewModel
    {
        public int? ReaderId { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }
       
    }
}