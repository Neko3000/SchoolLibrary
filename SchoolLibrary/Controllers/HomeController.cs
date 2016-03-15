using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolLibrary.Models;
using Microsoft.AspNet.Identity;

namespace SchoolLibrary.Controllers
{
    public class HomeController : Controller
    {
        private SchoolLibraryContext db = new SchoolLibraryContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BookList(string keyword=null)
        {
            var userId = User.Identity.GetUserId();
            if(keyword==null||keyword=="")
            {
                ViewBag.UserId = userId;
                return View(db.Books.ToList());
            }
            else
            {
                var books = db.Books.Where(a => a.Title.Contains(keyword)).Take(10).ToList();
                //var books2 = (from book in db.Books
                //              where book.Id == 1
                //              select book).ToList() ;
                ViewBag.UserId = userId;
                return View(books);
            }        
        }
        public ActionResult PopularBook(int page=1)
        {
            var popularBooks = (from book in db.Books
                                join popularBook in db.PopularBooks
                                on book equals popularBook.BookId
                                select book).ToList();
            return View(popularBooks);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}