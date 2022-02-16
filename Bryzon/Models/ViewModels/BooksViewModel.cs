using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bryzon.Models.ViewModels
{
    //Allow integration of both variables
    public class BooksViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}