using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bryzon.Models.ViewModels
{
    public class PageInfo
    {
        //create dnamic page info based on tables
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Calculate pages needed
        public int TotalPages => (int)Math.Ceiling((double)TotalNumBooks / BooksPerPage);
    }
}
