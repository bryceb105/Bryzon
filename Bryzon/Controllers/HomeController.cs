using Bryzon.Models;
using Bryzon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bryzon.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookType, int pageNum = 1)
        {
            //Create book pages
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookType || bookType == null)
                .OrderBy(b => b.Title)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (bookType == null
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == bookType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
